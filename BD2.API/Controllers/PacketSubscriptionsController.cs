﻿using AutoMapper;
using BD2.API.Database.Entities;
using BD2.API.Database.Repositories.Concrete;
using BD2.API.Database.Repositories.Interfaces;
using BD2.API.Models.Packets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BD2.API.Controllers
{
    [Route("[controller]")]
    public class PacketSubscriptionsController : ExtendedControllerBase
    {
        private readonly IPacketSubscriptionsRepository _repo;
        private readonly IPacketsRepository _prepo;
        private readonly IMapper _mapper;

        public PacketSubscriptionsController(IPacketSubscriptionsRepository repo, IMapper mapper, IPacketsRepository prepo)
        {
            _repo = repo;
            _mapper = mapper;
            _prepo = prepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetMyPackets()
        {
            var found = await _repo
                .All()
                .Where(x => x.OwnerId == UserId)
                .Include(x => x.Groups)
                .ToListAsync();

            if (found == null)
            {
                return BadRequest(new
                {
                    Success = false,
                    Errors = new List<string> { "Nie znaleziono pakietów dla użytkonika o podanym id" }
                });
            }

            return Ok(new
            {
                Success = true,
                data = found
            });
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddSubscriptionPacketModel model) // dodawanie nowych encji
        {
            if (model == null && model.PacketId == default)
            {
                return BadRequest(new
                {
                    Success = false,
                    Errors = new List<string> { "Nieprawidłowe dane" }
                });
            }

            var packet = await _prepo.All().Where(x => x.Id == model.PacketId).FirstOrDefaultAsync();

            if (packet == null)
            {
                return BadRequest(new
                {
                    Success = false,
                    Errors = new List<string> { "Nie znaleziono pakietu o podanym id" }
                });
            }

            // set packet data 
            var subcription = _mapper.Map<PacketSubscription>(model);
            subcription.OwnerId = (Guid)UserId;
            subcription.ExpirationDate = DateTime.Now.AddMonths(packet.PacketPeriod);
            
            var result = await _repo.AddAsync(subcription); 

            if (!result)
            {
                return BadRequest(new
                {
                    Success = false,
                    Errors = new List<string> { "Nie udało się wykupic sybskrybcji. Spróbuj ponownie później." }
                });
            }

            return Ok(new
            {
                Success = true,
                data = subcription
            });
        }
    }
}

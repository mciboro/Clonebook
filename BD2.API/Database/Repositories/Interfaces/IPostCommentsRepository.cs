﻿using BD2.API.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BD2.API.Database.Repositories.Interfaces
{
    public interface IPostCommentsRepository
    {
        public Task<PostComment> FindAsync(Guid PostId, Guid UserId);

        public Task<bool> AddAsync(PostComment entity);
        public Task<int> AddRangeAsync(IEnumerable<PostComment> entities);
        public Task<bool> UpdateAsync(PostComment entity);
        public Task<bool> DeleteAsync(Guid PostId, Guid UserId);
        public IQueryable<PostComment> All();
        public IQueryable<PostComment> AllByPost(Guid PostId);
    }
}

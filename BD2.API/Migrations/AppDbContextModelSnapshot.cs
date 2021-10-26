﻿// <auto-generated />
using System;
using BD2.API.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BD2.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BD2.API.Database.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.AccountImage", b =>
                {
                    b.Property<Guid>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ImageId", "AccountId");

                    b.HasIndex("AccountId");

                    b.ToTable("AccountImage");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID ()");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID ()");

                    b.Property<Guid>("AuthoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthoId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Chat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID ()");

                    b.Property<DateTime?>("LastPostDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Chat");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.ChatAccount", b =>
                {
                    b.Property<Guid>("ChatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ChatId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("LastViewDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ChatId", "AccountId");

                    b.HasIndex("AccountId");

                    b.HasIndex("ChatId1");

                    b.ToTable("ChatAccount");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.ChatEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID ()");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ChatId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("PostDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("ChatId");

                    b.HasIndex("ChatId1");

                    b.ToTable("ChatEntry");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Friendship", b =>
                {
                    b.Property<Guid>("FirstFriendId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SecondFriendId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FriendshipBeginDate")
                        .HasColumnType("datetime2");

                    b.HasKey("FirstFriendId", "SecondFriendId");

                    b.HasIndex("SecondFriendId");

                    b.ToTable("Friendship");

                    b.HasCheckConstraint("NotSelfFriends_Friendship_constraint", "FirstFriendId <> SecondFriendId");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID ()");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("LastPostDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.GroupAccount", b =>
                {
                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GroupId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("LastViewDate")
                        .HasColumnType("datetime2");

                    b.HasKey("GroupId", "AccountId");

                    b.HasIndex("AccountId");

                    b.HasIndex("GroupId1");

                    b.ToTable("GroupAccount");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<byte[]>("File")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("MimeType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("PostDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Invitation", b =>
                {
                    b.Property<Guid>("InvitingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InvitedId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("InvitationSendAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("InvitingId", "InvitedId");

                    b.HasIndex("InvitedId");

                    b.ToTable("Invitation");

                    b.HasCheckConstraint("NotSelfInvited_Friendship_constraint", "InvitingId <> InvitedId");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID ()");

                    b.Property<int>("CommentsCount")
                        .HasColumnType("int");

                    b.Property<Guid?>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastCommentDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastOwnerViewDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastReactionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("NegativeReactionCount")
                        .HasColumnType("int");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PositiveReactionsCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("PostDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("ViewsCounts")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.PostComment", b =>
                {
                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountId", "PostId");

                    b.HasIndex("PostId");

                    b.ToTable("PostComment");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.PostImage", b =>
                {
                    b.Property<Guid>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PostId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ImageId", "PostId");

                    b.HasIndex("PostId");

                    b.HasIndex("PostId1");

                    b.ToTable("PostImage");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.PostReaction", b =>
                {
                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("AccountId", "PostId");

                    b.HasIndex("PostId");

                    b.ToTable("PostReaction");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.PostView", b =>
                {
                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ViewDate")
                        .HasColumnType("datetime2");

                    b.HasKey("AccountId", "PostId");

                    b.HasIndex("PostId");

                    b.ToTable("PostView");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.AccountImage", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BD2.API.Database.Entities.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Book", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.ChatAccount", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .IsRequired();

                    b.HasOne("BD2.API.Database.Entities.Chat", "Chat")
                        .WithMany()
                        .HasForeignKey("ChatId")
                        .IsRequired();

                    b.HasOne("BD2.API.Database.Entities.Chat", null)
                        .WithMany("Members")
                        .HasForeignKey("ChatId1");

                    b.Navigation("Account");

                    b.Navigation("Chat");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.ChatEntry", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .IsRequired();

                    b.HasOne("BD2.API.Database.Entities.Chat", "Chat")
                        .WithMany()
                        .HasForeignKey("ChatId")
                        .IsRequired();

                    b.HasOne("BD2.API.Database.Entities.Chat", null)
                        .WithMany("Entries")
                        .HasForeignKey("ChatId1");

                    b.Navigation("Account");

                    b.Navigation("Chat");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Friendship", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.Account", "FirstFriend")
                        .WithMany()
                        .HasForeignKey("FirstFriendId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("BD2.API.Database.Entities.Account", "SecondFriend")
                        .WithMany()
                        .HasForeignKey("SecondFriendId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("FirstFriend");

                    b.Navigation("SecondFriend");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.GroupAccount", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .IsRequired();

                    b.HasOne("BD2.API.Database.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .IsRequired();

                    b.HasOne("BD2.API.Database.Entities.Group", null)
                        .WithMany("Members")
                        .HasForeignKey("GroupId1");

                    b.Navigation("Account");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Invitation", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.Account", "Invited")
                        .WithMany()
                        .HasForeignKey("InvitedId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("BD2.API.Database.Entities.Account", "Inviting")
                        .WithMany()
                        .HasForeignKey("InvitingId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Invited");

                    b.Navigation("Inviting");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Post", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.Group", "Group")
                        .WithMany("Posts")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BD2.API.Database.Entities.Account", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.PostComment", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .IsRequired();

                    b.HasOne("BD2.API.Database.Entities.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.PostImage", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId")
                        .IsRequired();

                    b.HasOne("BD2.API.Database.Entities.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .IsRequired();

                    b.HasOne("BD2.API.Database.Entities.Post", null)
                        .WithMany("Images")
                        .HasForeignKey("PostId1");

                    b.Navigation("Image");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.PostReaction", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .IsRequired();

                    b.HasOne("BD2.API.Database.Entities.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.PostView", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .IsRequired();

                    b.HasOne("BD2.API.Database.Entities.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.Account", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.Account", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BD2.API.Database.Entities.Account", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("BD2.API.Database.Entities.Account", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Chat", b =>
                {
                    b.Navigation("Entries");

                    b.Navigation("Members");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Group", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("BD2.API.Database.Entities.Post", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}

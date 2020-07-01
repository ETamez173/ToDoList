﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<ToDoItem> ToDoList { get; set; }

        public DbSet<ToDoStatus> ToDoStatuses { get; set; }
        public object ToDoStatus { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Create a new user for Identity Framework
            ApplicationUser user = new ApplicationUser
            {
                FirstName = "Eli",
                LastName = "Tamez",
                UserName = "e@e.com",
                NormalizedUserName = "E@E.COM",
                Email = "e@e.com",
                NormalizedEmail = "E@E.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-ffff-ffff-ffff-ffffffffffff"
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            // Create statuses
            modelBuilder.Entity<ToDoStatus>().HasData(
                new ToDoStatus()
                {
                    Id = 1,
                    Title = "To Do"

                },
                new ToDoStatus()
                {
                    Id = 2,
                    Title = "In Progress"
                },
                new ToDoStatus()
                {
                    Id = 3,
                    Title = "Done"
                }
            );

        }
    }
}

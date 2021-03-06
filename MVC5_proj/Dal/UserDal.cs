﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MVC5_proj.Models;

namespace MVC5_proj.Dal
{
    public class UserDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Contact>().ToTable("Contact");
            modelBuilder.Entity<Patient>().ToTable("Patients");
        }

        //property Collection  that returns us Dbset of obj User
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Patient> patients { get; set; }
    }

}


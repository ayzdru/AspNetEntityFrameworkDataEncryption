﻿using AspNetEntityFrameworkDataEncryption.Entities;
using AspNetEntityFrameworkDataEncryption.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetEntityFrameworkDataEncryption.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private readonly static ValueConverter<string,string> _encryptionValueConverter = new ValueConverter<string, string>(
    v => AesEncryptionExtension.Encrypt(v),
    v => AesEncryptionExtension.Decrypt(v));
        public DbSet<Person> Persons { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Person>().Property(p => p.Identity).HasConversion(_encryptionValueConverter);
            builder.Entity<Person>().Property(p => p.PhoneNumber).HasConversion(_encryptionValueConverter);
            builder.Entity<Person>().HasData(
   new Person() { Id = Guid.NewGuid(), Identity = "8248649570", FirstName =  "Ayaz", LastName = "Duru", PhoneNumber = "5554442121" });
        }
    }
}

﻿using EntityFrameworkWithPostgresPOC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhanhVn.EntityFramework
{
    public class DbContextFactory: IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ApplicationDbContext> builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            var context = new ApplicationDbContext(
                builder
                .UseNpgsql("Host=localhost;Database=nhanhDb;Username=postgres;Password=password")
                .UseLowerCaseNamingConvention()
                .Options);

            return context;
        }

    }
}

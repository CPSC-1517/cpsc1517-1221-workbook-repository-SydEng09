﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.Entities;

namespace WestWindSystem.DAL
{
    internal class WestwindContext:DbContext
    {
        public WestwindContext(DbContextOptions<WestwindContext> options) : base(options)
        {
            
        }
        public DbSet<BuildVersion> BuildVersions => Set<BuildVersion>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Product> Products => Set<Product>();
    }
}

﻿
using Microsoft.EntityFrameworkCore;
using BlazorDentista.Server.Models;

namespace BlazorDentista.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}

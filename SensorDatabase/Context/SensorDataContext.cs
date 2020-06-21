using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SensorDatabase.Context
{
    public class SensorDataContext : DbContext
    {
        public SensorDataContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=LocalSensorData;user=qeusadicha;password=Af3K9m08");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        public DbSet<SensorData> DataPoints {get; set;}
        public DbSet<Device> devices { get; set; }
        public DbSet<SensorType> sensorTypes { get; set; }
        public DbSet<Software> softwares { get; set; }
    }
}

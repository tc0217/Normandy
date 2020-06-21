using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MySql.Data.EntityFrameworkCore;

namespace SensorDatabase
{
    public class Device
    {
        [Key]
        public int deviceID { get; set; }
        public SensorType Type { get; set; }
        public string deviceName { get; set; }
        public Software Software { get; set; }
    }
}

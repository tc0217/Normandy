using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SensorDatabase
{
    public class SensorData
    {
        [Key]
        public int dataID { get; set; }
        public Device Device { get; set; }
        public DateTime ReadTime { get; set; }
        public double Value { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SensorDatabase
{
    public class SensorType
    {
        [Key]
        public int typeID { get; set; }
        public string typeName { get; set; }
        public string Units { get; set; }

    }
}

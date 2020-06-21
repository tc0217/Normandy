using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SensorDatabase
{
    public class Software
    {
        [Key]
        public int softwareID { get; set; }
        public string SWName { get; set; }
        public string Revision { get; set; }
    }
}

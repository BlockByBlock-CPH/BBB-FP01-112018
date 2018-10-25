using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlockByBlock.Models
{
    public class Mtc_Homezone
    {
        [Key]        
        public int Id_hz { get; set; }
        public int Zone_hz { get; set; }
        public int Home_hz { get; set; }       
        public int Day_hz { get; set; }
        public double Shared_hz { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlockByBlock.Models
{
    
    public class Mtc_Activity
    {
        
        [Key]
        public int Id_act { get; set; }
        public int Zone_act { get; set; }
        public int Count_act { get; set; }
        public int Hours_act { get; set; }        
        public int Day_act { get; set; }
        public double Density { get; set; }

    }
}
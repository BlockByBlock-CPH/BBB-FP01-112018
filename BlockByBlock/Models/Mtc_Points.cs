using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlockByBlock.Models
{
    public class Mtc_Points
    {   
        public int Id { get; set; }
        public int MId { get; set; }        
        public double X { get; set; }
        public double Y { get; set; }        
    }
}
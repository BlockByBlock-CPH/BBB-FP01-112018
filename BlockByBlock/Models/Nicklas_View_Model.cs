using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlockByBlock.Models
{
    public class Nicklas_View_Model
    {
        List<Zone> Related_Zone { get; set; }

        public int Radius { get; set; }
        public int InnerRadius { get; set; }
        public int MiddleRadius { get; set; }
        public int OuterRadius { get; set; }

       
    }

    public class Zone
    {
        public double Percent { get; set; }
        public double Distance { get; set; }
        
    }


}
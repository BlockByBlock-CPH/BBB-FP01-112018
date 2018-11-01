using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlockByBlock.Models
{
    public class Mtc
    {
        [Key]
        public int Gid { get; set; }
        public int Id { get; set; }
        public double Groesse { get; set; }
        public string Geom { get; set; }
        //[Column(TypeName = "Geometry")]
        //public DbGeometry  Geom { get; set; }
        //public System.Data.Spatial.DbGeography Geom { get; set; }
        public double Area { get; set; }
    }
}
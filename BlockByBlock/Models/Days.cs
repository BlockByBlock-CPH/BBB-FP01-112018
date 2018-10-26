using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlockByBlock.Models
{
    public class Days
    {
        [Key]
        public int Id_Day { get; set; }
        public string Name_Day { get; set; }
    }
}
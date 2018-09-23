using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string Hours_act { get; set; }
        public string Days_act { get; set; }
    }
}
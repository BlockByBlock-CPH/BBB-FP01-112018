﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlockByBlock.Models
{
    public class Product
    {[Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
    }
}
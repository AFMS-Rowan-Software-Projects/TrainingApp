﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainingApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string CatName { get; set; }

    }
}
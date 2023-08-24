﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWebApp.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public string? ISBN { get; set; }
        [Required]
        public string? Author { get; set; }
        [Required]
        [Range(1,10000)]
        public int ListPrice { get; set; }
        [Range(1,10000)]
        public int Price { get; set; }
        [Required]
        [Range(1,10000)]
        public int Price50 { get; set; }
        [Required]
        [Range(1,10000)]
        public int Price100 { get; set; }
        public string? ImageURL { get; set;}
        [Required]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        [Required]
        public int CoverTypeId { get; set; }
        public CoverType? CoverType { get; set; }
    }
}

﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleMvcCRUDApp.Data.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

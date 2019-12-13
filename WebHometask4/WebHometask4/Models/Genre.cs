using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebHometask4.Models
{
    public class Genre
    {
        [Key]
        public decimal Id { get; set; }
        public string Name { get; set; }
    }
}

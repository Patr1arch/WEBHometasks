using System;
using System.Collections.Generic;

namespace WebHometask7.Models
{
    public partial class Films
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public string AgeRate { get; set; }
        public double FilmRatio { get; set; }

        public virtual Companies Company { get; set; }
    }
}

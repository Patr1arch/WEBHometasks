using System;
using System.Collections.Generic;

namespace WebHometask7.Models
{
    public partial class Companies
    {
        public Companies()
        {
            Films = new HashSet<Films>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual ICollection<Films> Films { get; set; }
    }
}

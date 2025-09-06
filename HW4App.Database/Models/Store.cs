using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4App.Database.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? Description { get; set; }

        public int CompanyId { get; set; }
        public Company? Company { get; set; }

        public List<Client> Clients { get; set; } = null!;

    }
}

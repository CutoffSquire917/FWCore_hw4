using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4App.Database.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Surname { get; set; }

        public List<Store> Stores { get; set; } = null!;
    }
}

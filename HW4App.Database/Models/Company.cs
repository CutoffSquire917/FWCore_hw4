using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4App.Database.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateOnly CreatedAt { get; set; }

        public List<Store> Stores { get; set; } = null!;

    }
}

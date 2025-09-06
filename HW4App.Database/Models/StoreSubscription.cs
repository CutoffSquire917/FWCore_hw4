using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4App.Database.Models
{
    public class StoreSubscription
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public Store? Store { get; set; }

        public int ClientId { get; set; }
        public Client? Client { get; set; }

        public DateTime SubscribedAt { get; set; }
    }
}

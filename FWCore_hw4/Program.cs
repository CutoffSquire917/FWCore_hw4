

using HW4App.Database.Data;
using HW4App.Database.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

class Program
{
    static void Main()
    {

        SubscriptionServis.Restart();

        var Company_FreshMart = new Company
        {
            Name = "FreshMart",
            CreatedAt = new DateOnly(2010, 5, 12),
            Stores = new List<Store>
                {
                    new Store { Name = "FreshMart — Downtown", Address = "12 Main St", Description = "Central grocery store" },
                    new Store { Name = "FreshMart — Northside", Address = "88 North Ave", Description = "Neighborhood market" },
                    new Store { Name = "FreshMart — East End", Address = "45 East Blvd", Description = "Large supermarket" }
                }
        };
        var Company_TechWorld = new Company
        {
            Name = "TechWorld",
            CreatedAt = new DateOnly(2015, 11, 3),
            Stores = new List<Store>
                {
                    new Store { Name = "TechWorld — Main Plaza", Address = "200 Plaza Dr", Description = "Electronics flagship" },
                    new Store { Name = "TechWorld — South Center", Address = "500 South St", Description = "Large retail outlet" }
                }
        };
        var Company_StyleHouse = new Company
        {
            Name = "StyleHouse",
            CreatedAt = new DateOnly(2008, 3, 22),
            Stores = new List<Store>
                {
                    new Store { Name = "StyleHouse — Central Mall", Address = "90 Center Mall", Description = "Fashion mall branch" },
                    new Store { Name = "StyleHouse — City Park", Address = "12 Park Rd", Description = "Trendy boutique" },
                    new Store { Name = "StyleHouse — Metro Station", Address = "25 Metro Ln", Description = "Compact fashion shop" },
                    new Store { Name = "StyleHouse — Riverwalk", Address = "88 Riverwalk", Description = "Clothing & accessories" }
                }
        };

        var clients = new List<Client>
        {
            new Client { Name = "Alice", Surname = "Johnson" },
            new Client { Name = "Kevin", Surname = "Lewis" },
            new Client { Name = "Laura"},
            new Client { Name = "Michael"},
            new Client { Name = "Nora", Surname = "Young" },
            new Client { Name = "Oscar"}
        };

        SubscriptionServis.AddSubscribe(clients[0], Company_StyleHouse, Company_StyleHouse.Stores[1]);
        SubscriptionServis.AddSubscribe(clients[1], Company_FreshMart, Company_FreshMart.Stores[0]);
        SubscriptionServis.AddSubscribe(clients[2], Company_TechWorld, Company_TechWorld.Stores[1]);
        SubscriptionServis.AddSubscribe(clients[2], Company_FreshMart, Company_FreshMart.Stores[1]);
        SubscriptionServis.AddSubscribe(clients[3], Company_StyleHouse, Company_StyleHouse.Stores[0]);
        SubscriptionServis.AddSubscribe(clients[3], Company_TechWorld, Company_TechWorld.Stores[0]);
        SubscriptionServis.AddSubscribe(clients[4], Company_FreshMart, Company_FreshMart.Stores[2]);
        SubscriptionServis.AddSubscribe(clients[4], Company_StyleHouse, Company_StyleHouse.Stores[3]);
        SubscriptionServis.AddSubscribe(clients[4], Company_TechWorld, Company_TechWorld.Stores[1]);
        SubscriptionServis.AddSubscribe(clients[5], Company_FreshMart, Company_FreshMart.Stores[0]);
        SubscriptionServis.AddSubscribe(clients[5], Company_StyleHouse, Company_StyleHouse.Stores[2]);

        Console.WriteLine("\t-- SubscriptionServis.PrintSubscription() --\n");
        SubscriptionServis.PrintSubscription();
        Console.WriteLine("\t-- SubscriptionServis.PrintAllClients() --\n");
        SubscriptionServis.PrintAllClients();
        Console.WriteLine("\t-- SubscriptionServis.PrintAllCompaniesWhoHaveMoreThan(x) --\n");
        SubscriptionServis.PrintAllCompaniesWhoHaveMoreThan(0);
        Console.WriteLine("\t-- SubscriptionServis.PrintAllClientsWhoSubscribedMoreThan(x) --\n");
        SubscriptionServis.PrintAllClientsWhoSubscribedMoreThan(0);

    }
}


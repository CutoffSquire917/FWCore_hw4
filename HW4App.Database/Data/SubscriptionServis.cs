using HW4App.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HW4App.Database.Data
{
    public class SubscriptionServis
    {
        public static void AddSubscribe(Client client, Company company, Store store)
        {
            
            using (ApplicationContext db = new ApplicationContext())
            {
                store.Company = company;
                var attachedClient = db.Clients.Find(client.Id);
                var attachedStore = db.Stores.Find(store.Id);
                db.StoresSubscriptions.Add(new StoreSubscription {
                    Client = attachedClient == null ? client : attachedClient,
                    Store = attachedStore == null ? store : attachedStore
                });
                db.SaveChanges();
            }
        }
        public static void AddSubscribe(Client client, Store store)
        {

            using (ApplicationContext db = new ApplicationContext())
            {
                if (store.Company == null)
                {
                    throw new ArgumentNullException("Store must to have a company");
                }
                var attachedClient = db.Clients.Find(client.Id);
                var attachedStore = db.Stores.Find(store.Id);
                db.StoresSubscriptions.Add(new StoreSubscription
                {
                    Client = attachedClient == null ? client : attachedClient,
                    Store = attachedStore == null ? store : attachedStore
                });
                db.SaveChanges();
            }
        }

        public static void PrintSubscription()
        {
            List<Company>? companies;
            using (ApplicationContext db = new ApplicationContext())
            {
                companies =
                    db.Companies.Include(e => e.Stores).ThenInclude(e => e.Clients).ToList();
            }
            if (companies.IsNullOrEmpty())
            {
                return;
            }
            foreach (var company in companies)
            {
                Console.WriteLine($"{company.Name} ({company.Stores.Select(e => e.Clients.Count).ToArray().Sum()}):");
                Console.WriteLine(string.Join("\n", company.Stores.Select(e => $"  -- {e.Name}:\n{string.Join("\n", e.Clients.Select(c => $"     > {c.Name} {(c.Surname != null ? c.Surname : "\b")}").ToArray())}").ToArray()));
            }
        }

        public static void PrintAllClients()
        {
            List<Client>? clients;
            using (ApplicationContext db = new ApplicationContext())
            {
                clients =
                    db.Clients.Include(e => e.Stores).ThenInclude(e => e.Company).ToList();
            }
            if (clients.IsNullOrEmpty())
            {
                return;
            }
            foreach (var client in clients)
            {
                Console.WriteLine($"{client.Name} {((client.Surname != null) ? client.Surname : "\b")}:");
                Console.WriteLine(string.Join("\n", client.Stores.Select(e => $" - {e.Name} ({e.Company.Name})").ToArray() ));
            }
        }

        public static void PrintAllCompaniesWhoHaveMoreThan(int moreThan = 0)
        {
            List<Company>? companies;
            using (ApplicationContext db = new ApplicationContext())
            {
                companies =
                    db.Companies.Include(e => e.Stores).ToList();
            }
            if (companies.IsNullOrEmpty())
            {
                return;
            }
            foreach (var company in companies)
            {
                if (company.Stores.Count <= moreThan)
                {
                    continue;
                }
                Console.WriteLine($"{company.Name} ({company.Stores.Count}):");
                Console.WriteLine(string.Join("\n", company.Stores.Select(e => $" - {e.Name} ({e.Address})").ToArray()));
            }
        }

        public static void PrintAllClientsWhoSubscribedMoreThan(int moreThan = 0)
        {
            List<Client>? clients;
            using (ApplicationContext db = new ApplicationContext())
            {
                clients = db.Clients.Include(e => e.Stores).ToList();
            }
            if (clients.IsNullOrEmpty())
            {
                return;
            }
            foreach (var client in clients)
            {
                if (client.Stores.Count <= moreThan)
                {
                    continue;
                }
                Console.WriteLine($"{client.Name} {((client.Surname != null) ? client.Surname : "\b")} ({client.Stores.Count}):");
                Console.WriteLine(string.Join("\n", client.Stores.Select(e => $" - {e.Name}").ToArray()));
            }
        }

        public static bool Restart()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                try
                {
                    db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();
                    return true;
                }
                catch { return false; }
            }
            
        }
    }
}

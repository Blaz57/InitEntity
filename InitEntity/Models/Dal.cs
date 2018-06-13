using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InitEntity.Models
{
    public class Dal : IDisposable
    {
        //Dal : data access layer

        protected BddContext db;

        public Dal()
        {
            db = new BddContext();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public List<Client> GetClients()
        {
            return db.Clients.ToList();
        }

        public List<Client> GetClients(Predicate<Client> _predicate)
        {
            List<Client> result = new List<Client>();
            foreach (Client client in db.Clients)
            {
                if (_predicate(client))
                {
                    result.Add(client);
                }
            }

            return result;
        }

        public Client GetClient(int _id)
        {
            return db.Clients.FirstOrDefault(x => x.Id == _id);
        }


        public void AddClient(Client _client)
        {
            db.Clients.Add(_client);
            db.SaveChanges();
        }

        public void UpdateClient(Client _client)
        {
           Client upClient;
 
           upClient= GetClient(_client.Id);
           if (upClient != default(Client))
           {
                upClient.Lastname = _client.Lastname;
                upClient.Firstname = _client.Firstname;
                db.SaveChanges();
           }
            
        }

        public void DeleteClient(int _id)
        {
            Client delClient = GetClient(_id);
            if (delClient != default(Client))
            {
                db.Clients.Remove(delClient);
                db.SaveChanges();
            }
        }

        public void TruncateClients()
        {
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE Clients;");
        }
    }
}
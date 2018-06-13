using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InitEntity.Models;
using System.Collections.Generic;

namespace InitEntity.Tests
{
    [TestClass]
    public class TestClient
    {

        Dal dal = new Dal();

        Client client1 = new Client() { Firstname = "Alex", Lastname = "BLAZ" };
        Client client2 = new Client() { Firstname = "Tatan", Lastname = "KAM" };
        Client client3 = new Client() { Firstname = "Jean", Lastname = "FUIS" };

        [TestMethod]
        public void Test_Ajout_Clients()
        {
            dal.TruncateClients();
            int nb = dal.GetClients().Count;

            Assert.AreEqual(0, nb, "La table n'est pas vide. ");
            dal.AddClient(client1);


            List<Client> dbClient = dal.GetClients();
            Assert.AreEqual(1, dbClient.Count, "Le Client n'a pas été créé. ");
            Assert.AreEqual(client1.Firstname, dbClient[0].Firstname, "Le prénom duclient ne correspond pas");
            Assert.AreEqual(client1.Lastname, dbClient[0].Lastname, "Le nom duclient ne correspond pas");
            //List<Client> dbClient = dal.GetClients(x=> x.Lastname=="BLAZ");

           dal.TruncateClients();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MindBodyStarTest.ClassService;
using MindBodyStarTest.ClientService;
using WebApplication1.Services;
using Class = WebApplication1.ClassService.Class;
using Client = MindBodyStarTest.ClientService.Client;

namespace MindBodyStarTest
{
    [TestClass]
    public class StarTest
    {
        public void SetUp(Class[] classes)
        {
            // Create Clients
            TestClients.CreateClients(50);
            TestClients.CheckInClients(classes);


        }

        [TestMethod]
        public void StartRewardTest()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 |
                                                   SecurityProtocolType.Tls11;

            var starRewardService = new StarRewardService();

            var startAndEndDate = DateTime.Now.AddDays(-1);

            var classes = starRewardService.GetClasses(startAndEndDate, startAndEndDate);
            var clients = starRewardService.GetNames(classes);
            Assert.AreEqual(clients.Count, 0);

            SetUp(classes);

            classes = starRewardService.GetClasses(startAndEndDate,startAndEndDate);
            clients = starRewardService.GetNames(classes);

            Assert.AreEqual(clients.Count,30);

            var highestPair = clients.OrderByDescending(pair => pair.Value).FirstOrDefault().Key;

            Assert.IsTrue(highestPair.Equals("Katie"));
        }
    }

    public class TestClients
    {
        private static ClientService.ClientService _clientService = new ClientService.ClientService() ;
        private static ClassService.ClassService _classService = new ClassService.ClassService();

        private static List<string> idList = new List<string>();
        private readonly List<Client> _clients;
        private static ClientService.SourceCredentials clientSourceCredentials = new ClientService.SourceCredentials()
        {
            SourceName = "",
            Password = "",
            SiteIDs = new int[] { -99 }
        };
        private static ClassService.SourceCredentials classSourceCredentials = new ClassService.SourceCredentials()
        {
            SourceName = "",
            Password = "",
            SiteIDs = new int[] { -99 }
        };

        private static MindBodyStarTest.ClassService.UserCredentials clientUserCredentials =
            new MindBodyStarTest.ClassService.UserCredentials() {Password = "apitest1234", Username = "Siteowner", SiteIDs = new int[] {-99}};

        private static MindBodyStarTest.ClientService.UserCredentials classUserCredentials =
            new MindBodyStarTest.ClientService.UserCredentials() { Password = "apitest1234", Username = "Siteowner", SiteIDs = new int[] { -99 } };

        public static List<Client> ClientList
        {
            get
            {
                var currentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                var clients = new List<Client>();
                clients.Add(new Client(){FirstName = "Kate", LastName = "Lybrand", BirthDate = currentDate.AddYears(-19), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Cait", LastName = "Guay", BirthDate = currentDate.AddYears(-39), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Katie", LastName = "Macedo", BirthDate = currentDate.AddYears(-59), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Katie", LastName = "Paterson", BirthDate = currentDate.AddYears(-26), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Katie", LastName = "Wiegand", BirthDate = currentDate.AddYears(-33), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Katie", LastName = "Poff", BirthDate = currentDate.AddYears(-52), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Katie", LastName = "Pia", BirthDate = currentDate.AddYears(-34), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Katie", LastName = "Lobaugh", BirthDate = currentDate.AddYears(-54), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Katie", LastName = "Soltys", BirthDate = currentDate.AddYears(-48), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Katie", LastName = "Pontes", BirthDate = currentDate.AddYears(-38), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Katie", LastName = "Posner", BirthDate = currentDate.AddYears(-28), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Katie", LastName = "Boucher", BirthDate = currentDate.AddYears(-28), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Kristie", LastName = "Lewellen", BirthDate = currentDate.AddYears(-29), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Christi", LastName = "Waldrep", BirthDate = currentDate.AddYears(-45), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Christy", LastName = "Matta", BirthDate = currentDate.AddYears(-37), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Christy", LastName = "Ripple", BirthDate = currentDate.AddYears(-28), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Christy", LastName = "Land", BirthDate = currentDate.AddYears(-54), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Christy", LastName = "Dibiase", BirthDate = currentDate.AddYears(-57), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Christy", LastName = "Grosch", BirthDate = currentDate.AddYears(-50), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Christy", LastName = "Sobota", BirthDate = currentDate.AddYears(-23), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Christy", LastName = "Mahone", BirthDate = currentDate.AddYears(-45), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Jim", LastName = "Holtzman", BirthDate = currentDate.AddYears(-34), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Jim", LastName = "Grippo", BirthDate = currentDate.AddYears(-50), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Jim", LastName = "Meiers", BirthDate = currentDate.AddYears(-24), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Jim", LastName = "Kyzer", BirthDate = currentDate.AddYears(-43), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Jim", LastName = "Dambrosio", BirthDate = currentDate.AddYears(-55), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Jim", LastName = "Bakley", BirthDate = currentDate.AddYears(-29), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Odell", LastName = "Holen", BirthDate = currentDate.AddYears(-37), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Rozanne", LastName = "Feagin", BirthDate = currentDate.AddYears(-30), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Laverne", LastName = "Drey", BirthDate = currentDate.AddYears(-43), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Eleanor", LastName = "Borgman", BirthDate = currentDate.AddYears(-32), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Sherell", LastName = "Maynez", BirthDate = currentDate.AddYears(-42), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Shaunte", LastName = "Marcinkowski", BirthDate = currentDate.AddYears(-44), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Keely", LastName = "Vicente", BirthDate = currentDate.AddYears(-32), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Santina", LastName = "Householder", BirthDate = currentDate.AddYears(-26), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Ward", LastName = "Hiser", BirthDate = currentDate.AddYears(-50), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Paul", LastName = "Grim", BirthDate = currentDate.AddYears(-28), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Vina", LastName = "Pedrick", BirthDate = currentDate.AddYears(-25), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Myung", LastName = "Conde", BirthDate = currentDate.AddYears(-28), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Carly", LastName = "Chand", BirthDate = currentDate.AddYears(-42), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Andree", LastName = "Gearing", BirthDate = currentDate.AddYears(-30), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Margo", LastName = "Wilcher", BirthDate = currentDate.AddYears(-38), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Margarito", LastName = "Dittmer", BirthDate = currentDate.AddYears(-35), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Leonardo", LastName = "Garden", BirthDate = currentDate.AddYears(-52), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Joselyn", LastName = "Maier", BirthDate = currentDate.AddYears(-51), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Palmira", LastName = "Pilger", BirthDate = currentDate.AddYears(-52), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Maurice", LastName = "Malatesta", BirthDate = currentDate.AddYears(-28), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Temeka", LastName = "Hawes", BirthDate = currentDate.AddYears(-41), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Lela", LastName = "Witten", BirthDate = currentDate.AddYears(-39), BirthDateSpecified = true });
                clients.Add(new Client() { FirstName = "Jaleesa", LastName = "Seeger", BirthDate = currentDate.AddYears(-45), BirthDateSpecified = true});

                return clients;
            }
        }
       
        public static void CreateClients(int numberOfClients)
        {
            var existingClients = 0;
            var numberOfClientsList = ClientList.Take(numberOfClients);
            foreach (var client in numberOfClientsList)
            {
                var result = _clientService.GetClients(new GetClientsRequest()
                {
                    SourceCredentials = clientSourceCredentials,
                    UserCredentials = classUserCredentials,
                    SearchText = String.Format("{0} {1}", client.FirstName, client.LastName)
                });
                foreach (var existingClient in result.Clients)
                {
                    var tempClient = ClientList.Select(x => x)
                        .FirstOrDefault(x => x.FirstName.Equals(existingClient.FirstName) &&
                                             x.LastName.Equals(existingClient.LastName) &&
                                             x.BirthDate.Equals(new DateTime(existingClient.BirthDate.Value.Year,
                                                 existingClient.BirthDate.Value.Month,
                                                 existingClient.BirthDate.Value.Day, 0, 0, 0)));

                    if (tempClient != null)
                    {
                        idList.Add(existingClient.ID);
                        numberOfClients--;
                        existingClients++;
                    }
                }
            }
            if (numberOfClients > 0)
            {
                var addResult = _clientService.AddOrUpdateClients(new AddOrUpdateClientsRequest()
                {
                    SourceCredentials = clientSourceCredentials,
                    UserCredentials = classUserCredentials,
                    Clients = ClientList.Skip(existingClients).Take(numberOfClients).ToArray()
                });
                if (addResult?.Clients != null)
                {
                    foreach (var client in addResult.Clients)
                    {
                        idList.Add(client.ID);
                    }
                }
            }
        }

        public static void CheckInClients(Class[] classes)
        {
            var totalNumberOfClients = idList.Count;
            int currentClass = 0;
            var classItem = classes[currentClass];

            // Sign Clients into Yesterday's Classes
            var maxCapacity = 0;
            var totalClientsInClass = 0;

            foreach (var id in idList)
            {
                if (totalClientsInClass == maxCapacity)
                {
                    currentClass++;
                    classItem = classes[currentClass];
                    Debug.Assert(classItem.MaxCapacity != null, "classItem.MaxCapacity != null");
                    maxCapacity = classItem.MaxCapacity.Value;
                    totalClientsInClass = 0;
                }
                //Add client to class
                while (classItem.IsCanceled && ( (currentClass+1) < classes.Length))
                {
                    currentClass++;
                    classItem = classes[currentClass];
                    Debug.Assert(classItem.MaxCapacity != null, "classItem.MaxCapacity != null");
                    maxCapacity = classItem.MaxCapacity.Value;
                    totalClientsInClass = 0;
                }
                    var result = _classService.AddClientsToClasses(new AddClientsToClassesRequest()
                    {
                        SourceCredentials = classSourceCredentials,
                        UserCredentials = clientUserCredentials,
                        ClassIDs = new int[] {classItem.ID.Value},
                        ClientIDs = new string[] {id},
                        RequirePayment = false
                    });
                    totalClientsInClass++;
                
            }
            
        }
    }
    
}

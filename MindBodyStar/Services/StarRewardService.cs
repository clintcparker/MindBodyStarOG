using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using WebApplication1.ClassService;

namespace WebApplication1.Services
{
    public class StarRewardService
    {
        public Class[] GetClasses(DateTime startDate, DateTime endDate)
        {

            var sourceCredentials = new ClassService.SourceCredentials()
            {
                SourceName = "",
                Password = "",
                SiteIDs = new int[] { -99 }
            };

            var userCredentials = new UserCredentials() { Password = "Siteowner", Username = "apitest1234", SiteIDs = new int[] { -99 } };
            
            var classService = new ClassService.ClassService();
            var results =
                classService.GetClasses(new GetClassesRequest()
                {
                    SourceCredentials = sourceCredentials,
                    StartDateTime = new DateTime(startDate.Year, startDate.Month, startDate.Day,  0,  0,  0), 
                    EndDateTime =   new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59)
                });
            return results.Classes;
        }

        public Dictionary<String, int> GetNames(Class[] classes)
        {

            var sourceCredentials = new ClassService.SourceCredentials()
            {
                SourceName = "",
                Password = "",
                SiteIDs = new int[] { -99 }
            };
            var userCredentials = new UserCredentials() { Password = "apitest1234", Username = "Siteowner", SiteIDs = new int[] { -99 } };

            var classService = new ClassService.ClassService();
            var names = new Dictionary<String, int>();
            foreach (var _class in classes)
            {
                var classID = _class.ID.Value;

                var results =
                    classService.GetClassVisits(new GetClassVisitsRequest()
                    {
                        ClassID = classID,
                        SourceCredentials = sourceCredentials,
                        UserCredentials = userCredentials
                    });

                if (results.Class?.Visits != null)
                {
                    foreach (var classVisit in results.Class.Visits)
                    {
                        
                        if ( classVisit.Client != null)
                        {
                            var client = classVisit.Client;
                            int numberOf = 0;
                            if (names.ContainsKey(client.FirstName))
                            {
                                names.TryGetValue(client.FirstName, out numberOf);
                                names.Remove(client.FirstName);
                            }
                            names.Add(client.FirstName, numberOf + 1);
                        }
                    }
                }
            }
            return names;
        }
    }
}
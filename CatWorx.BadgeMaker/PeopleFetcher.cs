using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json.Linq;

namespace CatWorx.BadgeMaker 
{
    class PeopleFetcher
    {
        public static List<Employee> GetEmployees ()
        {
            //returns a list of strings
          List<Employee> employees = new List<Employee>();
            while (true)
            {
            Console.WriteLine("Enter first name: (leave empty to exit)");
            string firstName = Console.ReadLine();
                if (firstName == "")
                 {
                  break;
                 }

                Console.Write("Enter last name: ");
                string lastName = Console.ReadLine();

                Console.Write("Enter ID: ");
                int id = Int32.Parse(Console.ReadLine());

                Console.Write("Enter Photo URL: ");
                string photoUrl = Console.ReadLine();

          Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
          employees.Add(currentEmployee);
          }
         return employees;
        }

        public static List<Employee> GetFromApi()
        {
            List<Employee> employees = new List<Employee>();
            using (WebClient client = new WebClient())
            {
                string response = client.DownloadString("https://randomuser.me/api/?results=10&nat=us&inc=name,id,picture");
                //checking to see if API call worked using Console.WriteLine
                Console.WriteLine(response);
                JObject json = JObject.Parse(response);
                foreach (JToken person in json.SelectToken("results"))
                {
                   //Console.WriteLine(person.SelectToken("name.first"));
                   Employee newEmp = new Employee (
                       person.SelectToken("name.first").ToString(),
                       person.SelectToken("name.last").ToString(),
                       Int32.Parse(person.SelectToken("id.value").ToString().Replace("-", "")),
                       person.SelectToken("picture.large").ToString()
                   );
                   employees.Add(newEmp);
                }
            }
            return employees;

        }
    }
}
using System;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
    class Program
    {
    

    static void Main(string[] args)
        {
          List<Employee> employees;
          Console.WriteLine("Welcome to Catworx Employee Badge Maker!\nDo you want to create badges manually or automatically based on our employee database?\nEnter m or M for manual creation - default is automatic.");
          string answer = Console.ReadLine();
          if (answer == "m" || answer == "M")
          {
            employees = PeopleFetcher.GetEmployees();
          }
          else {
            employees = PeopleFetcher.GetFromApi();
          }

          Util.PrintEmployees(employees);

          Util.MakeCSV(employees);
          Util.MakeBadges(employees);
        }
    }
}


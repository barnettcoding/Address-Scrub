using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;
using AddressScrub.Models;
using System.Net;
using System.Collections.Generic;

namespace AddressScrub
{
    class Program
    {

        public static async Task Main(string[] args)
        {
            string myJsonString = "";
            string filePath = @"C:\Dev\Tony\Actual Projects\AddressScrub\scrubs.json";
            string filePath2 = @"C:\Dev\Tony\Actual Projects\AddressScrub\outputFile";
            var newFile = "";
     
            List<string> info = new List<string>();
            List<string> clientids = new List<string>();
            info = File.ReadAllLines(filePath).ToList();
            foreach (string line in info)
            { myJsonString += line; }
            
            Root root = JsonSerializer.Deserialize<Root>(myJsonString) ?? new Root();
            
            
            
         if (Convert.ToBoolean(root.Options.RemoveDuplicates)) {
                removeDupes();
            };
            
         if (Convert.ToBoolean(root.Options.RemoveMinors)) {
                removeMinors();
            };
            
         if (Convert.ToBoolean(root.Options.RemoveSeniors)) {
                removeSeniors();
            };
            
         if (Convert.ToBoolean(root.Options.Address.Validate)) {
                AddressScrub();
            };

        }
         public static void AddressScrub() {
            //root.Data.ForEach(info => newFile += ($"{info.Id}|{info.Name.First}|{info.Name.Middle}|{info.Name.Last}|{info.Address?.Street}|{info.Address?.City}|{info.Address.State}|{info.Address.PostalCode}\n"));
            //File.WriteAllText(filePath2, newFile);
            // Console.WriteLine("dkdkdieieidkclskefo;eijdf");
           
        }
       

         
        

       
        private static void removeDupes()
        {
            //Console.WriteLine(root.Options);
        }

        private static void removeMinors()
        {
            string dateStr = "2005-04-20";
            DateTime date = DateTime.Parse(dateStr);
            Console.WriteLine(date);
            Console.WriteLine(DateTime.Now);
         //if (DateTime.TryParse(dateStr, out DateTime date)) { 
           // if (DateTime.Now.Subtract(date) < 18)
             //   {
               //     Console.WriteLine("You're a minor");
                //};
           // }
        }

        private static void removeSeniors()
        {
            string newEmail = "";
        }
    }
}

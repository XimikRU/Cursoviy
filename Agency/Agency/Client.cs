using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency
{
    [Serializable]
    public enum Sex { Female, Male, Unkn }

    [Serializable]
    public class Base
    {
        public Base(string name, int amount)
        {
            Name = name;
            LastIndex = 1;
            AmountClients = amount+1;
            Clients = new Client[AmountClients];
            IndexFemale = new int[AmountClients];
            IndexMale = new int[AmountClients];
            UsedNames = new string[AmountClients];
        }
        public string Name { get; set; }
        public Client[] Clients { get; set; }
        public int AmountClients { get; set; }
        public int LastIndex { get; set; }
        public int[] IndexFemale { get; set; }
        public int[] IndexMale { get; set; }
        public string[] UsedNames { get; set; }
    }

    [Serializable]
    public  class Client
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public int Growth { get; set; }
        public int Weight { get; set; }
        public string Contact { get; set; }
        public string Info { get; set; }
    }
}

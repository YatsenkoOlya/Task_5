using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    abstract class Garden:ILand
    {
        public string Address { get; set ; }
        public string GardenType { get => gardenType; set => gardenType = value; } 
        public Dictionary<string, int> Quantity { get => quantity; set => quantity = value; } 
        public int Number { get => number; set => number = value; } 

        private int number;
        private string gardenType;
        private Dictionary<string, int> quantity;

        protected Garden(string address, int number, string gardenType, Dictionary<string, int> quantity)
        {
            Address = address;
            this.number = number;
            this.gardenType = gardenType;
            this.quantity = quantity;
        }
        public double AvgScore()
        {
            Dictionary<string, int>.KeyCollection keyColl = Quantity.Keys;
            int Sum = 0;
            int Count = Quantity.Count;
            foreach (string s in keyColl)
            {
                Sum += Quantity[s];
            }
            double Avg = (double)Sum / Count;
            double Ravg = Math.Round(Avg,2);
            return Ravg;
        }
        public int LandWeave(Dictionary<int, int> allTrees) 
        {
            Dictionary<int, int>.KeyCollection keyColl = allTrees.Keys;
            foreach (int s in keyColl)
            {
                if (s==Number) { 
                    return allTrees[s]; 
                }
            }
            return 0;

        }
        abstract public int LandValue(Dictionary<string, int> cost);
    }
}

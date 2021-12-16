using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class AppleGarden : Garden
    {
        String ownersName; 
        int newTrees; 

        public AppleGarden(string address, int number, string gardenType, Dictionary<string, int> quantity,string ownersName, int newTrees) :base (address, number, gardenType, quantity)
        {
            this.ownersName = ownersName;
            this.newTrees = newTrees;
        }

        public int NewTrees { 
            get => newTrees; 
            set => newTrees = value; 
        }
        public string OwnersName { 
            get => ownersName; 
            set => ownersName = value; 
        }
        public override int LandValue(Dictionary<string, int> cost)
        {
            Dictionary<String, int>.KeyCollection keyColl = cost.Keys;
            foreach (String s in keyColl)
            {
                if (s == GardenType) { 
                    return cost[s]; 
                }  
            }
            return 0;
        }
        public double EmpPercentage(int treeT) 
        {
            return Math.Round((double)NewTrees / treeT * 100); 
        }

        //public override string ToString()
        //{
          //  return "Name: " + Address + "; Group: " + Group + "; Department: " + Department + "; Grades: " + Grades["1s"]  + "; Curators name: " + OwnersName + "; Additional hours: " + AdditionalHours;
            //;
        //}
    }
}

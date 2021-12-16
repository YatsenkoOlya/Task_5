using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class MixedGarden : Garden 
    {
        int berries; 
        int square;

        public MixedGarden(string address, int number, string gardenType, Dictionary<string, int> quantity,int berries, int square) : base(address, number, gardenType, quantity)
        {
            this.berries = berries;
            this.square = square;
        }

        public int Berries { get => berries; set => berries = value; }
        public int Square { get => square; set => square = value; }

        public override int LandValue(Dictionary<string, int> cost)
        {
            Dictionary<String, int>.KeyCollection keyColl = cost.Keys;
            foreach (String s in keyColl)
            {
                if (s == GardenType) { return cost[s]; }
            }
            return 0;
        }
        /*public int SrchPlaceOnTourments(String tourment)
        {
            Dictionary<String, int>.KeyCollection keyColl = tournmentRes.Keys;
            foreach (string s in keyColl)
            {
                if (s == tourment) { return tournmentRes[s]; }
            }
            return 0;
        }*/
        public int LastT()
        {
            return Berries;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    interface ILand
    {
        string Address { get; set; } 
        int LandWeave(Dictionary<int, int> allTrees); 
        int LandValue(Dictionary<String,int> cost); 

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGOPPuke3
{
    internal class CheckIfSuccesful
    {

        public static bool IsSuccessful(int maxValue)
        {
            Random rand = new Random();

            return rand.Next(0, maxValue) == 2;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGOPPuke3
{
    internal class Player
    {
       public bool isDead { get; private set; }

       public void setDead()
       {
           isDead = true;
       }
    }
}

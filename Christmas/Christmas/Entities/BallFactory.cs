using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Christmas.Entities
{
    public class BallFactory
    {
        public Ball CreateNew() //CreateNew fuggveny letrehozasa
        {
            return new Ball(); //visszatérési érték
        }
    }
}

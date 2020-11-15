using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Christmas.Abstractions
{
    public interface IToyFactory
    {
        Toy CreateNew();

        //interfeszekben megadott elemeknek mindig publikusnak kell lennie 'PUBLIC'
        //'CreateNew' fuggveny, visszatérési értéke Toy típusú
    }
}

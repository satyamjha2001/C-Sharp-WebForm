using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1FirstProgram
{
    class Car
    {
        String Color = "Red";
        static void Main()
        {
            Car myObj1 = new Car();
            Car myObj2 = new Car();

            Console.WriteLine(myObj1.Color);
            Console.WriteLine(myObj2.Color);
        }
    }
}

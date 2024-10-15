using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw1._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte a, b;
            try
            {
                string x = Console.ReadLine();
                a = Convert.ToByte(x);
                string y = Console.ReadLine();
                b = Convert.ToByte(y);
                Console.WriteLine($"{a / b}");
            }
            catch
            {
                Console.WriteLine("Некорректный ввод!");
            }
        }
    }
}

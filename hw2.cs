using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2
{
    internal class Program
    {
        /// <summary> Находит простые делители числа
        /// </summary>
        static string PrimeFactors(int a)
        {
            string ans = "";
            if (a <= 1)
            {
                ans = "Некорректный ввод";
            }
            else
            {
                while (a != 1)
                {
                    int b = a;
                    for (int i = 2; i <= a; i++)
                    {
                        if (b % i == 0)
                        {
                            b /= i;
                            ans += Convert.ToString(i);
                            ans += " ";
                            break;
                        }
                    }
                    a = b;
                }
            }
            return ans;
        }
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            Console.WriteLine(PrimeFactors(Convert.ToInt32(a)));
        }
    }
}

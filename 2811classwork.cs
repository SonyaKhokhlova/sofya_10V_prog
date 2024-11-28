using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2811
{
    internal class Program
    {
        public class Fraction
        {
            // Числитель дроби
            public int Numerator { get; set; }
            // Знаменатель дроби
            public int Denominator { get; set; }

            public Fraction(int numerator, int denominator)
            {
                Numerator = numerator;
                Denominator = denominator;
            }

            public override string ToString()
            {
                return $"{Numerator}/{Denominator}";
            }

            public static Fraction operator *(Fraction a, Fraction b)
            {
                return new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
            }

            public static Fraction operator /(Fraction a, Fraction b)
            {
                return new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
            }
        }
        static void Main(string[] args)
        {
            Fraction f1 = new Fraction(1, 5);
            Fraction f2 = new Fraction(2, 3);
            Console.WriteLine(f1 * f2);
            Console.WriteLine(f1 / f2);
        }
    }
}

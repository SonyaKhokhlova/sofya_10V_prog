using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw10
{
    internal class Program
    {
        public class MyClass<T>
        {
            public T Value { get; set; }
            public static void PrintArray(T[] array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Console.WriteLine(array[i]);
                }
            }

            public static int FindOccurrencesCount(T[] array, T item)
            {
                int counter = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    if (item.Equals(array[i]))
                    {
                        counter++;
                    }
                }
                return counter;
            }

            public static List<T> Reverse(List<T> list)
            {
                List<T> ans = new List<T>();
                for (int i = list.Count - 1; i <= 0; i--)
                {
                    ans.Add(list[i]);
                }
                return ans;
            }
        }

        static void Main(string[] args)
        {
        }
    }
}

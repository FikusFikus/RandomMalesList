using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MalesList
{
    class Program
    {
        class MyArray
        {
            public string[] Array { get; set; }

            public MyArray()
            {
                this.Array = Array;
            }
            public string[] ReadFromFile(string filename)
            {
                using (StreamReader srNames = new StreamReader(filename, System.Text.Encoding.UTF8))
                {
                    int size = Convert.ToInt32(srNames.ReadLine());
                    string[] array = new string[size];
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = srNames.ReadLine();
                    }
                    srNames.Close();
                    return array;
                }
            }

            public void WriteToFile(string filename)
            {
                StreamWriter sw = new StreamWriter(filename);
                sw.WriteLine(Array.Length);
                for (int i = 0; i < Array.Length; i++)
                {
                    sw.WriteLine(Array[i]);
                }
                sw.Close();
            }

            public string[] CreatePhoneNumArray()
                {
                    string countyCode = "+7";

                    for (int i = 0; i < Array.Length; i++)
                    {
                        System.Threading.Thread.Sleep(25);
                        Random rnd = new Random();
                        string region = Convert.ToString(rnd.Next(900, 999));
                        string number = Convert.ToString(rnd.Next(100, 999)) + "-" + Convert.ToString(rnd.Next(10, 99)) + "-" + Convert.ToString(rnd.Next(10, 99));
                        Array[i] = $"{countyCode} ({region}) {number}";
                    }
                return Array;
                }



            static void Main(string[] args)
            {
                MyArray names = new MyArray();
                names.Array = names.ReadFromFile("maleNames.txt");

                MyArray surnames = new MyArray();
                surnames.Array = surnames.ReadFromFile("maleSurnames.txt");

                MyArray phones = new MyArray();
                phones.Array = new string[1000];
                phones.Array = phones.CreatePhoneNumArray();

                Random rnd = new Random();

                MyArray randomMales = new MyArray();

                randomMales.Array = new string[1000];

                for (int i = 0; i < randomMales.Array.Length; i++)
                {
                    randomMales.Array[i] = $"{i + 1}. {names.Array[rnd.Next(0, names.Array.Length)]} {surnames.Array[rnd.Next(0, names.Array.Length)]}, телефон: {phones.Array[i]} ";
                    Console.WriteLine(randomMales.Array[i]);
                }


                randomMales.WriteToFile("malesList1.txt");

                Console.ReadLine();
            }
        }
    }
}

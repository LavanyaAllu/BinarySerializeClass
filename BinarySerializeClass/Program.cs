using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace BinarySerializeClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the DateOfBirth in the following format 21 nov 1999");
            string s = Console.ReadLine();

            DateTime dob = Convert.ToDateTime(s);   
            DateTime PresentYear = DateTime.Now;
            TimeSpan ts = PresentYear - dob;
            DateTime Age = DateTime.MinValue.AddDays(ts.Days);
            
            FileStream fs = new FileStream(@"CalulateAge.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, Age.Year - 1);

            fs.Seek(0, SeekOrigin.Begin);

            int res = (int)bf.Deserialize(fs); //unboxing
            Console.WriteLine("Age is: " + res);
            Console.WriteLine(PresentYear);
        }
    }
}

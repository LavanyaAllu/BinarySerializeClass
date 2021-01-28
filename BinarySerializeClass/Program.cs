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
    [Serializable]
    class DobClass : IDeserializationCallback
    {
        public int BirthYear { get; set; }
        public int PresentYear { get; set; }


        public void OnDeserialization(object sender)
        {
            Console.WriteLine($"The Present Age is:{PresentYear - BirthYear}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DobClass d = new DobClass();
            d.PresentYear = DateTime.Now.Year;
            Console.WriteLine(DateTime.Now);
            Console.WriteLine("Enter Your Year of Birth:");
            d.BirthYear = Convert.ToInt32(Console.ReadLine());
            FileStream fs = new FileStream(@"E:\DateOfBirth.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(fs, d);
            fs.Seek(0, SeekOrigin.Begin);
            DobClass d1 = (DobClass)b.Deserialize(fs);
        }
    }
}

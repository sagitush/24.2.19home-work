using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _24._2._19_homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Car[] cars = {new Car("mazda", 3, 2011, "blue", 5332, 5),
            new Car("nissan",6,2000,"red",2332,6),new Car("ford",7,2008,"gray",2556,7)};
            //Car mazda = new Car("mazda", 3, 2011, "blue", 5332, 5);
            //Console.WriteLine(mazda);
            XmlSerializer myxmlSerializer = new XmlSerializer(typeof (Car[]));
            using (Stream file = new FileStream(@"c:\temp\xmlfile.xml", FileMode.Create))
            {
              myxmlSerializer.Serialize(file, cars);
            }
            PrintArray(cars);
            Car [] cars2;
            //XmlSerializer myxmlSerializer = new XmlSerializer(typeof(Car[]));
            using (Stream file = new FileStream(@"c:\temp\xmlfile.xml", FileMode.Open))
            {
                cars2 = myxmlSerializer.Deserialize(file) as Car[];
            }
            PrintArray(cars2);
        }
        static void PrintArray(Car [] c)
        {
            foreach  (Car car in c)
            {
                Console.WriteLine(car);
            }
        }
    }
}

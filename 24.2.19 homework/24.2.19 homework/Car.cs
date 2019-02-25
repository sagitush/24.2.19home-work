using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _24._2._19_homework
{
    public class Car
    {
        public string Model { get; set; }
        public int Brand { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        private int codan;
        protected int numberOfSeats;
        

        public Car()
        {

        }
        public Car(string FileName)
        {
            Car car;
            XmlSerializer myxmlSerializer = new XmlSerializer(typeof(Car));
            using (Stream file = new FileStream($@"c:\{FileName}\xmlfile.xml", FileMode.Open))
            {
                car = myxmlSerializer.Deserialize(file) as Car;
            }
            this.Model = car.Model;
            this.Brand = car.Brand;
            this.Year = car.Year;
            this.Color = car.Color;
        }

        public Car(string model, int brand, int year, string color, int codan, int numberOfSeats)
        {
            Model = model;
            Brand = brand;
            Year = year;
            Color = color;
            this.codan = codan;
            this.numberOfSeats = numberOfSeats;
        }
        public int Codan
        {
            get
            {
                return this.codan;
            }
        }
        public int NumberOfSeats
        {
            get
            {
                return this.numberOfSeats;
            }
        }
        protected void ChangeNumberOfSeats(int n)
        {
            this.numberOfSeats = n;
        }
        public static void SerializeACar(string fileName,Car car)
        {
            XmlSerializer myxmlSerializer = new XmlSerializer(typeof(Car));
            using (Stream file = new FileStream($@"c:\{fileName}\xmlfile.xml", FileMode.Create))
            {
                myxmlSerializer.Serialize(file, car);
            }
        }
        public static void SerializeACarArray(string fileName, Car[] cars)
        {
            XmlSerializer myxmlSerializer = new XmlSerializer(typeof(Car[]));
            using (Stream file = new FileStream($@"c:\{fileName}\xmlfile.xml", FileMode.Create))
            {
                myxmlSerializer.Serialize(file, cars);
            }
        }
        public static Car DeserializeACar(string fileName)
        {
            Car car;
            XmlSerializer myxmlSerializer = new XmlSerializer(typeof(Car));
            using (Stream file = new FileStream($@"c:\{fileName}\xmlfile.xml", FileMode.Open))
            {
                car = myxmlSerializer.Deserialize(file) as Car;
            }
            return car;
        }
        public static Car[] DeserializeACarArray(string fileName)
        {

            Car[] cars;
            XmlSerializer myxmlSerializer = new XmlSerializer(typeof(Car[]));
            using (Stream file = new FileStream($@"c:\{fileName}\xmlfile.xml", FileMode.Open))
            {
                cars = myxmlSerializer.Deserialize(file) as Car[];
            }
            return cars;
        }
        public bool CarCompare(string fileName)
        {
            Car car;
            XmlSerializer myxmlSerializer = new XmlSerializer(typeof(Car));
            using (Stream file = new FileStream($@"c:\{fileName}\xmlfile.xml", FileMode.Open))
            {
                car = myxmlSerializer.Deserialize(file) as Car;
            }
            if (this.Model == car.Model&& this.Brand == car.Brand&& this.Year == car.Year&& this.Color == car.Color)
            {
                return true;
                       
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"Car model:{this.Model,5} Brand:{this.Brand,2} Year:{this.Year,5} Color:{this.Color,5} codan:{this.codan} number of seats:{this.numberOfSeats}";
        }
    }
}

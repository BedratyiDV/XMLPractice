using System.Drawing;
using System.Xml;
using System.Xml.Linq;

namespace XMLPtactice
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            Car car1 = new Car( "Ford Focus", 17000, "AI2012HB");
            cars.Add(car1);
            Car car2 = new Car( "Audi TT",20000, "AH3333BK");
            cars.Add(car2);
            Car car3 = new Car( "Toyota RAV-4", 30000,"AX5033VT");
            cars.Add(car3);
            Car car4 = new Car("Honda Civic", 18000, "AA4444BB");
            cars.Add(car4);

            foreach (Car car in cars)
            { 
            Console.WriteLine($" {car.Name},  {car.Price},  {car.Number}"); 
            }

             void SaveCollectionInXmlFile(IEnumerable<Car> cars)
            {
                var carCollection = new XDocument();
                var rootElement = new XElement("carShop");

                foreach (var car in cars)

                {
                    var aNewCar = new XElement("ANewCar");
                    var aNewCarAttr = new XAttribute("Number", car.Number);
                    var aNewCarName = new XElement("Name", car.Name);
                    var aNewCarPrice = new XElement("Price", car.Price);
                    aNewCar.Add(aNewCarAttr);
                    aNewCar.Add(aNewCarName);
                    aNewCar.Add(aNewCarPrice);
                    rootElement.Add(aNewCar);
                }
                carCollection.Add(rootElement);
                carCollection.Save("C:\\Users\\denis\\source\\Hillel\\Pro\\XMLPtactice\\CarCollection.xml");
            }

            void SetNewCarPriceByNumber(string carNumber, int newPrice)
            {
                var carCollection = XDocument.Load("C:\\Users\\denis\\source\\Hillel\\Pro\\XMLPtactice\\CarCollection.xml");
                var carToUpdate = from car in carCollection.Descendants("ANewCar")
                                  where (string)car.Attribute("Number") == carNumber
                                  select car;


                if (carToUpdate.Any())
                {
                   carToUpdate.Elements("Price").FirstOrDefault().Value = newPrice.ToString();
                }
                else
                {
                    Console.WriteLine($"Car with number {carNumber} is not found.");
                }
                carCollection.Save("C:\\Users\\denis\\source\\Hillel\\Pro\\XMLPtactice\\CarCollection.xml");
            }
            //SaveCollectionInXmlFile (cars);
            //SetNewCarPriceByNumber("AX5033VT", 29500);
            SetNewCarPriceByNumber("AA4444BB", 34500);
        }
            }
}
        

    
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace XMLPtactice
{
    internal class Car
    {
        private string _name;
        private int _price;
        private string _number;

        public Car(string name, int price, string number)
        {
            _name = name;
            _price = price;
            _number = number;
        }
        public string Name
        {
            get => _name;
        }
        public int Price
        {
            get => _price;
            set => _price = value;
        }
        public string Number
        {
            get => _number;
        }

    }
}

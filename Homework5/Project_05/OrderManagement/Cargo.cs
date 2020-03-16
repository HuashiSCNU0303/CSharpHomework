using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement
{
    class Cargo
    {
        public int cargoPrice { get; }
        public string cargoName { get; }
        public Cargo(string name, int price)
        {
            cargoName = name;
            cargoPrice = price;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement_WinForm
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigments_01
{
    public class StoreItems : Item
    {
        public int Price;
        public StoreItems(string name, string stat, int statBonus, string description, int atdf, int price) : base(name, stat, statBonus, description, atdf, price)
        {
            Price = price;
        }
    }
}

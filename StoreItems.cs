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
        public bool isPurchaseCompleted;
        public StoreItems(bool isequip, string name, string stat, int statBonus, string description, int atdf, int price, bool ispurchasecompleted) : base(isequip, name, stat, statBonus, description, atdf)
        {
            Price = price;
            isPurchaseCompleted = ispurchasecompleted;
        }
    }
}

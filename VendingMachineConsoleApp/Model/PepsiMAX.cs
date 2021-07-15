using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineConsoleApp.Model
{
    public class PepsiMAX : Item
    {
        public PepsiMAX(int allId, int price)
        {
            AllId = allId;
            Price = price;
        }
        public override string Examine()
        {
            return $"PepsiMAX: Cost {Price}KR";
        }

        public override string Use()
        {
            return "Enjoy your beverage";
        }
    }
}

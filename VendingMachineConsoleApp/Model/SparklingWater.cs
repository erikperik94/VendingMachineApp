using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineConsoleApp.Model
{
    public class SparklingWater : Item
    {
        public SparklingWater(int allId, int price)
        {
            AllId = allId;
            Price = price;
        }
        public override string Examine()
        {
            return $"Sparkling Water: Cost {Price}KR";
        }

        public override string Use()
        {
            return "Enjoy your beverage";
        }
    }
}

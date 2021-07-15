using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineConsoleApp.Model
{
    public class Peanuts : Item
    {
        public Peanuts(int allId, int price)
        {
            AllId = allId;
            Price = price;
        }
        public override string Examine()
        {
            return $"Peanuts: Cost {Price}KR";
        }

        public override string Use()
        {
            return "Enjoy your peanuts";
        }
    }
}

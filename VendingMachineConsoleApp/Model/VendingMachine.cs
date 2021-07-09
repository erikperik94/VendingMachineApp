using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineConsoleApp.Model
{
    public class VendingMachine : IVending
    {
        public readonly int[] moneyChange= {1,5,10,20,50,100,500,1000};
        private List<Item> InStoreItems = new List<Item>();
        private List<Item> purchasedItems = new List<Item>();
        private int moneyPool = 0;

        public VendingMachine()
        {
            StoreItems();
        }
        public int UserMoney()
        {
            return moneyPool;
        }

        public bool InsertMoney(int deposit)
        {
            foreach (int money in moneyChange)
            {
                if(money == deposit)
                {
                    moneyPool += deposit;
                    Console.WriteLine("\nYour total deposit is " + moneyPool);

                    return true;
                }
            }
            return false;
        }
        public bool Purchase(int allId)
        {
            foreach (Item item in InStoreItems)
            {
                if(item.AllId == allId && DepositIsEnough(item.Price))
                {
                    purchasedItems.Add(item);
                    moneyPool -= item.Price;
                    return true;
                }
            }
            return false;
        }
        public List<Item> showAll()
        {
            return purchasedItems;
        }
        public string EndTransaction()
        {
            foreach (int value in moneyChange)
            {
                if(moneyPool >= moneyChange[value] && moneyPool % moneyChange[value] == 0)
                {
                    return $"Change {moneyPool}KR";
                }
                else if(moneyPool >= moneyChange[value] && moneyPool % moneyChange[value] != 0)
                {
                    return $"Change {moneyPool}KR";
                }
            }
            return null;
        }
        public bool DepositIsEnough(int itemPrice)
        {
            bool result = moneyPool >= itemPrice;
            return result;
        }
        public void GiveUsageInstructions(List<Item> collatedItems)
        {
            foreach (Item item in collatedItems)
            {
                Console.WriteLine(item.Use());
            }
        }
        public List<Item> CollatedItems()
        {
            List<int> itemAllId = new List<int>();
            List<Item> collatedItems = new List<Item>();

            foreach (Item item in purchasedItems)
            {
                if(!itemAllId.Contains(item.AllId))
                {
                    collatedItems.Add(item);
                    itemAllId.Add(item.AllId);
                }
            }
            return collatedItems;
        }
        public int ShowTotalDeposit()
        {
            return moneyPool;
        }
        public void ClearVariables()
        {
            moneyPool = 0;
            purchasedItems.Clear();
        }
        public void StoreItems()
        {
            InStoreItems.Add(new SparklingWater(1, 5));
            InStoreItems.Add(new PepsiMAX(2, 10));
            InStoreItems.Add(new Peanuts(3, 15));
        }
    }
}

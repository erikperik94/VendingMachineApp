using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineConsoleApp.Model
{
    public class VendingMachine : IVending
    {
        public readonly int[] moneyChange= {1000,500,100,50,20,10,5,1};
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
        
        
        
        /*public string EndTransaction()
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
        }*/
        public Dictionary<int,int> EndTransaction()
        {
            Dictionary<int, int> changeMoney = new Dictionary<int, int>();
            int[] Amount = new int[moneyChange.Length];
            int Change = moneyPool;
            int Value;
            
            try
            {
                for (int i = 0; i < moneyChange.Length; i++)
                {
                    if (Change >= moneyChange[i])
                    {
                        Value = Change / moneyChange[i];
                        Change = Change - (Value * moneyChange[i]);
                        Amount[i] = Value;
                    }
                    else
                    {
                        Amount[i] = 0;
                    }
                    changeMoney.Add(moneyChange[i], Amount[i]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            return changeMoney;
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

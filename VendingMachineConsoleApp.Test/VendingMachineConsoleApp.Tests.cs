using System;
using Xunit;
using VendingMachineConsoleApp.Model;

namespace VendingMachineConsoleApp.Test
{
    public class VendingMachineTests
    {
        [Fact]
        public void SparklingWaterTest()
        {
            //Arrange
            int AllId = 1;
            int Price = 5;
            string Examine = "Sparkling Water: Cost 5KR";
            string Use = "Enjoy your beverage";
            //Act
            SparklingWater beverage = new SparklingWater(1, 5);
            //Assert
            Assert.Equal(AllId, beverage.AllId);
            Assert.Equal(Price, beverage.Price);
            Assert.Equal(Examine, beverage.Examine());
            Assert.Equal(Use, beverage.Use());
        }
        [Fact]
        public void PepsiMAXTest()
        {
            //Arrange
            int AllId = 2;
            int Price = 10; 
            string Examine = $"PepsiMAX: Cost {Price}KR";
            string Use = "Enjoy your beverage";
            //Act
            PepsiMAX beverage = new PepsiMAX(2,10);
            //Assert
            Assert.Equal(AllId, beverage.AllId);
            Assert.Equal(Price, beverage.Price);
            Assert.Equal(Examine, beverage.Examine());
            Assert.Equal(Use, beverage.Use());
        }
        [Fact]
        public void PeanutsTest()
        {
            //Arrange
            int AllId = 3;
            int Price = 15;
            string Examine = "Peanuts: Cost 15KR";
            string Use = "Enjoy your peanuts";
            //Act
            Peanuts beverage = new Peanuts(3, 15);
            //Assert
            Assert.Equal(AllId, beverage.AllId);
            Assert.Equal(Price, beverage.Price);
            Assert.Equal(Examine, beverage.Examine());
            Assert.Equal(Use, beverage.Use());
        }
        [Fact]
        public void VendingMachineInsertTest()
        {
            //Arrange
            int value = 31;
            //Act
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.InsertMoney(1);
            vendingMachine.InsertMoney(10);
            vendingMachine.InsertMoney(20);
            //Assert
            Assert.Equal(value, vendingMachine.ShowTotalDeposit());
        }
        [Fact]
        public void VendingMachinePurchaseTest()
        {
            //Arrange
            int item_allId_1 = 1;
            int item_price_1 = 5;
            int item_allId_2 = 2;
            int item_price_2 = 10;
            int item_allId_3 = 3;
            int item_price_3 = 15;
            //Act
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.InsertMoney(50);
            vendingMachine.Purchase(1);
            vendingMachine.Purchase(2);
            vendingMachine.Purchase(3);
            //Assert
            //Check all products/prices if match
            Assert.Equal(item_allId_1,vendingMachine.showAll()[0].AllId);
            Assert.Equal(item_price_1,vendingMachine.showAll()[0].Price);
            Assert.Equal(item_allId_2, vendingMachine.showAll()[1].AllId);
            Assert.Equal(item_price_2, vendingMachine.showAll()[1].Price);
            Assert.Equal(item_allId_3, vendingMachine.showAll()[2].AllId);
            Assert.Equal(item_price_3, vendingMachine.showAll()[2].Price);


        }
        [Fact]
        public void VendingMachineEndTransactionTest()
        {
            //Arrange
            string result = "Change 35KR";
            //Act
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.InsertMoney(50);
            vendingMachine.Purchase(3);
            //Assert
            Assert.Equal(result, vendingMachine.EndTransaction());
        }
        [Fact]
        public void VendingMachineClearTest()
        {
            //Arrange
            int deposit = 0;
            //Act
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.InsertMoney(50);
            vendingMachine.ClearVariables();
            //Assert
            //------Reset to Zero
            Assert.Equal(deposit, vendingMachine.ShowTotalDeposit());
        }
        [Fact]
        public void VendingMachineDepositTest()
        {
            //Arrange
            bool GivesTrue = true;
            bool GivesFalse = false;
            //Act
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.InsertMoney(10);
            vendingMachine.Purchase(1);
            //Assert
            //------Costs 5
            Assert.Equal(GivesTrue, vendingMachine.DepositIsEnough(vendingMachine.showAll()[0].Price));
            //------Costs 10
            Assert.Equal(GivesFalse, vendingMachine.Purchase(2));

        }
    }
}

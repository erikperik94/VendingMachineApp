using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineConsoleApp.Model
{
    public interface IVending
    {
        bool InsertMoney(int deposit);
        bool Purchase(int allId);
        public List<Item> showAll();
        string EndTransaction();

    }
}

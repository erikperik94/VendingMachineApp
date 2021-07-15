using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineConsoleApp.Model
{
    public abstract class Item
    {
        public int AllId { get; set; }
        public int Price { get; set; }

        public abstract string Examine();
        public abstract string Use();

    }
}

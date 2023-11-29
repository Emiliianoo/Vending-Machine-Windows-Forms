using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaquinaExpendedora;

namespace MaquinaExpendedora.Methods
{
    internal static class MainControl
    {
        private static bool IDLocked = false;
        private static double _totalAmountDeposited = 0;
        public static string ID { get; private set; } = "";
        public static double  TotalAmountDeposited
        {
            get => _totalAmountDeposited;
            set
            {
                _totalAmountDeposited = value;
                Console.WriteLine(_totalAmountDeposited);
            }
        }
        private static Dictionary<string, (double Price, int Amount, string Name)> _itemsInfo = new Dictionary<string, (double, int, string)>
        {
            { "1A", (21.00, 5, "Coca Cola") },
            { "2A", (20.00, 2, "Sprite") },
            { "3A", (20.00, 1, "Pepsi") },
            { "1B", (23.00, 3, "DrPepper") },
            { "2B", (22.00, 3, "Ruffles") },
            { "3B", (23.00, 2, "Sabritas") },
            { "1C", (25.00, 1, "Gansito") },
            { "2C", (24.00, 5, "Barritas") },
            { "3C", (25.00, 3, "Chocorroles") }
        };  

        public static double getItemPrice()
        {
            return _itemsInfo[ID].Price;
        }

        public static string getItemName()
        {
            return _itemsInfo[ID].Name;
        }

        public static int getItemAmount()
        {
            return _itemsInfo[ID].Amount;
        }

        public static bool PurchaseOnGoing()
        {
            return IDLocked;
        }

        public static void ToggleIDLock()
        {
            IDLocked = !IDLocked;
        }

        public static void AddCashAmount(double amount)
        {
            TotalAmountDeposited += amount;
            Console.WriteLine(TotalAmountDeposited);
        }

        public static void ModifyID(string btnChar)
        {
            if (IDLocked || ID.Length == 2) return;

            ID += btnChar;
        }

        public static void ClearID()
        {
            if (IDLocked) return;

            ID = "";
        }

        public static bool IDExists()
        {
            return _itemsInfo.ContainsKey(ID);
        }

        public static void DispenseItem()
        {
            if (!IDExists()) return;

            var item = _itemsInfo[ID];
            if (item.Amount == 0) return;

            item.Amount--;
            _itemsInfo[ID] = item;

        }

        public static void SubtractCashAmount(double amount)
        {
            TotalAmountDeposited -= amount;
            Console.WriteLine(TotalAmountDeposited);
        }

    }
}

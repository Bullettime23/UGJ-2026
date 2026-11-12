using CodeBase.InventorySystem;
using UnityEngine;
namespace CodeBase.InteractionSystem {
    public class Inventory : IInventory
    {

        private const string PREFS_KEY = "keysAmount";
        public int CurrentAmount { get; private set; }

        public Inventory()
        {
            CurrentAmount = PlayerPrefs.GetInt(PREFS_KEY, 0);
        }

        public void PutKeyToInventory()
        {
            CurrentAmount++;
            PlayerPrefs.SetInt(PREFS_KEY, CurrentAmount);
        }
        public bool DragKeysFromInventory(int amount)
        {
            if (amount > CurrentAmount)
            {
                return false;
            }
                
            CurrentAmount -= amount;
            PlayerPrefs.SetInt(PREFS_KEY, CurrentAmount);
            return true;
        }
    }
}
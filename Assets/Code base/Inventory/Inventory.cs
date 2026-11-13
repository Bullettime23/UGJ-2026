using CodeBase.InventorySystem;
using System;
using UnityEngine;
namespace CodeBase.InteractionSystem {
    public class Inventory : IInventory
    {
        
        private const string PREFS_KEY = "keysAmount";

        public event EventHandler<int> OnKeysAmountChange;

        public int CurrentAmount { get; private set; }

        public Inventory()
        {
            CurrentAmount = PlayerPrefs.GetInt(PREFS_KEY, 0);
        }

        public void PutKeyToInventory()
        {
            CurrentAmount++;
            OnKeysAmountChange(this, CurrentAmount);

            PlayerPrefs.SetInt(PREFS_KEY, CurrentAmount);
        }
        public bool DragKeysFromInventory(int amount)
        {
            if (amount > CurrentAmount)
            {
                return false;
            }
                
            CurrentAmount -= amount;
            OnKeysAmountChange(this, CurrentAmount);

            PlayerPrefs.SetInt(PREFS_KEY, CurrentAmount);
            return true;
        }

        public void Reset()
        {
            CurrentAmount = 0;
            OnKeysAmountChange(this, CurrentAmount);

            PlayerPrefs.SetInt(PREFS_KEY, CurrentAmount);
        }
    }
}
using LevGamekit.Infrastructure.ServiceLocator;
using System;

namespace CodeBase.InventorySystem {
    public interface IInventory : IService
    {
        event EventHandler<int> OnKeysAmountChange;
        int CurrentAmount { get; }

        void PutKeyToInventory();

        bool DragKeysFromInventory(int amount);


        void Reset();
    }
}
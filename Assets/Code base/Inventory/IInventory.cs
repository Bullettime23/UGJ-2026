using LevGamekit.Infrastructure.ServiceLocator;

namespace CodeBase.InventorySystem {
    public interface IInventory : IService
    {
        int CurrentAmount { get; }
        void PutKeyToInventory();

        bool DragKeysFromInventory(int amount);

        void Reset();
    }
}
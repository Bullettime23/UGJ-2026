using LevGamekit.Infrastructure.ServiceLocator;

namespace CodeBase.InventorySystem {
    public interface IInventory : IService
    {
        void PutKeyToInventory();

        bool DragKeysFromInventory(int amount);
    }
}
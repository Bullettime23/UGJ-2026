using CodeBase.InventorySystem;
using LevGamekit.Infrastructure.ServiceLocator;
using UnityEngine;

namespace CodeBase.InteractionSystem {
    public class KeyPickable : MonoBehaviour, IInteractible
    {
        [SerializeField] private string m_Description = "The key from the main exit";

        public string GetDescrition()
        {
            return m_Description;
        }

        public void Interact()
        {
            Debug.Log("Add key to inventory");
            AllServices.Container.Single<IInventory>().PutKeyToInventory();

            //Play sound
            gameObject.SetActive(false);
        }
    }
}
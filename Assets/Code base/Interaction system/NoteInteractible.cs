using LevGamekit.Infrastructure.ServiceLocator;
using UnityEngine;

namespace CodeBase.InteractionSystem {
    public class NoteInteractible : MonoBehaviour, IInteractible
    {
        [SerializeField] private string m_Description = "A suspecious note";
        [SerializeField] private string m_NoteText = "You've been kidnapped! My lucky number is 7. So I'll give you 7 attempts to escape!";

        private IUINote m_NoteUI;

        private void Start()
        {
            m_NoteUI = AllServices.Container.Single<IUINote>();
        }
        public string GetDescription()
        {
            return m_Description;
        }

        public void Interact()
        {
            m_NoteUI.ShowMessage(m_NoteText);
        }
    }
}
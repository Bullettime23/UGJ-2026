using CodeBase.InteractionSystem;
using LevGamekit.Infrastructure.SceneLoader;
using LevGamekit.Infrastructure.ServiceLocator;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.InteractionSystem {
    public class DoorInteractible : MonoBehaviour, IInteractible
    {
        public UnityEvent OnInteract;

        [SerializeField] private string m_Description;
        [SerializeField] private string m_LoadSceneName;

        private ISceneLoader m_SceneLoader;

        private void Start()
        {
            m_SceneLoader = AllServices.Container.Single<ISceneLoader>();
        }

        public string GetDescription()
        {
            return m_Description;
        }

        public void Interact()
        {
            OnInteract.Invoke();
            m_SceneLoader.Load(m_LoadSceneName);
        }
    }
}
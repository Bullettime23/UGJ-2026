using CodeBase.InteractionSystem;
using LevGamekit.Infrastructure.SceneLoader;
using LevGamekit.Infrastructure.ServiceLocator;
using UnityEngine;
using UnityEngine.Events;

public class DoorInteractible : MonoBehaviour, IInteractible
{
    public UnityEvent OnInteract;

    [SerializeField] private string m_Description;
    [SerializeField] private string m_LoadSceneName;

    public string GetDescrition()
    {
        return m_Description;
    }

    public void Interact()
    {
        OnInteract.Invoke();
        AllServices.Container.Single<ISceneLoader>().Load(m_LoadSceneName);
    }
}

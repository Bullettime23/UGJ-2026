using CodeBase.InteractionSystem;
using LevGamekit.Infrastructure.SceneLoader;
using LevGamekit.Infrastructure.ServiceLocator;
using UnityEngine;
using UnityEngine.Events;

public class InteractibleTest : MonoBehaviour, IInteractible
{
    public UnityEvent OnInteract;
    public string GetDescription()
    {
        return "To Main room";
    }

    public void Interact()
    {
        OnInteract.Invoke();
        AllServices.Container.Single<ISceneLoader>().Load("MainRoom");
    }
}

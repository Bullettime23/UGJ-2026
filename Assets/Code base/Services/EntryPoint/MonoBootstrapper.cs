using UnityEngine;

namespace LevGamekit.Infrastructure.EntryPoint
{ 
    /// <summary>
    /// Use to execute game logic
    /// </summary>
    public abstract class MonoBootstrapper : MonoBehaviour
    {
        public abstract void Bootstrap();
    }
}

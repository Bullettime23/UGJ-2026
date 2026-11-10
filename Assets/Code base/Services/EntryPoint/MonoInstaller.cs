using UnityEngine;

namespace LevGamekit.Infrastructure.EntryPoint
{
    /// <summary>
    /// Use to register services before game logic execution
    /// </summary>
    public class MonoInstaller : MonoBehaviour
    {
        [SerializeField] private MonoBootstrapper monoBootstrapper;

        private void Awake()
        {
            InstallBindings();

            monoBootstrapper?.Bootstrap();
        }
        /// <summary>
        /// Executes logic beforeBootstrap method call of the MonoBootstrapper
        /// </summary>
        protected virtual void InstallBindings() { }
    }
}

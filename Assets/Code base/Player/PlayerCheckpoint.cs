using CodeBase.DamageSystem;
using LevGamekit.Infrastructure.ServiceLocator;
using StarterAssets;
using UnityEngine;

namespace CodeBase.Player {

    public class PlayerCheckpoint : MonoBehaviour, IService
    {
        private void OnTriggerEnter(Collider other)
        {
            PlayerDestructable destructable = other.GetComponent<PlayerDestructable>();

            if (destructable != null)
            {
                destructable.LastCheckpoint = this;
            }
        }

        public void Respawn(PlayerDestructable player)
        {
            player.GetComponent<FirstPersonController>().SetPositionAndRotation(transform);

            player.playerActionMap.Enable();
        }
    }
}
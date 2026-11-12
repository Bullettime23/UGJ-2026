using UnityEngine;

namespace CodeBase.DamageSystem {
    public class KillZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            PlayerDestructable destructable = other.GetComponent<PlayerDestructable>();

            if (destructable != null)
            {
                destructable.Kill();
            }
        }
    }
}
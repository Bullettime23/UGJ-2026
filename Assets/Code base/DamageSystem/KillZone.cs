using UnityEngine;

namespace CodeBase.DamageSystem {
    public class KillZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("collided  with " + other.name);
            PlayerDestructable destructable = other.GetComponent<PlayerDestructable>();

            if (destructable != null)
            {
                destructable.Kill();
            }
        }
    }
}
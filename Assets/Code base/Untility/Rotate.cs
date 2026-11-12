using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private Vector3 direction;
    [SerializeField] private GameObject target;

    private void Update()
    {
        if (target != null)
        {
        target.transform.Rotate(Time.deltaTime * direction);
        }
    }
}

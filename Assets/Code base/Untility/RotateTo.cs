using UnityEngine;

public class RotateTo : MonoBehaviour
{
    [SerializeField] private Vector3 target;
    [SerializeField] private float speed;

    private void Update()
    {
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(target), speed * Time.deltaTime);
    }
}

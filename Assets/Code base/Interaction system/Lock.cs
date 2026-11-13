using UnityEngine;

public class Lock : MonoBehaviour
{
    public bool isOpen = false;

    public void OpenLock()
    {
        GetComponent<MeshRenderer>().material.color = Color.goldenRod;

        Destroy(gameObject, 1);
    }
}

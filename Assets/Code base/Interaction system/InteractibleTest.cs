using CodeBase.InteractionSystem;
using UnityEngine;

public class InteractibleTest : MonoBehaviour, IInteractible
{
    private Material m_Mat;

    private void Start()
    {
        m_Mat = GetComponent<MeshRenderer>().material;
    }
    public string GetDescrition()
    {
        return "Some random description";
    }

    public void Interact()
    {
        m_Mat.color = new Color(Random.value, Random.value, Random.value);
    }
}

using UnityEngine;

public class ObjetosVisionNocturna : MonoBehaviour
{
    private Renderer vision;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vision = GetComponent<Renderer>();
        vision.enabled = false;
    }

    public void ActualizarVision(bool visionActiva)
    {
        vision.enabled = visionActiva;
        Debug.Log("Vision objetos: " + vision);
    }
}

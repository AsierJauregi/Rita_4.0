using UnityEngine;

public class Puerta : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private Transform posicionAbierta;
    [SerializeField] private Transform posicionCerrada;

    private Transform posicionPuerta;

    void Start()
    {
        posicionPuerta = posicionCerrada;
        posicionAbierta.SetParent(null);
        posicionCerrada.SetParent(null);
    }


    void Update()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, posicionPuerta.position, velocidad *  Time.deltaTime);
    }

    public void Abrir()
    {
        posicionPuerta = posicionAbierta;
    }

    public void Cerrar()
    {
        posicionPuerta = posicionCerrada;
    }

}

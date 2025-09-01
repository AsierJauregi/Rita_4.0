using Unity.Cinemachine;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private Transform posicionAbierta;
    [SerializeField] private Transform posicionCerrada;
    [SerializeField] private CinemachineCamera camPuerta;

    private Transform posicionPuerta;
    public bool movimientoCompletado = true;
    private bool puertaAbierta = false;

    void Start()
    {
        posicionPuerta = posicionCerrada;
        posicionAbierta.SetParent(null);
        posicionCerrada.SetParent(null);
    }


    void Update()
    {
        if (transform.position != posicionPuerta.position)
        {
            if (camPuerta != null)
            {
                camPuerta.Priority = 20;
            }

            movimientoCompletado = false;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, posicionPuerta.position, velocidad * Time.deltaTime);
        }
        else
        {
            movimientoCompletado = true;
            camPuerta.Priority = 5;
        }
    }


    public void AbrirCerrar()
    {
        puertaAbierta = !puertaAbierta;

        if (puertaAbierta)
        {
            posicionPuerta = posicionAbierta;
        }
        else
        {
            posicionPuerta = posicionCerrada;
        }
    }

}

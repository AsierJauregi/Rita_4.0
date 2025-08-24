using UnityEngine;

public class Palanca : MonoBehaviour, IInteractuable
{
    [SerializeField] private Puerta puertaAsociada;
    [SerializeField] private Transform basePalanca;
    private bool activada = false;

    public void Interact(GameObject interactor)
    {
        activada = !activada;  // Cambio el estado

        if (activada)
        {
            Debug.Log("Palanca activada");
            puertaAsociada.Abrir();
        }
        else
        {
            Debug.Log("Palanca desactivada");
            puertaAsociada.Cerrar();
        }

        RotarPalanca();
    }

    private void RotarPalanca()
    {
        if (activada)
        {
            transform.RotateAround(basePalanca.position, Vector3.forward, 45f);
        }
        else
        {
            transform.RotateAround(basePalanca.position, Vector3.forward, -45f);
        }
    }

}

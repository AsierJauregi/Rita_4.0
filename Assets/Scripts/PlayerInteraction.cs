using UnityEngine;
using UnityEngine.Timeline;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float rangoInteraccion;
    [SerializeField] private LayerMask capaInteractuable;
    [SerializeField] private Transform puntoInteraccion;

    private Vector3 direccion;


    void Update()
    {
        direccion = transform.right;
        Debug.DrawRay(puntoInteraccion.position, direccion * rangoInteraccion, Color.green);

        if (Input.GetKeyDown(KeyCode.E))    // Uso el sistema viejo por comodidad
        {
            Debug.Log("intento interactuar");
            IntentarInteractuar();
        }   
    }

    private void IntentarInteractuar()
    {
        Ray ray = new Ray(puntoInteraccion.position, direccion);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rangoInteraccion, capaInteractuable))
        {
            IInteractuable interactuable = hit.collider.GetComponent<IInteractuable>();

            if (interactuable != null)  // Si contiene la interfaz IInteractuable
            {
                Debug.Log("Interactuo");
                interactuable.Interact(gameObject);
            }
        }
    }
}

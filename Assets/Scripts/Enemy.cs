using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float vida;

    public void QuitarVida(float danho)
    {
        vida -= danho;
        Debug.Log("Vida restante: " + vida);

        if (vida <= 0)
        {
            Destroy(this.gameObject);          
        }
    }

}

using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float vida;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


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

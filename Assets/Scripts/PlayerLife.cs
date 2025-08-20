using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int vidaTotal;
    private int vida;

    [Header("UI")]
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Image fillImage;

    private void Start()
    {
        vida = vidaTotal;
        healthSlider.maxValue = vidaTotal;
        healthSlider.value = vida;
    }

    public void QuitarVida()
    {
        vida--;
        Debug.Log("Vida: " + vida);

        ActualizarUI();

        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void ActualizarUI()
    {
        healthSlider.value = vida;

        float t = (float) vida / vidaTotal;

        if (t > 0.5f)
        {
            fillImage.color = Color.green;
        }
        else if (t > 0.25)
        {
            fillImage.color = Color.yellow;
        }
        else
        {
            fillImage.color = Color.red;
        }
    }
}

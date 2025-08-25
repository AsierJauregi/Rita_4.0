using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private Button botonCargar;

    private void Start()
    {
        // Solo puedo pulsarlo si hay algo guardado
        botonCargar.interactable = SaveSystem.HayCheckpoint();
    }
    public void NuevaPartida()
    {
        SaveSystem.ResetProgress();
        SceneManager.LoadScene("Juego");
    }

    public void CargarPartida()
    {
        SceneManager.LoadScene("Juego");
        SaveSystem.CargarCheckpoint();
    }
}

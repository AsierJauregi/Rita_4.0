using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool activado = false;

    private void OnTriggerEnter(Collider elOtro)
    {
        if (elOtro.CompareTag("Player") && !activado)
        {
            activado = true;
            FindAnyObjectByType<CheckpointManager>().UpdateRespawnPoint(transform);
        }
    }
}

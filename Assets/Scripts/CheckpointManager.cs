using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private Transform respawnPoint;


    public void Respawn()
    {
        CharacterController cc = GetComponent<CharacterController>();

        cc.enabled = false;

        transform.position = respawnPoint.position;

        cc.enabled = true;

    }

    private void OnTriggerEnter(Collider elOtro)
    {
        if (elOtro.CompareTag("Checkpoint"))
        {
            respawnPoint = elOtro.transform;
        }
    }
}

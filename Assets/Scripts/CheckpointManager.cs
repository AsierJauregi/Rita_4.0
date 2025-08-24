using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    [SerializeField] private GameObject efectoCheckpoint;
    [SerializeField] private Transform checkpointEffectPoint;
    private Transform respawnPoint;
    

    public void Respawn()
    {
        CharacterController cc = GetComponent<CharacterController>();

        cc.enabled = false;

        transform.position = respawnPoint.position;

        cc.enabled = true;

    }

    public void UpdateRespawnPoint(Transform nuevoPunto)
    {
        respawnPoint = nuevoPunto;
        Instantiate(efectoCheckpoint, checkpointEffectPoint);
    }
}

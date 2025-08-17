using UnityEngine;

public class NightVisionPickup : MonoBehaviour, IInteractuable
{

    public void Interact(GameObject interactor)
    {
        Debug.Log("Cojo el objeto");
        // Miro si el interactor (player) tiene el script correspondiente
        NightVisionManager vision = interactor.GetComponent<NightVisionManager>();

        if (vision != null)
        {
            vision.RecogerGafas();
        }

        Destroy(gameObject);
    }

}

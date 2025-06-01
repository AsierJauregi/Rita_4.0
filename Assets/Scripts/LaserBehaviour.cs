using UnityEngine;
using UnityEngine.UIElements;

public class LaserBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private string playerTag;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag(playerTag))
        {
            Debug.Log("Rita hit");
            Destroy(gameObject);
        }
       else if (other.gameObject.layer == LayerMask.NameToLayer("Suelo"))
        {

        }
    }
}

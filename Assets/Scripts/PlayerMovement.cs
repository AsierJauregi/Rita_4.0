using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float inputH;
    [SerializeField] private float horizontalSpeed;

    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        inputH = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(inputH * horizontalSpeed, rb.linearVelocity.y);

        if (inputH != 0)
        {
            anim.SetBool("running", true);
            if (inputH > 0)
            {
                transform.eulerAngles = Vector3.zero;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
        else
        {
            anim.SetBool("running", false);
        }
    }
}

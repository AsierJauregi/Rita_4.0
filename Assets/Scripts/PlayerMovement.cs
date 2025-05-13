using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float horizontalSpeed;
    [SerializeField] private InputManagerSO inputManager;
    [SerializeField] private float factorGravedad;
    [SerializeField] private float alturaDeSalto;

    private Vector2 direccionInput;
    private Vector2 direccionMovimiento;
    private Vector2 velocidadVertical;
    private CharacterController controller;

    [Header("Detección suelo")]
    [SerializeField] private Transform pies;
    [SerializeField] private float radioDeteccion;
    [SerializeField] private LayerMask queEsSuelo;

    [Header("Ataque")]
    [SerializeField] private Transform puntoAtaque;
    [SerializeField] private float radioAtaque;
    [SerializeField] private LayerMask queEsEnemigo;
    [SerializeField] private float danhoAtaque;
    [SerializeField] private float timeBtwAttacks;
    private float timer = 0;

    private Animator anim;


    private void OnEnable()
    {
        inputManager.OnSaltar += Saltar;
        inputManager.OnMover += Mover;
        inputManager.OnAtacar += Atacar;
    }


    private void Atacar()
    {
        anim.SetTrigger("attack");
        Collider[] enemigosDetectados = Physics.OverlapSphere(puntoAtaque.position, radioAtaque, queEsEnemigo);

        if (enemigosDetectados.Length > 0 && timer >= timeBtwAttacks)
        {
            // Solo atacamos al primer enemigo detectado
            GameObject enemigo = enemigosDetectados[0].gameObject;

            // Obtenemos el componente con la lógica del enemigo
            Enemy enemigoScript = enemigo.GetComponent<Enemy>();
            if (enemigoScript != null)
            {
                enemigoScript.QuitarVida(danhoAtaque); 
                timer = 0;
            }
        }
        else
        {
            Debug.Log("No hay enemigos al alcance");
        }

    }


    private void Mover(Vector2 ctx)
    {
        direccionInput = new Vector2(ctx.x, 0);
    }

    private void Saltar()
    {
        if (EstoyEnSuelo())
        {
            Debug.Log("Saltar");
            velocidadVertical.y = Mathf.Sqrt(-2 * factorGravedad * alturaDeSalto);
            //y = sqrt(-2 * g * h)
            anim.SetTrigger("jump");
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        timer += Time.deltaTime;
    }

    private void Movement()
    {
        direccionMovimiento = new Vector2(direccionInput.x, 0);
        controller.Move(direccionMovimiento * horizontalSpeed * Time.deltaTime);

        if (direccionMovimiento.magnitude != 0)
        {
            anim.SetBool("running", true);
            if (direccionMovimiento.x > 0)
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

        if (EstoyEnSuelo() && velocidadVertical.y < 0)
        {
            //Si he aterrizado reseteo la velocidad vertical
            velocidadVertical.y = 0;
            anim.ResetTrigger("jump"); //Para que no se acumulen triggers
        }
        AplicarGravedad();
    }

    private bool EstoyEnSuelo()
    {
        return Physics.CheckSphere(pies.position, radioDeteccion, queEsSuelo);
        //Devuelve un bool para saber si estoy en el suelo o en el aire
    }

    private void AplicarGravedad()
    {
      
        velocidadVertical.y += factorGravedad * Time.deltaTime;

        controller.Move(velocidadVertical * Time.deltaTime);
        //Multiplico ambas veces por Time.deltaTime porque es una aceleración (s^2)
    }


    private void OnDrawGizmos()
    {
        //Área de ataque
        Gizmos.DrawSphere(puntoAtaque.position, radioAtaque);
    }
}

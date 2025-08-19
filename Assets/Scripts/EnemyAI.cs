using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private enum State { Patrol, Chase, Attack }
    private State currentState;

    [Header("Referencias")]
    [SerializeField] Transform player;
    [SerializeField] Transform[] waypoints;

    [Header("Datos")]
    [SerializeField] private float patrolSpeed;
    [SerializeField] private float chaseSpeed;
    [SerializeField] private float detectionRange;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackCooldown;

    private int waypointIndex = 0;
    private float attackTimer;


    void Start()
    {
        currentState = State.Patrol;

        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i].SetParent(null);  // Desemparento los waypoints para que no se muevan con el prefab
        }

        attackTimer = attackCooldown;  // Para que pueda atacar nada más llegar
    }

    void Update()
    {
        switch (currentState)
        {
            case State.Patrol: Patrol(); break;
            case State.Chase: Chase(); break;
            case State.Attack: Attack(); break;
        }
    }

    private void Patrol()
    {
        // Movimiento hacia el waypoint actual
        Transform targetWaypoint = waypoints[waypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, patrolSpeed * Time.deltaTime);

        // Mirar hacia la direccion correcta
        if (targetWaypoint.position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        // Actualizar el waypoint
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.2f)
        {
            waypointIndex = (waypointIndex + 1) % waypoints.Length; //Lo hago así por si se pasa del límite
        }

        // Cambiar de estado
        if (Vector3.Distance(transform.position, player.position) < detectionRange)
        {
            currentState = State.Chase;
        }

    }

    private void Chase()
    {
        // Movimiento hacia el jugador
        Vector3 dir = (player.position - transform.position).normalized;
        transform.position += new Vector3(dir.x, 0, 0) * chaseSpeed * Time.deltaTime;

        // Mirar hacia el jugador
        if (player.position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        // Cambiar de estado
        float dist = Vector3.Distance(transform.position, player.position);

        if (dist < attackRange)
        {
            currentState = State.Attack;
        }
        else if (dist > detectionRange * 1.5f) // Dejo algo de margen
        {
            currentState = State.Patrol;
        }
    }

    private void Attack()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer >= attackCooldown)
        {
            attackTimer = 0;
            Debug.Log("El enemigo ataca");
        }

        // Mirar hacia el jugador
        if (player.position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        // Cambiar de estado
        float dist = Vector3.Distance(transform.position, player.position);

        if (dist > attackRange)
        {
            currentState = State.Chase;
        }
    }

}

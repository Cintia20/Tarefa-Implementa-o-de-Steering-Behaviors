using UnityEngine;

public class Wander : MonoBehaviour
{
    public Transform target; // O personagem que o 'cat-1-Sleeping2_0' vai seguir
    public float wanderRadius = 5f; // Raio de "wandering"
    public float wanderTimer = 2f; // Tempo entre as mudanças de direção
    private float timer;
    private Vector3 wanderTarget;

    // Velocidade de movimento
    public float moveSpeed = 3f;

    // Start é chamado antes do primeiro Update
    void Start()
    {
        // Inicializa o timer
        timer = wanderTimer;
        // Escolhe um ponto aleatório inicial dentro do raio
        wanderTarget = GetRandomWanderTarget();
    }

    // Update é chamado uma vez por quadro
    void Update()
    {
        // Reduz o timer
        timer -= Time.deltaTime;

        // Se o tempo de wandering expirar, cria um novo alvo aleatório
        if (timer <= 0)
        {
            wanderTarget = GetRandomWanderTarget();
            timer = wanderTimer;
        }

        // Movimento de Wander (movendo-se para um ponto aleatório)
        Vector3 directionToWanderTarget = wanderTarget - transform.position;
        directionToWanderTarget.z = 0; // Ignora a dimensão z para 2D
        if (directionToWanderTarget.magnitude > 0.1f)
        {
            transform.position += directionToWanderTarget.normalized * moveSpeed * Time.deltaTime;
        }

        // Movimento em direção ao 'basic_01'
        Vector3 directionToTarget = target.position - transform.position;
        directionToTarget.z = 0; // Ignora a dimensão z para 2D
        if (directionToTarget.magnitude > 0.1f)
        {
            transform.position += directionToTarget.normalized * moveSpeed * Time.deltaTime;
        }
    }

    // Função que retorna um ponto aleatório dentro de um raio especificado
    Vector3 GetRandomWanderTarget()
    {
        float randomX = Random.Range(-wanderRadius, wanderRadius);
        float randomY = Random.Range(-wanderRadius, wanderRadius);
        return new Vector3(randomX, randomY, 0) + transform.position;
    }
}
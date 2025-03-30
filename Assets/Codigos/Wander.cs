using UnityEngine;

public class Wander : MonoBehaviour
{
    public Transform target; // O personagem que o 'cat-1-Sleeping2_0' vai seguir
    public float wanderRadius = 5f; // Raio de "wandering"
    public float wanderTimer = 2f; // Tempo entre as mudan�as de dire��o
    private float timer;
    private Vector3 wanderTarget;

    // Velocidade de movimento
    public float moveSpeed = 3f;

    // Start � chamado antes do primeiro Update
    void Start()
    {
        // Inicializa o timer
        timer = wanderTimer;
        // Escolhe um ponto aleat�rio inicial dentro do raio
        wanderTarget = GetRandomWanderTarget();
    }

    // Update � chamado uma vez por quadro
    void Update()
    {
        // Reduz o timer
        timer -= Time.deltaTime;

        // Se o tempo de wandering expirar, cria um novo alvo aleat�rio
        if (timer <= 0)
        {
            wanderTarget = GetRandomWanderTarget();
            timer = wanderTimer;
        }

        // Movimento de Wander (movendo-se para um ponto aleat�rio)
        Vector3 directionToWanderTarget = wanderTarget - transform.position;
        directionToWanderTarget.z = 0; // Ignora a dimens�o z para 2D
        if (directionToWanderTarget.magnitude > 0.1f)
        {
            transform.position += directionToWanderTarget.normalized * moveSpeed * Time.deltaTime;
        }

        // Movimento em dire��o ao 'basic_01'
        Vector3 directionToTarget = target.position - transform.position;
        directionToTarget.z = 0; // Ignora a dimens�o z para 2D
        if (directionToTarget.magnitude > 0.1f)
        {
            transform.position += directionToTarget.normalized * moveSpeed * Time.deltaTime;
        }
    }

    // Fun��o que retorna um ponto aleat�rio dentro de um raio especificado
    Vector3 GetRandomWanderTarget()
    {
        float randomX = Random.Range(-wanderRadius, wanderRadius);
        float randomY = Random.Range(-wanderRadius, wanderRadius);
        return new Vector3(randomX, randomY, 0) + transform.position;
    }
}
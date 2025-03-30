using UnityEngine;

public class Arrival : MonoBehaviour
{
    public Transform target; // Referência para o alvo (personagem "basic_01")
    public float arrivalRadius = 1f; // Distância em que o comportamento de chegada começa
    public float maxSpeed = 5f; // Velocidade máxima do personagem
    public float maxAcceleration = 10f; // Aceleração máxima do personagem
    private Vector3 velocity; // Velocidade do personagem (sem usar Rigidbody2D)

    void Start()
    {
        // Encontre o alvo na cena (caso não esteja referenciado diretamente)
        if (target == null)
        {
            target = GameObject.FindWithTag("basic_01").transform;
        }
    }

    void Update()
    {
        // Chama a função de Steering Behaviors "Arrival"
        Vector3 steering = ArrivalSteering(target.position);
        // Aplica o steering ao personagem, movendo-o
        ApplySteering(steering);
    }

    Vector3 ArrivalSteering(Vector3 targetPosition)
    {
        // Calcula a direção do alvo
        Vector3 direction = targetPosition - transform.position;

        // Calcula a distância até o alvo
        float distance = direction.magnitude;

        // Normaliza a direção
        direction.Normalize();

        // Se o personagem estiver dentro do raio de chegada, reduz a velocidade
        if (distance < arrivalRadius)
        {
            // Reduz a velocidade de aproximação conforme a distância
            float speed = Mathf.Lerp(0, maxSpeed, distance / arrivalRadius);
            return direction * speed;
        }
        else
        {
            // Se estiver longe o suficiente, usa a velocidade máxima
            return direction * maxSpeed;
        }
    }

    void ApplySteering(Vector3 steering)
    {
        // Atualiza a posição do personagem diretamente com base no steering calculado
        transform.position += steering * Time.deltaTime;
    }
}
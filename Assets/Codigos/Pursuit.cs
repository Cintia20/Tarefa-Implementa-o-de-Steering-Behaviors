using UnityEngine;

public class Pursuit : MonoBehaviour
{
    public Transform target; // Referência para o alvo (basic_01)
    public float maxSpeed = 5f; // Velocidade máxima do cat-1-Sleeping2_0
    public float maxPrediction = 1f; // Previsão máxima do alvo (quanto mais alto, mais distante a previsão)

    private Vector3 previousPosition; // Armazena a posição anterior do alvo
    private Vector3 velocity; // Velocidade do alvo baseada na posição anterior

    private void Start()
    {
        // Inicializa a posição anterior do alvo
        if (target != null)
        {
            previousPosition = target.position;
        }
    }

    private void Update()
    {
        // Se o alvo não estiver definido, sai
        if (target == null)
            return;

        // Atualiza a velocidade do alvo com base na diferença entre a posição anterior e a atual
        UpdateTargetVelocity();

        // Chama a função de Pursuit
        PursueTarget();
    }

    private void UpdateTargetVelocity()
    {
        // Calcula a velocidade do alvo com base na diferença de posição
        velocity = (target.position - previousPosition) / Time.deltaTime;

        // Atualiza a posição anterior para a posição atual
        previousPosition = target.position;
    }

    private void PursueTarget()
    {
        // Calcula a direção para o alvo e a distância
        Vector3 directionToTarget = target.position - transform.position;
        float distance = directionToTarget.magnitude;

        // Calcula o tempo de previsão (quanto mais rápido o alvo, mais previsão é necessária)
        float predictionTime = Mathf.Min(distance / maxSpeed, maxPrediction);

        // Calcula a posição futura do alvo
        Vector3 futurePosition = target.position + velocity * predictionTime;

        // Direção de Pursuit: ponto futuro menos a posição atual do personagem
        Vector3 pursuitDirection = futurePosition - transform.position;

        // Normaliza a direção para ajustar a velocidade
        pursuitDirection.Normalize();

        // Move o personagem para a posição de Pursuit
        transform.position += pursuitDirection * maxSpeed * Time.deltaTime;
    }
}
using UnityEngine;

public class Pursuit : MonoBehaviour
{
    public Transform target; // Refer�ncia para o alvo (basic_01)
    public float maxSpeed = 5f; // Velocidade m�xima do cat-1-Sleeping2_0
    public float maxPrediction = 1f; // Previs�o m�xima do alvo (quanto mais alto, mais distante a previs�o)

    private Vector3 previousPosition; // Armazena a posi��o anterior do alvo
    private Vector3 velocity; // Velocidade do alvo baseada na posi��o anterior

    private void Start()
    {
        // Inicializa a posi��o anterior do alvo
        if (target != null)
        {
            previousPosition = target.position;
        }
    }

    private void Update()
    {
        // Se o alvo n�o estiver definido, sai
        if (target == null)
            return;

        // Atualiza a velocidade do alvo com base na diferen�a entre a posi��o anterior e a atual
        UpdateTargetVelocity();

        // Chama a fun��o de Pursuit
        PursueTarget();
    }

    private void UpdateTargetVelocity()
    {
        // Calcula a velocidade do alvo com base na diferen�a de posi��o
        velocity = (target.position - previousPosition) / Time.deltaTime;

        // Atualiza a posi��o anterior para a posi��o atual
        previousPosition = target.position;
    }

    private void PursueTarget()
    {
        // Calcula a dire��o para o alvo e a dist�ncia
        Vector3 directionToTarget = target.position - transform.position;
        float distance = directionToTarget.magnitude;

        // Calcula o tempo de previs�o (quanto mais r�pido o alvo, mais previs�o � necess�ria)
        float predictionTime = Mathf.Min(distance / maxSpeed, maxPrediction);

        // Calcula a posi��o futura do alvo
        Vector3 futurePosition = target.position + velocity * predictionTime;

        // Dire��o de Pursuit: ponto futuro menos a posi��o atual do personagem
        Vector3 pursuitDirection = futurePosition - transform.position;

        // Normaliza a dire��o para ajustar a velocidade
        pursuitDirection.Normalize();

        // Move o personagem para a posi��o de Pursuit
        transform.position += pursuitDirection * maxSpeed * Time.deltaTime;
    }
}
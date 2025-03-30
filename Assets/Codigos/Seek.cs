using UnityEngine;

public class Seek : MonoBehaviour
{
    public Transform target; // Referência ao personagem "basic_01"
    public float speed = 5f;
    public float stoppingDistance = 0.5f; // Distância mínima para parar

    void Update()
    {
        if (target != null)
        {
            Vector2 direction = (target.position - transform.position).normalized; // Direção para o alvo
            float distance = Vector2.Distance(transform.position, target.position);

            if (distance > stoppingDistance)
            {
                transform.position += (Vector3)direction * speed * Time.deltaTime; // Move o personagem
            }
        }
    }
}
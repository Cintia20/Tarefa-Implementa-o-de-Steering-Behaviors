using UnityEngine;

public class Seek : MonoBehaviour
{
    public Transform target; // Refer�ncia ao personagem "basic_01"
    public float speed = 5f;
    public float stoppingDistance = 0.5f; // Dist�ncia m�nima para parar

    void Update()
    {
        if (target != null)
        {
            Vector2 direction = (target.position - transform.position).normalized; // Dire��o para o alvo
            float distance = Vector2.Distance(transform.position, target.position);

            if (distance > stoppingDistance)
            {
                transform.position += (Vector3)direction * speed * Time.deltaTime; // Move o personagem
            }
        }
    }
}
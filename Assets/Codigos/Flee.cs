using UnityEngine;

public class Flee : MonoBehaviour
{
    public Transform target;  // O personagem que o cat-1-Sleeping2_0 vai fugir
    public float fleeRadius = 5f;  // Distância para começar a fugir
    public float speed = 5f;  // Velocidade do personagem

    private Vector3 fleeDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Definindo o alvo para o basic_01
        target = GameObject.Find("basic_01").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Chama o método de Flee (Fuga) se o target estiver dentro do raio de fuga
        if (Vector3.Distance(transform.position, target.position) < fleeRadius)
        {
            FleeFromTarget();
        }
    }

    // Método de Fuga
    void FleeFromTarget()
    {
        // Calcula a direção oposta ao alvo
        fleeDirection = transform.position - target.position;
        fleeDirection.Normalize();  // Normaliza para que a velocidade seja constante

        // Move o personagem na direção oposta ao alvo
        transform.position += fleeDirection * speed * Time.deltaTime;
    }
}
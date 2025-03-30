using UnityEngine;

public class Movimento : MonoBehaviour
{
    public float speed = 5f; // Velocidade do personagem

    void Update()
    {
        // Captura a posição do mouse na tela e converte para o espaço do mundo
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z; // Mantém a posição Z do personagem

        // Move o personagem em direção ao mouse de forma suave
        transform.position = Vector3.Lerp(transform.position, mousePosition, speed * Time.deltaTime);
    }
}
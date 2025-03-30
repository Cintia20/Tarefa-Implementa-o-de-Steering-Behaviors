using UnityEngine;

public class Movimento : MonoBehaviour
{
    public float speed = 5f; // Velocidade do personagem

    void Update()
    {
        // Captura a posi��o do mouse na tela e converte para o espa�o do mundo
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z; // Mant�m a posi��o Z do personagem

        // Move o personagem em dire��o ao mouse de forma suave
        transform.position = Vector3.Lerp(transform.position, mousePosition, speed * Time.deltaTime);
    }
}
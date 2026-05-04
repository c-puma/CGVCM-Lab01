using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float tiempoVida = 5f; // Para no saturar el motor físico

    void Start()
    {
        // Destruye la bala después de unos segundos para optimizar performance
        Destroy(gameObject, tiempoVida);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Detecta si golpeó a un enemigo o un aro (usando Tags)
        if (collision.gameObject.CompareTag("Target"))
        {
            Debug.Log("¡Impacto certero!");
            LogicaJuego logica = FindFirstObjectByType<LogicaJuego>();
            if (logica != null) logica.GanarPuntos(10);

            Destroy(gameObject); // Destruye la bala al impactar
        }

        // Si toca el suelo, simplemente puede revotar para simular la fisica real
    }

}
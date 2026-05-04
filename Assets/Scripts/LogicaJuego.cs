using UnityEngine;
using UnityEngine.SceneManagement; // Para reiniciar el nivel

public class LogicaJuego : MonoBehaviour
{
    public int puntosParaGanar = 50;
    public int puntosActuales = 0;
    public GameObject panelVictoria; // Arrastra aquí tu PanelVictoria

    // Método para sumar puntos (lo llamaremos desde el proyectil)
    public void GanarPuntos(int cantidad)
    {
        puntosActuales += cantidad;

        if (puntosActuales >= puntosParaGanar)
        {
            MostrarVictoria();
        }
    }

    void MostrarVictoria()
    {
        panelVictoria.SetActive(true); // Muestra el panel
        Time.timeScale = 0f; // Pausa el motor físico y el tiempo 
        Cursor.lockState = CursorLockMode.None; // Libera el mouse para el botón
        Cursor.visible = true;
    }

    // Función para el botón de Reiniciar
    public void ReiniciarJuego()
    {
        Time.timeScale = 1f; // Reanuda el tiempo
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
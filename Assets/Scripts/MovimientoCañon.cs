using UnityEngine;

public class MovimientoCañon : MonoBehaviour
{

    public GameObject prefabBala;    
    public Transform puntoDisparo;  
    public float fuerzaDisparo = 500f;
    public float velocidadRotacion = 100f;

    public AudioClip sonidoDisparo;
    private AudioSource audioSource;

    void Start()
    {
        // Obtenemos el componente AudioSource al iniciar
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float rotarH = Input.GetAxis("Horizontal") * velocidadRotacion * Time.deltaTime;
        transform.Rotate(0, rotarH, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Disparar();
        }
    }

    void Disparar()
    {
        // Instancia el proyectil
        GameObject bala = Instantiate(prefabBala, puntoDisparo.position, puntoDisparo.rotation);

       // Obtiene el Rigidbody para aplicar física [cite: 30, 51]
        Rigidbody rb = bala.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Aplica una fuerza hacia adelante
            rb.AddForce(puntoDisparo.forward * fuerzaDisparo, ForceMode.Impulse);
            // REPRODUCIR SONIDO
            if (audioSource != null && sonidoDisparo != null)
            {
                audioSource.PlayOneShot(sonidoDisparo);
            }
        }
    }
}


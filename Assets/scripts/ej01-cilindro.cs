/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes 2026-2027
 * 4º Año de Carrera
 * Práctica 4: Eventos y Físicas en Unity - Ejercicio 1
 *
 * @author Bruno Morales Hernandez alu0101664309@ull.edu.es
 * @brief Emisor de eventos que notifica mediante un delegado cuando
 *        el cubo colisiona físicamente contra el cilindro.
 * @date Oct 18 2026
 * @version 1.0
 */

using UnityEngine;

public class NotificadorCilindro : MonoBehaviour
{
    // Firma del delegado para la notificación de colisión
    public delegate void delegadoColision();

    // Evento al que se suscribirán las esferas para reaccionar al impacto
    public event delegadoColision onCuboChoca;

    /**
     * @brief Detecta el impacto físico con el Cubo y dispara el evento.
     * @param collision Información física del contacto.
     */
    void OnCollisionEnter(Collision collision)
    {
        // Se valida que el objeto colisionante sea el Cubo
        if (collision.gameObject.name == "Cubo")
        {
            // Notificación segura a todos los suscriptores registrados
            if (onCuboChoca != null)
            {
                onCuboChoca();
            }
        }
    }
}
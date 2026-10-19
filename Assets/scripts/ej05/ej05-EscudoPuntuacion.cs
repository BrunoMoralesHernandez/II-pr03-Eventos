/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes 2026-2027
 * 4º Año de Carrera
 * Práctica 4: Eventos y Físicas en Unity - Ejercicio 5
 *
 * @author Bruno Morales Hernandez alu0101664309@ull.edu.es
 * @brief Destruye el objeto escudo de la escena al detectar la colisión física con el jugador.
 * @date Oct 19 2026
 * @version 1.0
 */

using UnityEngine;

public class EscudoPuntuacion : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Se destruye el escudo tras ser recolectado por el jugador
        if (collision.gameObject.name == "jugador")
        {
            Destroy(gameObject);     
        }
    }
}
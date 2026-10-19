/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes 2026-2027
 * 4º Año de Carrera
 * Práctica 4: Eventos y Físicas en Unity - Ejercicio 3
 *
 * @author Bruno Morales Hernandez alu0101664309@ull.edu.es
 * @brief Emisor de eventos asociado al jugador (cubo). Notifica a los distintos
 *        grupos de humanoides al impactar físicamente con ellos.
 * @date Oct 19 2026
 * @version 1.0
 */

using UnityEngine;

public class NotificadorCubo : MonoBehaviour
{
    public delegate void delegadoColision();
    public event delegadoColision onCuboChocaGrupo1;
    public event delegadoColision onCuboChocaGrupo2;

    void OnCollisionEnter(Collision collision)
    {
        // Identificación por subcadena en el nombre del prefab/instancia
        if (collision.gameObject.name.Contains("Footman"))
        {
            if (onCuboChocaGrupo1 != null)
            {
                onCuboChocaGrupo1();
            }
        }
        else if (collision.gameObject.name.Contains("FreeLich"))
        {
            if (onCuboChocaGrupo2 != null)
            {
                onCuboChocaGrupo2();
            }
        }
    }
}
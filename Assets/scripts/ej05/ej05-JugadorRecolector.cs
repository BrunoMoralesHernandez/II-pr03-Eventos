/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes 2026-2027
 * 4º Año de Carrera
 * Práctica 4: Eventos y Físicas en Unity - Ejercicio 5
 *
 * @author Bruno Morales Hernandez alu0101664309@ull.edu.es
 * @brief Gestiona la recolección de escudos mediante colisiones físicas, incrementando
 *        la puntuación según el tipo de escudo e imprimiendo el total por consola.
 * @date Oct 19 2026
 * @version 1.0
 */

using UnityEngine;

public class JugadorRecolector : MonoBehaviour
{
    private int puntuacion = 0;

    void OnCollisionEnter(Collision collision)
    {
        // Se discrimina la puntuación en función del tipo de escudo impactado
        if (collision.gameObject.name.Contains("Tipo1"))
        {
            puntuacion += 5;
        } 
        else if (collision.gameObject.name.Contains("Tipo2"))
        {
            puntuacion += 10;
        }

        Debug.Log("Puntuacion: " + puntuacion);
    }
}
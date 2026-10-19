/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes 2026-2027
 * 4º Año de Carrera
 * Práctica 4: Eventos y Físicas en Unity - Ejercicio 4
 *
 * @author Bruno Morales Hernandez alu0101664309@ull.edu.es
 * @brief Objeto de referencia (cilindro) que monitoriza la distancia con el cubo
 *        y dispara un evento de proximidad cuando se acerca a un umbral determinado.
 * @date Oct 19 2026
 * @version 1.0
 */

using UnityEngine;

public class NotificadorReferencia : MonoBehaviour
{
    public delegate void delegadoColision();
    public event delegadoColision onProximidadDetectada;

    public GameObject cubo;
    public float distanciaActivacion = 2;

    void Update()
    {
        // Comprobación de proximidad euclídea con el cubo
        if (Vector3.Distance(transform.position, cubo.transform.position) <= distanciaActivacion)
        {
            onProximidadDetectada();
        }
    }
}
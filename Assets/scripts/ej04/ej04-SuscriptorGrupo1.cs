/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes 2026-2027
 * 4º Año de Carrera
 * Práctica 4: Eventos y Físicas en Unity - Ejercicio 4
 *
 * @author Bruno Morales Hernandez alu0101664309@ull.edu.es
 * @brief Suscriptor para los humanoides del Grupo 1. Reacciona al evento de
 *        proximidad del objeto de referencia teletransportándose al escudo objetivo.
 * @date Oct 19 2026
 * @version 1.0
 */

using UnityEngine;

public class SuscriptorTPGrupo1 : MonoBehaviour
{
    public NotificadorReferencia cilindro;
    public GameObject objetivo;

    void Start()
    {
        cilindro.onProximidadDetectada += Teletransporte;
    }

    void Teletransporte()
    {
        // Reubicación instantánea a la posición del escudo objetivo
        if (objetivo != null)
        {
            transform.position = objetivo.transform.position;
        }
    }
}
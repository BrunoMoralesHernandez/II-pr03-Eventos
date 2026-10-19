/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes 2026-2027
 * 4º Año de Carrera
 * Práctica 4: Eventos y Físicas en Unity - Ejercicio 4
 *
 * @author Bruno Morales Hernandez alu0101664309@ull.edu.es
 * @brief Suscriptor para los humanoides del Grupo 2. Reacciona al evento de
 *        proximidad orientando su rotación frontal hacia un objeto determinado.
 * @date Oct 19 2026
 * @version 1.0
 */

using UnityEngine;

public class SuscriptorOrientaGrupo2 : MonoBehaviour
{
    public NotificadorReferencia cilindro;
    public GameObject objetivo;

    void Start()
    {
        cilindro.onProximidadDetectada += Orientar;
    }

    void Orientar()
    {
        // Rota la entidad para que su eje Z mire directamente al objeto designado
        if (objetivo != null)
        {
            transform.LookAt(objetivo.transform);
        }
    }
}
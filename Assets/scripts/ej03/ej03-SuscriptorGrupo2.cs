/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes 2026-2027
 * 4º Año de Carrera
 * Práctica 4: Eventos y Físicas en Unity - Ejercicio 3
 *
 * @author Bruno Morales Hernandez alu0101664309@ull.edu.es
 * @brief Controla a los humanoides del Grupo 2 (FreeLich). Se activa cuando el cubo 
 *        colisiona con un humanoide del Grupo 1, desplazándose hacia el escudo objetivo.
 * @date Oct 19 2026
 * @version 1.0
 */

using UnityEngine;

public class SuscriptorGrupo2 : MonoBehaviour
{
    public NotificadorCubo notificador;
    public GameObject objetivo;
    public float velocidad = 5f;

    private bool huboColision = false;

    void Start()
    {
        // Reacciona al impacto del cubo con entidades del grupo rival (Grupo 1)
        if (notificador != null)
        {
            notificador.onCuboChocaGrupo1 += ActivarMovimiento;
        }
    }

    void Update()
    {
        if (huboColision && objetivo != null)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                objetivo.transform.position,
                velocidad * Time.deltaTime
            );
        }
    }

    void ActivarMovimiento()
    {
        huboColision = true;
    }

    private void OnDestroy()
    {
        if (notificador != null)
        {
            notificador.onCuboChocaGrupo1 -= ActivarMovimiento;
        }
    }
}
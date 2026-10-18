/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes 2026-2027
 * 4º Año de Carrera
 * Práctica 4: Eventos y Físicas en Unity - Ejercicio 1
 *
 * @author Bruno Morales Hernandez alu0101664309@ull.edu.es
 * @brief Suscriptor que escucha el evento del cilindro y desplaza la esfera
 *        hacia su objetivo asignado mediante interpolación lineal.
 * @date Oct 18 2026
 * @version 1.0
 */

using UnityEngine;

public class SuscriptorEsfera : MonoBehaviour
{
    // Referencia al cilindro que emite el evento de choque
    public NotificadorCilindro notificador;

    // Objeto destino hacia el que se desplazará la esfera (cilindro u otra esfera)
    public GameObject objetivo;

    // Velocidad constante de desplazamiento
    public float velocidad = 5f;

    // Bandera de control para activar el movimiento tras el evento
    private bool huboColision = false;

    /**
     * @brief Suscripción al evento del notificador al arrancar el objeto.
     */
    void Start()
    {
        if (notificador != null)
        {
            notificador.onCuboChoca += ActivarMovimiento;
        }
    }

    /**
     * @brief Traslación frame a frame hacia el objetivo si el evento ha sido recibido.
     */
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

    /**
     * @brief Callback ejecutado cuando el cilindro emite el evento de colisión.
     */
    void ActivarMovimiento()
    {
        huboColision = true;
    }
}
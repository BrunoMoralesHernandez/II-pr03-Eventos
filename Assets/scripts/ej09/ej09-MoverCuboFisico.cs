/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes 2026-2027
 * 4º Año de Carrera
 * Práctica 4: Eventos y Físicas en Unity - Ejercicio 9
 *
 * @author Bruno Morales Hernandez alu0101664309@ull.edu.es
 * @brief Control de movimiento físico del cubo mediante Rigidbody y MovePosition
 *        en FixedUpdate para garantizar la resolución continua de colisiones.
 * @date Oct 19 2026
 * @version 1.0
 */

using UnityEngine;

public class MoverCuboFisico : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float movimientoVertical = Input.GetAxisRaw("Vertical");
        float movimientoHorizontal = Input.GetAxisRaw("Horizontal");

        if (movimientoHorizontal != 0 || movimientoVertical != 0)
        {
            Vector3 desplazamiento = new Vector3(
                movimientoHorizontal * speed * Time.fixedDeltaTime,
                0f,
                movimientoVertical * speed * Time.fixedDeltaTime
            );

            // Desplazamiento continuo que evalúa colisiones sólidas en el trayecto
            rb.MovePosition(rb.position + desplazamiento);
        }
    }
}
/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes 2026-2027
 * 4º Año de Carrera
 * Práctica 4: Eventos y Físicas en Unity - Ejercicio 3
 *
 * @author Bruno Morales Hernandez alu0101664309@ull.edu.es
 * @brief Desplaza al cubo sobre el plano mediante Rigidbody en FixedUpdate,
 *        garantizando una correcta interacción física con los colisionadores de la escena.
 * @date Oct 19 2026
 * @version 1.0
 */

using UnityEngine;

public class MoverCubo : MonoBehaviour
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
            // Desplazamiento cinemático del cuerpo rígido preservando la detección de colisiones
            Vector3 desplazamiento = new Vector3(
                movimientoHorizontal * speed * Time.deltaTime,
                0,
                movimientoVertical * speed * Time.deltaTime
            );
            rb.position = rb.position + desplazamiento;
        }
    }
}
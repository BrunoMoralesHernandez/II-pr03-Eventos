/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes 2026-2027
 * 4º Año de Carrera
 * Práctica 4: Eventos y Físicas en Unity - Ejercicio 6
 *
 * @author Bruno Morales Hernandez alu0101664309@ull.edu.es
 * @brief Gestiona la recolección de escudos y actualiza en tiempo real
 *        la puntuación del jugador sobre la interfaz gráfica (Canvas) usando TextMeshPro.
 * @date Oct 19 2026
 * @version 1.0
 */

using UnityEngine;
using TMPro;

public class JugadorRecolectorUI : MonoBehaviour
{
    public TMP_Text textoPuntuacion;
    private int puntuacion = 0;

    void Start()
    {
        ActualizarMarcador();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Se discrimina la puntuación en función del tipo de escudo impactado
        if (collision.gameObject.name.Contains("Tipo1"))
        {
            puntuacion += 5;
            ActualizarMarcador();
            Destroy(collision.gameObject);
        } 
        else if (collision.gameObject.name.Contains("Tipo2"))
        {
            puntuacion += 10;
            ActualizarMarcador();
            Destroy(collision.gameObject);
        }
    }

    // Refresca el contenido visual del texto en el HUD
    void ActualizarMarcador()
    {
        if (textoPuntuacion != null)
        {
            textoPuntuacion.text = "Puntos: " + puntuacion;
        }
    }
}
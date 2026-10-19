/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes 2026-2027
 * 4º Año de Carrera
 * Práctica 4: Eventos y Físicas en Unity - Ejercicio 7
 *
 * @author Bruno Morales Hernandez alu0101664309@ull.edu.es
 * @brief Gestiona la recolección de escudos, la actualización del marcador en tiempo real
 *        y el desbloqueo progresivo de recompensas en la UI cada 100 puntos acumulados.
 * @date Oct 19 2026
 * @version 1.0
 */

using UnityEngine;
using TMPro;

public class NotificadorJugador : MonoBehaviour 
{
    [Header("Interfaz de Usuario")]
    public TMP_Text textoPuntuacion;
    public TMP_Text textoRecompensa;

    [Header("Variables de Lógica")]
    public int puntosTotales = 0;
    private int proximaRecompensa = 100;

    void Start()
    {
        ActualizarMarcador();
        if (textoRecompensa != null)
        {
            textoRecompensa.text = ""; 
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Se discrimina la puntuación en función del tipo de escudo impactado
        if (collision.gameObject.name.Contains("Tipo1"))
        {
            SumarPuntos(5);
            Destroy(collision.gameObject);
        }   
        else if (collision.gameObject.name.Contains("Tipo2"))
        {
            SumarPuntos(10);
            Destroy(collision.gameObject);
        }
    }

    void SumarPuntos(int cantidad)
    {
        puntosTotales += cantidad;
        ActualizarMarcador();
        ComprobarRecompensa();
    }

    void ActualizarMarcador()
    {
        if (textoPuntuacion != null) 
        {
            textoPuntuacion.text = "Puntos: " + puntosTotales;
        }
    }

    // Comprueba si se ha alcanzado o superado el umbral actual de recompensa
    void ComprobarRecompensa()
    {
        if (puntosTotales >= proximaRecompensa)
        {
            if (textoRecompensa != null)
            {
                textoRecompensa.text = "¡Recompensa Desbloqueada por " + proximaRecompensa + " puntos!";
            }
            
            // Se incrementa la meta de forma escalonada (100, 200, 300...)
            proximaRecompensa += 100; 
        }
    }
}
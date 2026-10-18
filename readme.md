# Práctica 4: Eventos, Físicas y Notificaciones en Unity

**Asignatura:** Interfaces Inteligentes  
**Titulación:** Grado en Ingeniería Informática — Universidad de La Laguna (ULL)  
**Autor:** Bruno Morales Hernández — alu0101664309@ull.edu.es  
**Fecha:** Octubre 2026  

---

## Descripción General

El propósito principal de esta práctica es profundizar en la integración del motor de físicas 3D de Unity junto con arquitecturas orientadas a eventos mediante **delegados y eventos en C#** (Patrón Observador). A través de una batería progresiva de ejercicios, se abordan la comunicación desacoplada entre objetos ante impactos o triggers, la sustitución e interacción con modelos humanoides, mecánicas de recolección con actualización de interfaz gráfica (UI) y la coexistencia de entidades físicas dinámicas y cinemáticas.

---

## Estructura del Repositorio

```text
.
├── Assets/
│   ├── Scenes/
│   │   └── SampleScene.unity      
│   ├── Scripts/                   
│   │   ├── NotificadorCilindro.cs
│   │   └── SuscriptorEsfera.cs
│   └── Settings/                  
├── docs/
│   └── gifs/                      
│       └── ejercicio-01.gif
├── Packages/                      
├── ProjectSettings/               
└── README.md                      
```

---

## Ejercicios y Soluciones Técnicas

### Ejercicio 1: Coordinación de esferas mediante el Patrón Observer

Para resolver este ejercicio se implementa una arquitectura desacoplada basada en el **Patrón Observer** (publicador-suscriptor) utilizando los delegados (`delegate`) y eventos (`event`) nativos de C#. En lugar de que el objeto que detecta el impacto tenga que conocer y buscar manualmente a cada una de las esferas en la escena, el **Cilindro actúa como emisor (*Publisher*)**, disparando el evento `onCuboChoca` dentro del callback de colisión física `OnCollisionEnter` cuando valida que el cuerpo que contacta con él es el Cubo.

Las esferas, por su parte, actúan como **oyentes (*Subscribers*)** mediante el script `SuscriptorEsfera`. Al iniciarse la escena se suscriben al evento del cilindro, asociando su propia función callback. Cuando el cilindro notifica el impacto, todas las esferas activan su estado de marcha de manera reactiva y se desplazan frame a frame en `Update` mediante `Vector3.MoveTowards`: las de tipo 1 (rojas) convergen hacia la esfera de tipo 2 de referencia, mientras que las de tipo 2 (verdes) se dirigen hacia el propio cilindro.

* **Componentes y conceptos clave:**
  * **Físicas:** `OnCollisionEnter`, `BoxCollider` y `Rigidbody` dinámico en el Cubo para disparar la colisión.
  * **Arquitectura C#:** `delegate` y `event` para garantizar un acoplamiento nulo entre el cilindro y los objetos que reaccionan.
  * **Movimiento cinemático:** `Vector3.MoveTowards` con `Time.deltaTime` para un avance lineal constante y freno exacto en destino.

![Demostración Ejercicio 1](docs/gifs/ejercicio-01.gif)

---
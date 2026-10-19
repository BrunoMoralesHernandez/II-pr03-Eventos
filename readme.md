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

### Ejercicio 2: Sustitución de primitivas por modelos humanoides

Para este ejercicio cambiamos las esferas básicas por modelos 3D de humanoides, manteniendo exactamente la misma lógica de eventos que ya teníamos montada. El objetivo principal es ver cómo una arquitectura desacoplada nos permite cambiar la parte visual por completo sin tener que reescribir el comportamiento. A cada uno de estos nuevos personajes se le ajusta un `BoxCollider` a su cuerpo para delimitar su volumen y se le vuelve a asignar el script del suscriptor.

El funcionamiento en escena es el mismo que en el ejercicio anterior: cuando el cubo choca contra el cilindro, se lanza el evento y los personajes reaccionan. Los humanoides de tipo 1 (rojos) empiezan a caminar hacia el humanoide de tipo 2 (verde) que tenemos fijado como referencia, y los de tipo 2 (verdes) se desplazan directos hacia el cilindro. Al estar todo separado mediante delegados, no hizo falta tocar la lógica de comunicación para adaptarla a los nuevos modelos.

* **Componentes y conceptos clave:**
  * **Adaptación de geometrías:** Sustitución de primitivas por modelos tridimensionales ajustando sus colisionadores (`BoxCollider`) al volumen del cuerpo.
  * **Reutilización y desacoplamiento:** Mantenimiento de la arquitectura de eventos y delegados de C# sin cambios en el código lógico, validando la independencia entre vista/modelo y lógica.
  * **Traslación y orientación:** Desplazamiento reactivo de los avatares hacia sus objetivos fijados mediante `Vector3.MoveTowards`.

![Demostración Ejercicio 2](docs/gifs/ejercicio-02.gif)

---

### Ejercicio 3: Notificación selectiva entre grupos y colisión con escudos

En este ejercicio ampliamos la mecánica basada en el patrón Observer para gestionar dos grupos de entidades independientes: humanoides del tipo 1 (Footman) y del tipo 2 (FreeLich), junto con dos tipos de escudos en la escena. Ahora el emisor del evento pasa a ser el propio Cubo mediante el script `NotificadorCubo`. Cuando el cubo se desplaza con las teclas y colisiona físicamente contra un personaje, discrimina a qué grupo pertenece en `OnCollisionEnter` revisando el nombre del objeto (`Footman` o `FreeLich`) y lanza el evento correspondiente: `onCuboChocaGrupo1` o `onCuboChocaGrupo2`.

La lógica de respuesta está cruzada entre ambos bandos. Los humanoides del grupo 1 (Footman) se suscriben al evento que avisa cuando el cubo impacta a un rival del grupo 2; al recibirlo, inician su desplazamiento hacia el escudo de tipo 1 seleccionado. Por su parte, los del grupo 2 (FreeLich) escuchan el choque contra el grupo 1 y avanzan hacia los escudos del grupo 2. Además, durante el desplazamiento en `Update`, cada humanoide comprueba frame a frame si su volumen o malla entra en contacto con la del escudo objetivo (evaluando la intersección de sus colisionadores). En cuanto se detecta dicho contacto, se modifica el material del modelo a través de su `Renderer`: los del grupo 1 cambian su color a **amarillo**, mientras que los del grupo 2 pasan a color **violeta**.

* **Componentes y conceptos clave:**
  * **Eventos diferenciados:** Declaración de múltiples eventos (`onCuboChocaGrupo1` y `onCuboChocaGrupo2`) para coordinar respuestas cruzadas e independientes entre ambos grupos.
  * **Discriminación en colisión:** Filtrado en `OnCollisionEnter` mediante comprobación de subcadenas en los nombres de las instancias para saber qué delegado invocar.
  * **Físicas y control del jugador:** Desplazamiento cinemático con `rb.position` en `FixedUpdate` para interactuar de forma sólida con los personajes.
  * **Comprobación geométrica y respuesta visual:** Verificación de solapamiento de mallas/colisionadores en `Update` y cambio dinámico de color en el `Renderer` (amarillo para el grupo 1 y violeta para el grupo 2) al alcanzar el escudo.

![Demostración Ejercicio 3](docs/gifs/ejercicio-03.gif)

---

### Ejercicio 4: Detección por proximidad, teletransporte y orientación

En este ejercicio cambiamos la forma de activar el evento: en lugar de esperar a un choque físico directo, la interacción se dispara por proximidad geométrica. Para ello, el cilindro actúa como objeto de referencia y emisor a través del script `NotificadorReferencia`. En su método `Update`, calcula en cada frame la distancia euclídea que lo separa del cubo con `Vector3.Distance`; en cuanto el jugador cruza el umbral establecido (`distanciaActivacion`), se lanza el evento `onProximidadDetectada`.

A partir de esta única señal, volvemos a aplicar el patrón Observer para obtener respuestas totalmente distintas según el tipo de humanoide. Los del grupo 1 tienen asociado `SuscriptorTPGrupo1`, de modo que al activarse el evento se teletransportan al instante igualando su posición a la del escudo objetivo (`transform.position = objetivo.transform.position`). Por su parte, los del grupo 2 utilizan `SuscriptorOrientaGrupo2` y no se desplazan, sino que reaccionan rotando su orientación hacia un objeto de la escena mediante `transform.LookAt`.

* **Componentes y conceptos clave:**
  * **Activación por proximidad:** Cálculo continuo de distancia euclídea (`Vector3.Distance`) en `Update` como alternativa matemática a los colisionadores de tipo Trigger.
  * **Patrón Observer con respuestas heterogéneas:** Un mismo evento dispara lógicas independientes según la entidad suscrita (traslación instantánea vs reorientación espacial).
  * **Manipulación de `Transform`:** Modificación directa de coordenadas para el teletransporte y empleo de `transform.LookAt` para enfocar el frente del modelo hacia el objetivo.

![Demostración Ejercicio 4](docs/gifs/ejercicio-04.gif)
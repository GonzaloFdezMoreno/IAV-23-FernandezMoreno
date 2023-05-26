# IAV-23-FernandezMoreno

## Autor
- Gonzalo Fernández Moreno ([GonzaloFdezMoreno](https://github.com/GonzaloFdezMoreno))
  *Leer el LeerPrimero.txt para tener algunos puntos en cuenta y saber de antemano posibles errores*

## Propuesta
Se pretende crear un juego en el cual el jugador pueda llegar al objeto que debe robar y una vez conseguida encontrar el camno de vuelta (usando la heuristica de la práctica 2); por otro lado habrá unos guardias que rondan el lugar y que dependiendo de si llevamos el objeto o no nos perseguiran o antes dudarán sobre si nos han visto o no.

## Punto de partida
Se parte de un proyecto base de Unity proporcionado por el profesor aquí:
https://github.com/Narratech/IAV-Navegacion.

En resumen, partimos de un proyecto de Unity en el que se nos proporciona, en una escena, un **menú principal** en el que podremos seleccionar el *tamaño del laberinto* y el *número de minotauros* en él. Una vez seleccionados los parámetros que queremos y le demos al botón de *Comenzar*, aparecerá un **laberinto del tamaño seleccionado**, y en él el **número de minotauros seleccionado** y a **Teseo**. Teseo se puede mover con WASD, podemos cambiar los FPS con F, hacer zoom con la rueda del ratón, reiniciar con R y cambiar la heurística utilizada con C.

En cuanto a código, se nos ha proporcionado varios scripts generales: *Agente, ComportamientoAgente, Dirección*, *MinoManager* y *GestorJuego*. A un nivel más específico, tenemos scripts para el jugador  (*ControlJugador* y *SeguirCamino*) y para los Minotauros (*Merodear*, *MinoCollision*, *MinoEvader* y *Slow*). La mayoría de estos últimos scripts
También se incluyen en el proyecto *prefabs* para el jugador, los minotauros y los elementos del laberinto.


Algunos de estos recursos se modificarán para hacer los nuevos comportamientos, asi como los objetivos (como los minotauros, que ahora serán guardias y se comportarán de forma distinta)



## Diseño de la solución

La manera en la que vamos a afrontar esta práctica es la siguiente:

 - Se utilizará **el script de Graph** para que sea capaz de ir y volver por camino utilizando el algoritmo de A*.

 - Además de ello, se modificará **el script de persecucuión** para el guardia, para que sea capaz de perseguir al jugador si se cumplen ciertas condiciones.
 
 - Se crearán y/o modificarán varios scripts para el nuevo comportamiento de los guardias.

 - Característica A: El juego ahora consiste en llegar al objeto y traerlo de vuelta a la casilla inicial
*Hacer que en el Game Manager una vez llegues a la salida,
puedas llevarte el objeto y debas llegar con ello al lugar donde empezaste para completar el juego*

 - Característica B: Modificar el hilo para que una vez tengas el objeto en tu poder te indique el camino de salida
 
 *If(tienes el objeto)-> lugar de destino: la salida*
  
 *else -> lugar de destino: el objeto*

- Característica C: El guardia seguirá un hilo hacia un punto determinado y cuando este lo alcance cambiará al siguiente asignado, estos puntos 
                    serán creados desde el mapa y se interpretarán en la lectura de este.
                    
 *If(casilla[i][j]=="1")->checkpoint1...*
 
 *If(llega al primer Checkpoint)-> lugar de destino: siguiente checkpoint*
  
 - Caracteristica D: El guardia dependiendo de lo que vea actuará de forma distinta:
 
                    - Si no ve al jugador, seguirá realizando su patrulla
                    - Si ve al jugador pero este no lleva el objeto, dudará unos instantes y se quedará parado mirando al jugador antes de ir a por el
                    - Si ve al jugador y este lleva el objeto irá directamente a por el
                    
 *If (no veo)->Patrulla*
 
  *else if(veo sin objeto)->sospecha*
  
  *else if (veo sin objeto durante un rato)->perseguir*
  
  *else if (veo con objeto)->perseguir*
- Caracteristica E: El jugador podrá recoger el objeto y dejarlo con la tecla E, llevar el objeto te hace ir mas lento y alerta al guardia ensegida si te ve,
                   por lo que a lo mejor es mas optimo para tu ruta de escape dejar el objeto en un lugar oculto o dejar el objeto para escapar con facilidad 
                   
                   
- Caracteristica F: El guardia si ve que el objeto se encuentra en un lugar que no le corresponde irá a por el para entregarlo de inmediato a donde debería estar

*if (veo objeto fuera de su sitio)-> Ir a por el objeto*

- Caractrística G: El guardia lleva el objeto al punto donde estaba originalmente y luego vuelve a seguir su patrulla 
 *if(lleva el ojbeto)-> lugar de destino: zona orginal del objeto*
 *una vez dejado -> seguir la patruya*

- Característica H: 2 guardias que funcionan de la misma forma con las carácterísticas anteriores pero que realizan un recorrido distinto y
                    funcionan de manera independiente

## Pruebas y métricas

Se descarga: [Vídeo de prueba](https://github.com/GonzaloFdezMoreno/IAV-23-FernandezMoreno/raw/main/Video%20Muestra.mp4)

Version final del juego:

Se descarga: [Vídeo final](https://github.com/GonzaloFdezMoreno/IAV-23-FernandezMoreno/raw/main/Video%20Final.mp4)

*Los videos realizan las pruebas mencionadas; sin embargo puede haber alguna característica que se muestra en el primer video y no en el segundo*

*Ejemplo: La Característica B se muestra cuando recoges el objeto y te indica la casilla de salida en el primer video, pero en el segundo no se muestra*

## Producción

| Estado  |  Tarea  |  Fecha  |  
|:-:|:--|:-:|
|  | Diseño: Primer borrador | 10/05/2023 |
| Hecho | Característica A: Nuevo objetivo del juego, ir y volver con el objeto | 14/05/2023 |
| Hecho | Característica B: Cambiar el camino a seguir del algoritmo A* cuando lleguemos al objeto | 17/05/2023 |
| Hecho | Característica C: Patrulla del guardia | 21/05/2023 |
| Hecho | Característica D: Decisiones del guardia | 22/05/2023 |
| Hecho | Característica E: Dejar y recoger el objeto | 22/05/2023 |
| Hecho | Característica F: Que el guardia recoja el objeto | 23/05/2023 |
| Hecho | Característica G: Que el guardia lleve el objeto a donde estaba | 26/05/2023 |
| Hecho | Característica H: 2 guardias|  26/05/2023 |

## Referencias

Los recursos de terceros utilizados son de uso público.

- *AI for Games*, Ian Millington.
- [Kaykit Medieval Builder Pack](https://kaylousberg.itch.io/kaykit-medieval-builder-pack)
- [Kaykit Dungeon](https://kaylousberg.itch.io/kaykit-dungeon)
- [Kaykit Animations](https://kaylousberg.itch.io/kaykit-animations)

# IAV-23-FernandezMoreno

## Autor
- Gonzalo Fernández Moreno ([GonzaloFdezMoreno](https://github.com/GonzaloFdezMoreno))

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

 - Utilizaremos **el script de Graph** para que sea capaz de ir y volver por camino utilizando el algoritmo de A*.

 - Además de ello, se modificará **el script de persecucuión** para el guardia, para que sea capaz de perseguir al jugador si se cumplen ciertas condiciones.
 
 - Crearemos un script para el nuevo comportamiento de los guardias y posiblemente será representado con una maquina de estados 

## Pruebas y métricas



## Ampliaciones



## Producción

| Estado  |  Tarea  |  Fecha  |  
|:-:|:--|:-:|
|  | Diseño: Primer borrador | 10/05/2023 |
| Hecho | Característica A: Nuevo objetivo del juego, ir y volver con el objeto | 14/05/2023 |
| Hecho | Característica B: Cambiar el camino a seguir del algoritmo A* cuando lleguemos al objeto | 17/05/2023 |
|  | Característica C: Patrulla del guardia
|  | Característica D: Decisiones del guardia
|  | Característica E: Dejar y recoger el objeto
||||
| **-----** | **OPCIONAL** | **-----** |
|  | Que el guardia recoja el objeto
|  | Varios guardias

## Referencias

Los recursos de terceros utilizados son de uso público.

- *AI for Games*, Ian Millington.
- [Kaykit Medieval Builder Pack](https://kaylousberg.itch.io/kaykit-medieval-builder-pack)
- [Kaykit Dungeon](https://kaylousberg.itch.io/kaykit-dungeon)
- [Kaykit Animations](https://kaylousberg.itch.io/kaykit-animations)

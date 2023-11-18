# VIDEO EXPLICATIVO
Link:

# APLICACIÓN DE PRINCIPIOS Y ARQUITECTURAS DE SISTEMAS HIPERMEDIA
Este script de Unity maneja la pausa y la reanudación del juego. Puede ser asociado a un botón en la interfaz de usuario y también responde a la tecla "P". Cuando se hace clic en el botón o se presiona la tecla "P", llama a la función CambiarEstadoPausa(), que invierte el estado de pausa del juego, pausando o reanudando el tiempo según el estado actual. Además, actualiza el texto del botón para reflejar el nuevo estado.

![image](https://github.com/f11v/Progreso-1/assets/146761375/2316bc60-c9c0-455c-bb03-6b0ca2096d14)

 

Este script de Unity maneja la funcionalidad de reiniciar el juego. Puede ser asociado a un botón en la interfaz de usuario y también responde a la tecla "R". Cuando se hace clic en el botón o se presiona la tecla "R", llama a la función ReiniciarJuegoFunc(). Dentro de esta función, se carga la escena especificada por nombreDeEscena utilizando SceneManager.LoadScene(). Además, se asegura de reiniciar el tiempo en el juego estableciendo Time.timeScale a 1 (esto es importante si el tiempo estaba pausado en algún momento).
 
![image](https://github.com/f11v/Progreso-1/assets/146761375/83ece105-c2d4-481d-9d09-9f4abe762a63)




Este código muestra una cámara alterna, en este caso yo le puse una cámara en la parte superior para simular un mapa, al momento de aplastar un botón la cámara se mostrará y en la parte inferior muestra unos mensajes en el botón, de ocultar y mostrar mapa.

 ![image](https://github.com/f11v/Progreso-1/assets/146761375/8151fbda-53ec-405f-83e2-08bbe2e9cdcf)



Nuestra última característica es mostrar la palabra ganaste cuando el score sea igual o mayor que 120 y después de 10 segundo volverá a la escena inicio.

![image](https://github.com/f11v/Progreso-1/assets/146761375/34470425-f4c2-4812-9bd0-90d1525bfdaf)


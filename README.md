# Camaras del proyecto

## Switch de las camaras 

[Codigo CameraSwitch](Assets/Scripts/CameraSwitch.cs)

Este script contiene tres variables para almacenar las tres camaras de proyecto y metodos correspondientes para su activacion y desactivacion.

## Camara tercera persona

[Codigo CameraSwitch](Assets/Scripts/CameraController.cs)

Este script utiliza un Vector3 para almacenar la distancia entre camara y jugador, para posteriormente utilizarla para mantener esa distancia independientemente del movimiento del jugador.

## Camara primera persona



## Camara plano completo

[Codigo CameraSwitch](Assets/Scripts/Camera_World.cs)

Este script utiliza los metodos LookAt() para mantener la vista al entorno de juego y Translate() para aplaicar un Vector3(1.0,0,0) * velocidad para mantener la camara rotando al rededor del entorno;

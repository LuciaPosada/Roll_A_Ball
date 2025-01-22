# Camaras del proyecto

## Switch de las camaras 

[Codigo CameraSwitch](Assets/Scripts/CameraSwitch.cs)

Este script contiene tres variables para almacenar las tres cámaras de proyecto y los métodos correspondientes para su activación y desactivación.

<details>
 <summary>Explicación del código</summary>
<br>

Variables que permiten asociar manualmente las cámaras:
```bash
public GameObject firstPersonCamera;
public GameObject thirdPersonCamera;
public GameObject WorldCamera;
```

En el método Update se detecta si el jugador presiona alguna de las teclas pertinentes (1,2,3) y llama al método correspondiente para activar a cada cámara:
```bash
private void Update() {
    if (Input.GetKeyDown(KeyCode.Alpha1)) {
        ActivateFirstPersonCamera(); # Activa camara de primera persona y desactiva el resto
    }
    ....
```
---
</details>

## Camara tercera persona

[Codigo CameraSwitch](Assets/Scripts/CameraController.cs)

Este script utiliza un Vector3 para almacenar la distancia entre camara y jugador, para posteriormente utilizarla para mantener esa distancia independientemente del movimiento del jugador.

## Camara primera persona



## Camara Global

[Codigo CameraSwitch](Assets/Scripts/Camera_World.cs)

Este script utiliza los metodos LookAt() para mantener la vista al entorno de juego y Translate() para aplaicar un Vector3(1.0,0,0) * velocidad para mantener la camara rotando al rededor del entorno;

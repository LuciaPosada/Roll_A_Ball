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

Este script utiliza un Vector3 para almacenar la distancia entre cámara y jugador y poder así seguir al jugador manteniendo una distancia constante.

<details>
 <summary>Explicación del código</summary>
<br>

Variables utilizadas:
```bash
public GameObject player; # Referencia al objeto jugador
private Vector3 offset; # Almacena la distancia entre cámara y jugador
```

Al comienzo, mediante el método Start(), se calcula la distancia entre jugador y cámara para almacenarla como Vector3:
```bash
void Start(){
    ....
    offset = transform.position - player.transform.position;
}
```

Mediante LateUpdate la cámara ajusta su posición a la del objeto manteniendo la misma distancia que al comienzo:
```bash
void LateUpdate(){
        transform.position = player.transform.position + offset;
}
```

---
</details>

## Camara primera persona



## Camara Global

[Codigo CameraSwitch](Assets/Scripts/Camera_World.cs)

Este script utiliza los metodos LookAt() para mantener la vista al entorno de juego y Translate() para aplaicar un Vector3(1.0,0,0) * velocidad para mantener la camara rotando al rededor del entorno;

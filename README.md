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
private Vector3 offset;   # Almacena la distancia entre cámara y jugador
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



## Camara global

[Codigo CameraSwitch](Assets/Scripts/Camera_World.cs)

Este script utiliza enfoca la camara hacia un blanco y va girando alrededor de este.

<details>
 <summary>Explicación del código</summary>
<br>

Variables utilizadas:
```bash
public Transform target; # Referencia al componente transform del que queramos apuntar (en este caso, es el conjunto de niveles/escenarios)
public float speed;      # Velocidad de movimiento de la cámara
```

Cada llamada del método Update() mantenemos la cámara apuntando al blanco y girando al rededor de el:
```bash
void Update(){
    transform.LookAt(target);                   # Mantiene la camara enfocado al entorno de juego (target)
    transform.Translate(Vector3.right * speed); # Mueve la cámara continuamente en la dirección derecha 
}
```

Al mantener el eje Z enfocado hacia el blanco evitamos que la cámara se desplace hacia la derecha indefinidamente y la forzamos a rotar al rededor del objeto. 

---
</details>

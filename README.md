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

[Codigo CameraController](Assets/Scripts/CameraController.cs)

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

[Codigo Camara_PrimPersona](Assets/Scripts/Camara_PrimPersona.cs)

Este script posiciona la cámara a la misma altura y posición que el objeto controlado por el jugador, permitiendo el movimiento horizontal de esta mediante el raton.

<details>
 <summary>Explicación del código</summary>
<br>

Variables utilizadas:
```bash
public GameObject player;             # Referencia al objeto jugador
public float mouseSensitivity = 100f; # Controla la velocidad de giro de la cámara en respuesta al movimiento del ratón
private float yRotation = 0f;         # Acumulador del ángulo de rotación horizontal
```

Al llamar al método Update() se recoge el imput del ratón en el eje horizontal y se le transmite a la rotación de la cámara:

```bash
void Update(){
    float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity; 
    yRotation += mouseX;                                        # Acumula los valores del movimiento del ratón
    transform.rotation = Quaternion.Euler(0f, yRotation, 0f);   # Actualiza la rotación de la cámara exlusivamente en el eje Y
    transform.position = player.transform.position;             # Mantiene la cámara en la misma posición que el jugador
}
```

---
</details>

[Codigo PlayerController](Assets/Scripts/PlayerController.cs)

Adicionalmente, el script del objeto que control el jugador contiene una variable para recoger los valores de la cámara de primera persona y así poder ajustar el movimiento del jugador en base a la orientación de esta.

<details>
 <summary>Explicación del código</summary>
<br>

Variables utilizadas:
```bash
# Almacenan las entradas del jugador en los ejes X e Y
private float movementX;
private float movementY;
# Referencia al componente transform de la cámara (en este caso la de primera persona)
public Transform cameraTransform; 
....
```

El metodo OnMove() se activa automáticamente al detectar entradas configuradas como "Move" en Unity, y en el se recogen las entradas del jugador:

```bash
void OnMove(InputValue movementValue){
    Vector2 movementVector = movementValue.Get<Vector2>();
    movementX = movementVector.x;
    movementY = movementVector.y;
}
```

Durante la llamada a FixedUpdate() se calcula un Vector3 en base a la orientación de la cámara y las entradas del jugador y se lo aplica al jugador:
```bash
private void FixedUpdate(){
    Vector3 forward = cameraTransform.forward; # Obtiene el vector z de la camara
    Vector3 right = cameraTransform.right;     # Obtiene el vector x de la camara

    Vector3 movement = forward * movementY + right * movementX; 
    movement.Normalize();                      # Normaliza el nuevo vector para mantener una velocidad constante, independientemente de la dirección
    rb.AddForce(movement * speed);             
}
```

---
</details>

## Camara global

[Codigo Camera_World](Assets/Scripts/Camera_World.cs)

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

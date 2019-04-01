using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRacket: MonoBehaviour
{
public float speed = 30f; //se declara publica para que podamos modificarla en el inspector (para pruebas) sin modificar en este script
public string axis = "Vertical"; 

    void FixedUpdate ()   //esta funci�n es parecida al Update solo que es llamada en un intervalo de tiempo fijo, se utiliza cuando ocupamos la f�sica
    {
        float v = Input.GetAxisRaw(axis); /* utilizamos el GetAxisRaw para determinar la entrada del usuario del eje Y "vertical"
                                            que usar�n las raquetas que se moveran de arriba a bajo, el eje X valdr�  0 porque las raquetas
                                            no se mueven horizontalmente */

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed; /* el GetComponent nos ayuda a acceder al compoente RigidBody de la 
                                                                          raqueta, y establecer su velocidad de movimiento (direcci�n multiplicada
                                                                          por velocidad)*/
    }
    
}
  

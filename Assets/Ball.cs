using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public float speed = 30f;

    //puntuación
    public Text scoreText;
    int player1Score;
    int player2Score;

    //ganador
    public Text winner;



    void Start()
    {

        //inicia la velocidad de la bola  
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;

    }

    void OnCollisionEnter2D(Collision2D col)//OnCollisionEnter2D funcion llamada de Unity al chocar contra otra cosa 
                                            // (col) contiene la informacion de choque
                                            // si la bola choc� con una raqueta entonces:

    {
        // si golpea la raqueta izquierda
        if (col.gameObject.name == "RacketLeft")
        // col.GameObject es la raqueta 
        {
            //calcular factor de golpe
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

            //calcular direccion, hacer la longitud = 1, 
            Vector2 dir = new Vector2(1, y).normalized;

            // establecer velocidad con dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;

            player1Score++;
            
        }
        // si golpea la raqueta derecha
        if (col.gameObject.name == "RacketRight")
        {
            //calcular factor de golpe
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
            /* col.transform.position: es la posici�n dela raqueta, col.collider
            es el colicionador de la raqueta */

            ////calcular direccion, hacer la longitud = -1, 
            Vector2 dir = new Vector2(-1, y).normalized;

            // establecer velocidad con dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;

            player2Score++;
            
        }
    }
  
    float hitFactor(Vector2 ballPos, Vector2 racketPos, float rachetHeight)
    {
        return (ballPos.y - racketPos.y) / rachetHeight;
        //ballPos.y, RacketPos.y restamos estos dos para tener una posicion contraria

        /* averiguamos donde está la bola en relacion con la raqueta
         dividir la coordenada (y) de la bola por la altura de la raqueta*/

        // 1: en la parte superior de la raqueta
        // 0: en medio de la raqueta
        // -1: por debajo de la raqueta
    }

    void Update()
    {
        
        scoreText.text = player1Score + " - " + player2Score; //para mostrar el texto 0-0
        
        
        if (player1Score == 10)
        {
            winner.text = ("player 1 gana");
            winner.gameObject.SetActive(true); //para activar el texto que dice el ganador
        }
        if (player2Score == 10)
        {
            winner.text = ("player 2 gana");
            winner.gameObject.SetActive(true);  //para activar el texto que dice el ganador
        }
        
      
    }

   
    


}


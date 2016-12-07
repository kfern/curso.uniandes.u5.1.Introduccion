using UnityEngine;
using System.Collections;

public class Controlador_Terreno : MonoBehaviour {

	void OnTriggerExit2D(Collider2D collider)
	{
		Debug.Log("Algo se ha salido del terreno. Si es el personaje está en el mar y debería perder vida o su equivalente."); 
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		Debug.Log ("Algo ha entrado. Al iniciar el juego se lanza el evento PARA CADA ELEMENTO QUE COLISIONE CON EL TERRENO!!. Si estaba perdiendo vida ha de dejar de perderla."); 
	}
}
 
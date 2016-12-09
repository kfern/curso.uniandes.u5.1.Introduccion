using UnityEngine;
using System.Collections;

public class Controlador_Personaje_A : MonoBehaviour {
	public float Velocidad = 0.5f;
	private Rigidbody2D rb;
	private Animator anim;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void Update(){
		//Determina la animacion en funcion de la velocidad (parado o no) y dirección actual (NESO).
		Vector2 rb_v = rb.velocity*Time.deltaTime;
		float x = rb_v.x;
		float y = rb_v.y;
		int nuevo_estado;

		if (x == 0 && y == 0) {
			//El objeto está parado
			nuevo_estado = 0;
		} else {
			//Si se está desplazando en x e y tengo que elegir uno de ellos ya que aún no tengo las transiciones en diagonal.
			//De momento lo decido en función del de mayor valor.
			if (x != 0 && y != 0) {
				if (Mathf.Abs (x) > Mathf.Abs (y)) {
					y = 0;
				} else {
					x = 0;
				}	
			}

			if (x == 0) {
				if (y > 0) {
					nuevo_estado = 1;//N
				} else {
					nuevo_estado = 3;//S
				}
			} else {
				if (x > 0) {
					nuevo_estado = 2;//E
				} else {
					nuevo_estado = 4;//O
				}

			}

		}

		//Asignar la nueva dirección
		anim.SetInteger ("Direccion", nuevo_estado);

	}

	void FixedUpdate () {
		//Determina las teclas pulsadas
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		Vector2 m = new Vector2(h,v);

		//Añade movimiento en función de las teclas pulsadas
		rb.AddForce (m * Velocidad);

	}
}

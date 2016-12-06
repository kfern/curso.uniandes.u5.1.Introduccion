using UnityEngine;
using System.Collections;

public class Controlador_Personaje_A : MonoBehaviour {
	public float Velocidad = 0.5f;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		Vector2 m = new Vector2 (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		rb.AddForce (m * Velocidad);
	}
}

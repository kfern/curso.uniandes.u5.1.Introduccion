using UnityEngine;
using System.Collections;

public class Controlador_Insecto_A : MonoBehaviour {
	public GameObject target;
	public float velocidadRotacion = 0.5f;
	public float velocidadAvance = 0.3f;

	//Holds the previous frames rotation
    Quaternion lastRotation;
  
	// Use this for initialization
	void Start () {
		lastRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		
		//Obtener el vector desde origen hasta destino
		Vector3 vectorToTarget = target.transform.position - transform.position;

		//Girar hasta ponerse mirando al target
		//http://answers.unity3d.com/questions/650460/rotating-a-2d-sprite-to-face-a-target-on-a-single.html
		float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) - 90;
		Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp (transform.rotation, q, Time.deltaTime * velocidadRotacion);

		//Obtener la velocidad angular. Cuando Vector3.Z = 0 => Ha terminado de girar
		//https://forum.unity3d.com/threads/manually-calculate-angular-velocity-of-gameobject.289462/
	    //The fancy, relevent math
		//References to the relevent axis angle variables
		float magnitude;
		Vector3 axis;

        Quaternion deltaRotation = transform.rotation * Quaternion.Inverse (lastRotation);
        deltaRotation.ToAngleAxis(out magnitude, out axis);
        lastRotation = transform.rotation;

		Vector3 velocidadAngular = (axis * magnitude) / Time.deltaTime;
		if (velocidadAngular.z == 0) {
			float step = velocidadAvance * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, target.transform.position, step);
		}
	}
}

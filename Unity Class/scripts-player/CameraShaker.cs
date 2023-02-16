using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
	Coroutine currentRoutine = null;

	[SerializeField] float shootShakeMagnitude = 0.5f;
	[SerializeField] float shootShakeTime = 0.1f;

    // Para que la camara se agite, usaremos corutinas
	// Las corutinas permiten parar una funcion, esperar un tiempo, y retomar la funcion por donde se habia quedado
	//		Debe devolver un IEnumerator

	// una funcion o variable que va a ser llamada por otras clases, tiene que tener la palabra clave public delante.
	public void ShootShake(Vector3 dir)
	{
		currentRoutine = StartCoroutine(ShootShakeRoutine(dir));
	}

	IEnumerator ShootShakeRoutine (Vector3 dir)
	{
		Vector3 ogPos = transform.position;
		transform.position += dir.normalized * shootShakeMagnitude;
		yield return new WaitForSeconds(shootShakeTime);
		transform.position = ogPos;
	}
}

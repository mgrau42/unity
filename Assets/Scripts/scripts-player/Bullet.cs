using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	// velocidad a la que se movera la bala
	[SerializeField] float speed = 10;
	// referencia al componente de las particulas que pondremos al morir
	[SerializeField] ParticleSystem particles = null;

	// variable que indica cuanto vamos a empujar hacia atras a un enemigo al tocarlo
	[Space]
	[SerializeField] float enemyKnockback = 0.1f;

	// Cada frame, movemos la bala para alante
    void FixedUpdate()
    {
		// el Transform no solo tiene informacion sobre la posicion, rotacion o escala del objeto.
		//		tambien de, por ejemplo, el right (la fecha roja en el editor).
        transform.position += transform.right * speed * Time.deltaTime;
    }


	// OnTriggerEnter es llamado siempre que el objeto que tiene este componente
	//		(que necesita tener tambien un Collider y un Rigidbody) haga trigger con algo.
	//		El trigger se activa cuando un collider con el checkbox de trigger activado toca algo
	private void OnTriggerEnter2D(Collider2D other) 
	{
		// hacer a las particulas hijas de nada, para que no se destruyan al destruir la bala
		//		puedes acceder al padre o los hijos de cualquier objeto desde el transform, y es siempre una referencia a otro transform
		particles.transform.parent = null;
		// activar particulas
		particles.Play();

		// Si lo otro tiene el tag enemy, le haremos daño
		if(other.CompareTag("Enemy"))
		{
			// GetComponent es una fucion que nos permite obtener el componente que queramos de un objeto.
			other.GetComponent<EnemyHealth>().TakeDamage(1);
			// Empujar hacia atras
			other.transform.position += transform.right * enemyKnockback;
		}

		// Destroy elimina un objeto de la escena
		Destroy(this.gameObject);
		//	Destroy admite un segundo parametro para destruir un objeto pasando un tiempo
		Destroy(particles.gameObject, 0.5f);
	}
}

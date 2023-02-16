using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
	// Referencia al Transform del player, para tener su posicion
    Transform player = null;
    // Referencia a la camara
    CameraShaker camShaker = null;

	[Space]
	[SerializeField] float speed = 7;

	[Space]
	[SerializeField] float obstacleDetectionRadius = 3;
	[SerializeField] LayerMask detectionMask = 0;
	[SerializeField] float obstacleAvoidance = 3;

	// referencia al ojo para que siempre mire al player
	[Space]
	[SerializeField] Transform eye = null;

	// El Start es una funcion a la que Unity llama al principio del juego.
	void Start()
	{
        // GameObject.FindWithTag(string tag) devuelve una referencia al GameObject que tenga el tag indicado.
        //		Si hay mas de un objeto con el mismo tag solo devolvera uno de ellos, y quiza no sea el que quieres.
        player = GameObject.FindWithTag("Player").transform;

        // Tenemos acceso a la camara principal desde cualquier parte con camera.main.
        camShaker = Camera.main.GetComponent<CameraShaker>();
    }

    void FixedUpdate()
    {
		if (player == null)		// si no hay player nada
			return;

		// la posicion del player - la del enemigo, es la direccion en la que deberia avanzar para acercarse a el.
        Vector3 dir = player.position - transform.position;

		// que el ojo mire al player
		eye.right = dir;

		// Con esta funcion obtenemos un array de todos los collider dentro de un area si tienen estan en una de las layer indicadas.
		// 		Los raycast y otras funciones de fisicas son utilimas :ojos: --> https://docs.unity3d.com/ScriptReference/Physics2D.html
		Collider2D [] obstacles = Physics2D.OverlapCircleAll(transform.position, obstacleDetectionRadius, detectionMask);
		// Bucle foreach, por cada Collider2D (al actual me referire como <current>) en obstacles...
		foreach	(Collider2D current in obstacles)
		{
			// modificamos la direccion para alejarnos de ese objeto
			dir += (current.transform.position - transform.position).normalized * -obstacleAvoidance;
		}

		// mover hacia la direccion
		transform.position += dir.normalized * speed * Time.deltaTime;
    }

    // -----------------------------------------------------------------------
    // ON TRIGGER
	void OnTriggerEnter2D(Collider2D other)
	{
        // si el otro es el player, que hemos guardado en el Start,
		if (other.transform == player)
		{
            // hacerle daño
            other.GetComponent<PlayerHealth>().TakeDamage(1);
            // buscar el componente game manager y resetear el multi
            GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>().ResetMulti();
            // un poco de camara shake
            camShaker.ShootShake(player.position - transform.position);

            // Destruir el enemigo
            Destroy(this.gameObject);
        }
	}
}

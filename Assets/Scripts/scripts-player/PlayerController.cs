using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	// velocidad a la que va a moverse el jugador.
	//		[SerializeField] se puede poner para editar el valor inicial de una variable desde el editor.
	//		También se puede poner public, pero eso hace que otras clases puedan accederla y modificarla.
	[SerializeField] float speed = 10;
	// Componente Animator del sprite del player, se encarga de manejas animaciones
	[SerializeField] Animator myAnimator = null;

	[Space]	// esto pone un espacio en el editor de Unity

	// El componente transform de la pistola, que asignaremos desde el editor.
	//		Nos permite modificar los valores de otro componente desde aqui.
	[SerializeField] Transform gun = null;
	// El componte Sprite Renderer de la pistola
	[SerializeField] SpriteRenderer gunSprite = null;


	// Update es una funcion a la que Unity llamara 1 vez por frame.
    void FixedUpdate()
    {
		Movement();
		GunRotation();
    }

	/* Aqui manejo el movimiento del player */
	void Movement()
	{
		// vector, por defecto a cero, que iremos modifando en base al input
		Vector3 direction = Vector3.zero;

		//	Input.GetKey() devuelve true o false si la tecla indicada esta siendo pulsada
		if (Input.GetKey(KeyCode.D))
			direction.x += 1;
		if (Input.GetKey(KeyCode.A))
			direction.x -= 1;
		if (Input.GetKey(KeyCode.W))
			direction.y += 1;
		if (Input.GetKey(KeyCode.S))
			direction.y -= 1;

		// Si la magnitud (lo que mide el vector) es mayor que cero es porque ha habido input
		//		Y si hay input, cambiamos la animacion para que se le vea corriendo
		if (direction.sqrMagnitude > 0)
			myAnimator.SetBool("run", true);
		else
			myAnimator.SetBool("run", false);

		//	Cambiamos la posicion en base al resultado de los input
		//		Normalizar un vector lo combierte en un vector con la misma direccion pero con longitud 1
		//		El deltaTime es una variable interna de Unity. Indica el tiempo, en segundos que ha pasado desde el ultimo frame.
		//			multiplicar por este valor al mover objetos hace que estos se muevan a la misma velocidad independiente del frame rate.
		transform.position += direction.normalized * speed * Time.deltaTime;

	}

	/* Aqui la rotacion del arma, para que mire al raton */
	void GunRotation()
	{
		// Guardar la posicion del raton
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos.z = 0;

		// Si la pistola apunta hacia arriba, meterla por detras del player para que parezca que él esta por delante
		if (mousePos.y > transform.position.y)
			gunSprite.sortingOrder = -1;
		else
			gunSprite.sortingOrder = 1;

		// Si la pistola apunta a la izquierda, invertir la imagen del arma
		if (mousePos.x < transform.position.x)
		{
			gun.localScale = new Vector3(1, -1, 1);
		}
		else
		{
			gun.localScale = new Vector3(1, 1, 1);	
		}

		// hacer que la pistola mire al punto
		gun.right =  mousePos - gun.position;		
	}
}

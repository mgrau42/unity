using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
	// Aqui pondremos la bala al dispararla
	[SerializeField] Transform shootingPoint = null;
	// Referencia al prefab de la bala
	[SerializeField] GameObject bulletPrefab = null;
	// Solo saldra una bala cada estos segundos
	[SerializeField] float bulletCooldown = .5f;
	// Las balas no saldran siempre rectas, tendran un poco de dispersion
	[SerializeField] float dispersion = 0.1f; 
	// Al disparar echaremos al jugador un poco para atras a modo de retroceso
	[SerializeField] float recoil = 0.3f;

	[Space]

	// Referencias a componentes camera shaker y particle system. Para añadir un poco de game feel al disparo.
	[SerializeField] CameraShaker camShaker = null;
	[SerializeField] ParticleSystem shootingParticles = null;

	// contador de tiempo para solo disparar una bala cada x
	float timeCounter = 0;

	// La funcion start es llamada por Unity al principio de la ejecucion
	void Start()
	{
		timeCounter = bulletCooldown;
	}

    void Update()
    {
		// sumar al contador de tiempo
		if (timeCounter < bulletCooldown)
			timeCounter += Time.deltaTime;

		// si se pulsa, disparar una bala. Solo si ha pasado el tiempo de cooldown.
        if (Input.GetKey(KeyCode.Mouse0) && timeCounter >= bulletCooldown)
		{
			// crear una nueva bala con Instantiate()
			//		Ojo: esto es muy poco eficiente,
			//		es mucho mejor tener una pool de objetos de las que ir sacando balas que hacer todo el rato un Instantiate.
			GameObject currentBullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
			currentBullet.transform.rotation = Quaternion.Euler(currentBullet.transform.rotation.eulerAngles + new Vector3 ( 0, 0, Random.Range(dispersion * -1, dispersion) ) );

			// echar al player un poco para atras cuando dispara
			transform.position += -shootingPoint.right * recoil;
			// añadir camara shake
			camShaker.ShootShake(-shootingPoint.right);
			// particulas de disparo
			shootingParticles.Play();
			
			// resetear contador
			timeCounter = 0;
		}
    }
}

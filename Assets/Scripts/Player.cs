using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;
    [SerializeField] int health = 200;
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.75f;

    /* U ovom delu koda, pravimo polja, koja se unose u samom razvojnom okruženju, odnosno,
    polja, koja su vezana za samog igrača. */

    [Header("Projectile")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 1f;
    [SerializeField] AudioClip projectileSound;
    [SerializeField] [Range(0, 1)] float projectileSoundVolume = 0.75f;

    /* U ovom delu koda, pravimo polja, koja se unose u samom razvojnom okruženju, odnosno,
   polja, koja su vezana za projektile, koje igrač ispaljuje. */

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    /* Definišemo globalne varijable */

    Coroutine firingCoroutine;

    /* Pravimo takozvani "Coroutine", odnosno objekat koji se ponaša kao petlja. */


    void Start()
    {
        SetUpMoveBoundaries();
    }

    /* U metodi Start, pozivamo metodu SetUpMoveBoundaries. */

    void Update()
    {
        Move();
        Fire();
    }

    /* U metodi Update, pozivamo metodu Move i metodu Fire. */

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    /* Kreirali smo metodu OnTriggerEnter2D, koja ima jedan argument, a to je Collider
     i ona treba da pravi damage Playeru, ukoliko neki objekat udari u njega.*/

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
            Destroy(gameObject);
            FindObjectOfType<Level>().LoadGameOver();
        }
    }

    /* Kreirali smo metodu ProcessHit, koja ima jedan argument, a to je objekat, koji smo
     kreirali pomoću klase DamageDealer. U ovoj metodi se oduzima Playeru health i ukoliko je
    health manji ili jednak nuli, poziva se AudioSource, uništava se igrač i pozivamo metodu
    LoadGameOver, koja menja scenu na GameOver.*/

    public int GetHealth()
    {
        return health;
    }

    /* Kreirali smo običnu metodu GetHealth, pomoću koje ćemo da šaljemo vrednost health.*/

    public void IncreaseHealth()
    {
        if(health<989)
        health += 10;
    }

    /*Kreirali smo metodu IncreaseHealth, pomoću koje ćemo da povećavamo health, kada je pozovemo,
     ali samo dok je health manji od 989*/

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContiniously());
        }
        if(Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    /* Kreiral smo metodu Fire, kod koje proveravamo da li je dugme za pucanje pritisnuto ili otpušteno
     i ukoliko je pritisnuto započinjemo naš "Coroutine", a ukoliko nije zaustavljamo ga.*/

    IEnumerator FireContiniously()
    {
        while (true)
        {
            GameObject laser = Instantiate(
                    laserPrefab,
                    transform.position,
                    Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            AudioSource.PlayClipAtPoint(projectileSound, Camera.main.transform.position, projectileSoundVolume);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }

    /* Kreirali smo metodu FireContiniously, gde sve dok je dugme za pucanje pritisnuto, pravimo lasere u vidu
     objekta, od našeg laserPrefab-a. Takođe, pozivamo AudioSource i ponavljamo akciju prema projectileFiringPeriod-u.*/

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
    }

    /* Kreirali smo metodu Move, pomoću koje, dobijamo nove pozicije Playera.*/

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;

    }

    /* Pomoću metode SetUpMoveBoundaries postavljamo granice, pomoću kojih, ne dozvoljavamo igraču da izlazi van granica same igrice.*/
}

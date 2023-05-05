using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] float health = 100;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.75f;

    /* U ovom delu koda, pravimo polja, koja se unose u samom razvojnom okruženju, odnosno,
    polja, koja su vezana za samog neprijatelja. */

    [Header("Projectiles")]
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] AudioClip projectileSound;
    [SerializeField] [Range(0, 1)] float projectileSoundVolume = 0.75f;

    /* U ovom delu koda, pravimo polja, koja se unose u samom razvojnom okruženju, odnosno,
    polja, koja su vezana za sam neprijateljski projektil. */

    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    /* U metodi Start, pozivamo metodu Random.Range, da bismo dobili neki Random broj, odnosno vreme između ispaljivanja projektila.*/

    void Update()
    {
        CountDownAndShoot();
    }

    /* U metodi Update, pozivamo metodu CountDownAndShoot.*/

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    /* Kreiramo metodu ContDownAndShoot, gde od varijable shotCounter oduzimamo vreme osvežavanja monitora, što je otprilike 100 nanosekundi
     i kada stignemo do vrednosti gde je varijabla manja od nule, pozivamo metodu Fire i ponovo radimo prethodni korak kao u metodi Start.*/

    private void Fire()
    {
        GameObject laser = Instantiate(
            projectile,
            transform.position,
            Quaternion.identity
            ) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(projectileSound, Camera.main.transform.position, projectileSoundVolume);
    }

    /* Metoda Fire slična je kao kod Playera, samo što se ne ponavlja sa Coroutine, već se izvršava samo kada se pozove sama metoda.*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        FindObjectOfType<GameSession>().AddToScore(3);
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    /* Kreirali smo metodu OnTriggerEnter2D, koja ima jedan argument, a to je Collider
     i ona treba da pravi damage Enemy-ju, ukoliko neki objekat udari u njega.*/

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            FindObjectOfType<GameSession>().AddToScore(50);
            FindObjectOfType<Player>().IncreaseHealth();
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume); 
        }
    }

    /* Kreirali smo metodu ProcessHit, koja ima jedan argument, a to je objekat, koji smo
     kreirali pomoću klase DamageDealer. U ovoj metodi se oduzima Enemy-ju health i ukoliko je
    health manji ili jednak nuli, poziva se AudioSource, uništava se neprijatelj, dodajemo Score igraču i povećavamo mu health.*/
}

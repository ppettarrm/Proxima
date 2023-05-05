using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig;
    List<Transform> waypoints;

    /* Kreiramo polja waveConfig i waypoints.*/

    int waypointIndex = 0;

    /* Kreiramo polje waypointIndex i inicijalizujem ga na 0.*/

    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].transform.position;
    }

    /* U metodi start polju waypoints, dodeljujemo vrednost pomoću metode GetWaypoints iz klase waveConfig.*/

    void Update()
    {
        Move();
    }

    /* U metodi Update, pozivamo metodu Move.*/

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    /* Kreiramo metodu SetWaveConfig, gde imamo argument, waveConfig, gde postavljamo trenutni waveConfig na novi waveConfig.*/

    public void Move()
    {
        if (waypointIndex <= waypoints.Count - 1) // waypoints.Count umanjujemo za 1, jer indeksi počinju od 0.
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }

        /* Sve dok je uslov ispunjen, targetPositionu, dodeljujemo vrednost novog waypointa, movementThisFrameu dodeljujemo vrednost i na kraju
         dodeljujemo novu poziciju talasu neprijatelja i pitamo se da li je trenutna pozicija jednaka ciljanoj poziciji.
        Ukoliko jeste, inkrementujemo waypointIndex. Ukoliko uslov nije ispunjen, uništavamo objekat. Ovo se dešava na kraju putanje talasa neprijatelja.*/
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;

    /* U ovom delu koda, pravimo polja, koja se unose u samom razvojnom okruženju, odnosno,
    polja, koja su vezana za samo stvaranje neprijateljskih talasa. */

    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while(looping);
       
    }

    /* U metodi Start, tipa IEnumerator, koristimo do while petlju, kojom sve dok je varijabla looping, koju unosimo u razvojnom okruženju,
     yield return statement-om startujemo "Coroutine" metode SpawnAllWaves.*/

    private IEnumerator SpawnAllWaves()
    {
        for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }

    /* Kreirali smo metodu SpawnAllWaves, tipa IEnumerator, u kojoj koristimo for petlju, da bismo kreirali talase neprijatelja. Deklarišemo i inicijalizujemo
     waveIndex, postavljamo uslov da se petlja izvršava sve dok je waveIndex manji od broja talasa koje smo kreirali, i na kraju inicijalizujemo waveIndex.
    Deklarišemo varijablu currentWave i dajemo joj vrednost elementa liste waveConfigs sa waveIndex-om. Nakon toga, počinjemo stvaranje svih neprijatelja.*/

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {
           var newEnemy = Instantiate(
                waveConfig.GetEnemyPrefab(),
                waveConfig.GetWaypoints()[0].transform.position,
                Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }

    /* Kreirali smo metodu SpawnAllEnemiesInWave, sa argumentom waveConfig tipa WaveConfig, u kojoj imamo for petlju, gde smo deklarisali i inicijalizovali varijablu
     enemyCount. Uslov je da je enemyCount manji od vrednosti koju dobijamo kada pozovemo funkciju GetNumberOfEnemies iz skripte WaveConfig. Na kraju inkrementujemo enemyCount.
    Deklaripemo novu varijablu newEnemy i stvaramo objekat(enemy-ja) metodom Insantiate, kojoj proslećujemo tri argumenta(Prefab, poziciju i Quaternion.identity. 
    Quaternion.identity znači da je objekat dobro orijentisan i postavljen). Pozivamo metodu SetWaveConfig iz skripte EnemyPathing i prosleđujemo joj argument waveConfig.
    Zatim pozivamo yield return statement, koji nam omogućava da odredimo vreme između stvaranja dva neprijatelja. Njemu prosleđujemo argument, koji je zapravo metoda 
    GetTimeBetweenSpawns iz skripte WaveConfig.*/

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "Enemy Wave Config")] // Prikazujemo novi tip objekta u razvojnom okruženju, pod imenom "Enemy Wave Config".
public class WaveConfig : ScriptableObject // Kreiramo novi tip objekta, putem roditeljske klase ScriptableObject.
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int numberofEnemies = 5;
    [SerializeField] float moveSpeed = 2f;

    /* Kreiramo polja, kojima se vrednosti mogu dodeljivati direktno iz razvojnog okruženja Unity-ja.*/

    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }

    /* Kreiramo metodu GetEnemyPrefab, koja vraća objekat polja enemyPrefab.*/

    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();
        foreach(Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }    
        return waveWaypoints;
    }

    /* Kreiramo metodu tipa List<Transform>, GetWaypoints, u kojoj deklarisemo varijablu waveWaypoints i dodeljujemo joj vrednost putem konstruktora.
     Zatim, petljom foreach, prolazimo kroz pathPrefab.transform, i našoj varijabli dodajemo taj element. Na kraju metode, vraćamo vrednosti naše varijable waveWaypoints.*/

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    /* Kreiramo metodu tipa float, GetTimeBetweenSpawns, kojom vraćamo vrednost varijable timeBetweenSpawns, koju smo deklarisali kao SerializeField i uneli je u razvojnom okruženju.*/

    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    /* Kreiramo metodu tipa float, GetSpawnRandomFactor, kojom vraćamo vrednost varijable spawnRandomFactor, koju smo deklarisali kao SerializeField i uneli je u razvojnom okruženju.*/

    public int GetNumberOfEnemies()
    {
        return numberofEnemies;
    }

    /* Kreiramo metodu tipa int, GetNumberOfEnemies, kojom vraćamo vrednost varijable numberofEnemies, koju smo deklarisali kao SerializeField i uneli je u razvojnom okruženju.*/

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    /* Kreiramo metodu tipa float, GetMoveSpeed, kojom vraćamo vrednost varijable moveSpeed, koju smo deklarisali kao SerializeField i uneli je u razvojnom okruženju.*/
    
}

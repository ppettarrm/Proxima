using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    public static int score = 0;

    /* Definišemo polje klase.*/

    void Start()
    {
        SetUpSingleton();
    }

    /* U metodi start, pozivamo metodu SetUpSingleton.*/

    private void SetUpSingleton()
    {
        score = 0;
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;
        if(numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    /* Kreirali smo metodu SetUpSingleton, u kojoj postavljamo score na 0. Takođe, kreiramo novu varijablu i dajemo joj vrednost pomoću funkcije.
     Nakon toga, pitamo se da li je varijabla numberGameSessions veća od 1 i ukoliko jeste, uništavamo gameObject, a ukoliko nije, ne uništavamo gameObject na učitavanju.*/

    public int GetScore()
    {
        return score;
    }

    /* Kreirali smo metodu GetScore, pomoću koje šaljemo vrednost varijable score u klasu ScoreDisplay.*/

    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }

    /* Kreirali smo metodu AddToScore, koja sadrži argument scoreValue, tipa int, i u njoj povećavamo score za argument metode.*/

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    /* Kreirali smo metodu ResetGame, pomoću koje uništavamo gameObject, odnosno, restartujemo score igrača.*/

}

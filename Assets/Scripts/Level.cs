using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* Koristimo zaglavlja UnityEngine.UI i UnityEngine.SceneManagement.*/

public class Level : MonoBehaviour
{
    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    /* Kreirali smo metodu LoadStartMenu, u kojoj SceneManager prelazi na scenu sa indeksom 0, a to je StartMenu.*/

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
        FindObjectOfType<GameSession>().ResetGame();
    }

    /* Kreirali smo metodu LoadGame, u kojoj SceneManager prelazi na scenu sa indeksom 1, a to je Game. 
       Takođe, poziva metodu ResetGame iz klase GameSession, i restartuje score igrača.*/

    public void LoadGameOver()
    {
        SceneManager.LoadScene(2);
    }

    /* Kreirali smo metodu LoadGameOver, u kojoj SceneManager prelazi na scenu sa indeksom 2, a to je GameOver.*/

    public void QuitGame()
    {
        Application.Quit();
    }

    /* Kreirali smo metodu QuitGame, u kojoj pozivamo metodu Application.Quit, kojom se izlazi iz aplikacije.*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Ovde koristimo zaglavlje UnityEngine.UI, da bismo mogli da pristupimo UI kontroli Text.*/

public class HealthDisplay : MonoBehaviour
{
    Text HealthText;
    Player player;

    /* Kreiramo polja klase HealthText i player.*/

    void Start()
    {
        HealthText = GetComponent<Text>();
        player = FindObjectOfType<Player>();
    }

    /* U metodi Start dodeljujemo objekte kreiranim poljima.*/

    void Update()
    {
        HealthText.text = player.GetHealth().ToString();
    }

    /* U metodi Update UI kontroli HealthText dodeljujemo vrednost, tako što pozivamo metodu iz skripte Player.*/
}

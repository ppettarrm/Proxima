using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] float backgroundScrollSpeed = 0.5f;

    /* Kreiramo polje, kome se vrednost može dodeljivati direktno iz razvojnog okruženja Unity-ja.*/

    Material myMaterial;
    Vector2 offSet;

    // Kreiramo polja klase tipa Material i Vector2.

    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        offSet = new Vector2(0f, backgroundScrollSpeed);
    }

    /* U metodi Start, polju myMaterial dodeljujemo objekat, koji je zapravo naš background.
     Polju offSet dodeljujemo vrednost, pomoću konstruktora Vector2, kome prosleđujemo dva argumenta.
    Prvi argument je 0, jer ne pomeramo naš background horizontalno, a drugi je backgroundScrollSpeed, jer
    background pomeramo vertikalno.*/

    void Update()
    {
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
    }

    /* U metodi Update, podešavamo svojstvo myMateriala, tako što mu dodeljujemo vrednost našeg polja offSet pomnoženog sa vremenom osvežavanja ekrana.*/

}

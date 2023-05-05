using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 100;

    /* Kreirali smo polje, koje se može uneti direktno iz razvojnog okruženja, a defaultna vrednost mu je 100.*/

    public int GetDamage()
    {
        return damage;
    }

    /* Kreirali smo metodu GetDamage, koja vraća vrednost polja damage.*/

    public void Hit()
    {
        Destroy(gameObject);
    }

    /* Kreirali smo metodu Hit, koja uništava gameObject.*/
}

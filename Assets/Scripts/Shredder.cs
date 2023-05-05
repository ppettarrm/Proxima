using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }

    // Koristimo metodu OnTriggerEnter2D, koja ima argument collision, tipa collision, koja uništava objekat, kada uđe u collider objekta sa ovom skriptom.
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Drop drop;
    public GameObject Newstate;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            drop.drop();
            Instantiate(Newstate, transform.position, transform.rotation);
            Destroy(gameObject);
            
        }
    }
}

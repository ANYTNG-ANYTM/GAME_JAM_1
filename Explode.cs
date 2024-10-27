using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public GameObject explode;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("BOSS"))
        {
            Instantiate(explode,transform.position,transform.rotation);
            Destroy(gameObject);
        }
    }
}

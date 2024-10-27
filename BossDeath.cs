using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeath : MonoBehaviour
{
    public Transform firepoint1;
    public Transform firepoint2;    
    public Transform firepoint3;
    public Transform firepoint4;
    public Transform firepoint5;

    public GameObject BulletPrefab;
    public float timer;
    public GameObject death;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bomb"))
        {
            Instantiate(death,transform.position,transform.rotation); 
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3)
        {
            timer = 0;
            Shoot();
        }

        void Shoot()
        {
            Instantiate(BulletPrefab, firepoint1.position, firepoint1.rotation);
            Instantiate(BulletPrefab, firepoint2.position, firepoint2.rotation);
            Instantiate(BulletPrefab, firepoint3.position, firepoint3.rotation);
            Instantiate(BulletPrefab, firepoint4.position, firepoint4.rotation);
            Instantiate(BulletPrefab, firepoint5.position, firepoint5.rotation);
        }
    }
}

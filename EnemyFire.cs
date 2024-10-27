using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public Transform firepoint;

    public GameObject BulletPrefab;

    public float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2  )
        {
            timer = 0;  
            Shoot();
        }

        void Shoot()
        {
            Instantiate(BulletPrefab, firepoint.position, firepoint.rotation);
        }
    }
}

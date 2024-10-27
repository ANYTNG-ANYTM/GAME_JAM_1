using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Transform point1, point2;
    public float speed;
    Vector2 target;
    void Start()
    {
       target = point2.position;

    }

    // Update is called once per frame
    void Update()
    {
        

        if(Vector2.Distance(transform.position, point2.position) < 0.1f)
        {
            target = point1.position;
        }

        if (Vector2.Distance(transform.position, point1.position) < 0.1f)
        {
            target = point2.position;
        }

        transform.position = Vector2.MoveTowards(transform.position,target,speed*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}

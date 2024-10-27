using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{

    public GameObject bomb;
    public void drop()
    {
        Instantiate(bomb,transform.position,transform.rotation);
    }
    
}

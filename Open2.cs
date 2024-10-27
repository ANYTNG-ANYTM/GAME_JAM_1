using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open2 : MonoBehaviour
{
    public SwitchCheck open;

    private void Update()
    {
        if (open.check == 4)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{

    public SwitchCheck open;

    private void Update()
    {
        if (open.check == 3)
        {
            Destroy(gameObject);
        }
    }
}

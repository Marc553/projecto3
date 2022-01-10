using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyoutofbounds : MonoBehaviour

{
    private float sideLimit = -5f;
    void Update()
    {
        //Bala fallida
        if (transform.position.x < sideLimit)
        {
            Destroy(gameObject);
        }

    }
}

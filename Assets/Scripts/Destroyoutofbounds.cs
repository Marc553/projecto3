using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyoutofbounds : MonoBehaviour

{
    private float sideLimit = -5f;
    void Update()
    {
        //Valal fuera del limte
        if (transform.position.x < sideLimit)
        {
            Destroy(gameObject);
        }

    }
}

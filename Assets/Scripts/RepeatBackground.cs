using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//para que la repeticion del fondo funcione, se requiere la componente moveleft
[RequireComponent(typeof(MoveLeft))]
public class RepeatBackground : MonoBehaviour
{

    private Vector3 startPosition;
    public float reapeatWidth;

    void Start()
    {
        startPosition = transform.position;
        reapeatWidth = GetComponent<BoxCollider>().size.x / 2f;
    }
    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < startPosition.x - reapeatWidth)
        {
            transform.position = startPosition;
        }
    }
}

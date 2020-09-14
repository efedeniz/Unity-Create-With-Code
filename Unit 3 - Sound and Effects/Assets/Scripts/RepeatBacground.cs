using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBacground : MonoBehaviour
{
    private Vector3 offset;
    private float repeatWith;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position;
        repeatWith = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < offset.x - repeatWith)
        {
            transform.position = offset;
        }
    }
}

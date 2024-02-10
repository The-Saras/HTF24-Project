using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 7f;
    private Vector3 StartPosition ;
    void Start()
    {
        StartPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down*speed*Time.deltaTime);
        if(transform.position.y < -26.54f){
            transform.position = StartPosition;
        }
    }
}

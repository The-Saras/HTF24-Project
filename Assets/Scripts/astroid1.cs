using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astroid1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject explosion;
    public GameObject explosion1;
    public float downwardSpeed = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * downwardSpeed * Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("mis1"))
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
        if (other.gameObject.CompareTag("rocket"))
        {
            Destroy(gameObject);
            Instantiate(explosion1, transform.position, Quaternion.identity);
        }
        
    }
}

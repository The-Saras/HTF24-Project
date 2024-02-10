using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject bullet;

    public GameObject bullet1;
     public Transform firePoint;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Print a message when the left mouse button is clicked
            Instantiate(bullet,firePoint.position , transform.rotation);
        }
        if (Input.GetMouseButtonDown(1))
        {
            // Print a message when the left mouse button is clicked
            Instantiate(bullet1,firePoint.position , transform.rotation);
        }
    }
}

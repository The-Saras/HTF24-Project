using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20f;
	
	public Rigidbody2D rb;
	public float lifetime;
	// Use this for initialization
	void Start () {
		
		Invoke("Destroyme", 3);
		
	}
	private void Update() {
		rb.velocity = transform.up * speed;
	}
	void Destroyme()
    {
        Destroy(gameObject);
    }
}

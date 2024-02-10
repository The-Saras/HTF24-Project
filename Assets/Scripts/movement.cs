using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    public float moveSpeed;
    public int health = 5;
    public GameObject expl;
    // Start is called before the first frame update
    void Update()
    {
        if(health <= 0)
        {
            Invoke("RestartGame", 3f);
        }
        // Move player to the right if right arrow key is pressed
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        // Move player to the left if left arrow key is pressed
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("astr"))
        {

            health--;
        }

        if (other.gameObject.CompareTag("astr1"))
        {
            health--;
        }
        
    }
    void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       Instantiate (expl, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}

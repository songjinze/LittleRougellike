using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    private float speed = 0.1f;
    private Transform transform;
    private BoxCollider2D boxCollider2D;
    private Rigidbody2D rigidbody2D;
    public LayerMask blockingLayer;
    private int food;
    private int health;
	// Use this for initialization
	void Start () {
        transform = GetComponent<Transform>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        food = GameManager.instance.playerFoodPoint;
        health = GameManager.instance.playerHealthPoint;
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            food += 10;
            Destroy(other.gameObject);
        }
        else if (other.tag == "Soda")
        {
            health += 10;
            Destroy(other.gameObject);
        }
        else if (other.tag == "Exit")
        { 
            enabled = false;
            Restart();  
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update () {
        Vector3 vector3 = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            vector3 += new Vector3(0, 1, 0)*speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            vector3 += new Vector3(0, -1, 0)*speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            vector3 += new Vector3(-1, 0, 0)*speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            vector3 += new Vector3(1, 0, 0)*speed;
        }
        boxCollider2D.enabled = false;
        RaycastHit2D hit = Physics2D.Linecast(transform.position, transform.position + vector3, blockingLayer);
        boxCollider2D.enabled = true;
        if (hit.transform==null)
        {
       
            rigidbody2D.MovePosition(transform.position + vector3);
        }
        
    }
}

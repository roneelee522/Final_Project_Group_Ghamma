using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) 
        {
            //Destroy(gameObject);
            Debug.Log("You died");
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Bullet")
        {
            health = health - 1; 
            Debug.Log("Hi There");
        }
    }
}

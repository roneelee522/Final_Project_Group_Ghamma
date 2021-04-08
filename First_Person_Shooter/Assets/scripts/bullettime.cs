using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullettime : MonoBehaviour
{
    public Rigidbody rb;
    public int speed;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 2.0f);
        rb.AddForce(transform.forward * speed);
        rb.AddForce(transform.up * 2f, ForceMode.Impulse);

            if (collider.CompareTag("Enemy"))
            {
                Debug.Log("Enemy hit");
                DestroyProjectile();
                col.GetComponent<EnemyController>().TakeDamage(damage);
            }
    }

    void OnCollisionEnter(Collider col)
    {
        if (col.gameObject.tag == "Player"){
        Debug.Log("Hi there");
        }

        if(col.CompareTag("Player"))
        {
            col.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}

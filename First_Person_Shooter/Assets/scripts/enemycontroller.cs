using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemycontroller : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent nav;
    public float range;
    public Transform playerDistance;
    public GameObject enemyExplosion;
    public float explosionRange;
    public float health;
    CapsuleCollider enemyCol;
    private Animator animator = null;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        enemyCol = GetComponent<CapsuleCollider>();
        animator.SetBool("isRunning", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(playerDistance.position, transform.position) <= range)
        {
            nav.SetDestination(target.position);
            animator.SetBool("isRunning", true);
        }

        if (Vector3.Distance(playerDistance.position, transform.position) <= explosionRange)
        {

            Explode();
        }

    }

    void Explode()
    {
        enemyCol.radius = 12.0f;
        Instantiate(enemyExplosion, transform.position, transform.rotation);
        Destroy(gameObject, 0.2f);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0) Invoke(nameof(Death), 0.5f);
    }

    private void Death()
    {
        Instantiate(enemyExplosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}


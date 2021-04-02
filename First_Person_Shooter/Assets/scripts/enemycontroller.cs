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
  



    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(playerDistance.position, transform.position) <= range)
        {
            nav.SetDestination(target.position);
        }

        if (Vector3.Distance(playerDistance.position, transform.position) <= explosionRange)
        {
            Explode();
        }

    }

    void Explode()
    {
        Instantiate(enemyExplosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}


using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class navmeshseek : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;
    public Animator animator;
    private bool touchingEnemy;
    private bool startWalking = false;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        StartCoroutine(Walk());
    }

    // Update is called once per frame
    void Update()
    {
        if(startWalking)
        {
            agent.destination = target.transform.position;
            animator.SetBool("isWalking", true);

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Respawn")
        {
            animator.SetBool("isWalking", false);
            animator.SetTrigger("Attacking");
        }
    }

    IEnumerator Walk()
    {
        yield return new WaitForSeconds(2f);
        startWalking = true;
    }
}

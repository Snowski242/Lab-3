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
    [SerializeField]private int speed = 3;
    [SerializeField] private float animatorSpeed = 1;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        agent.speed = speed;
        animator.speed = animatorSpeed;

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
            animator.speed = 1;
            agent.speed = 0;
        }
    }

    IEnumerator Walk()
    {
        yield return new WaitForSeconds(2f);
        startWalking = true;
    }
}

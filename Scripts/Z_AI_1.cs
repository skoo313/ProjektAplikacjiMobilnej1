using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Z_AI_1 : MonoBehaviour
{
    NavMeshAgent nav;
    public Transform target;

    public enum ZombieState { idle, chase }
    public ZombieState state = ZombieState.idle;
    public float chaseDist = 10f;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        StartCoroutine(Think());
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Think()
    {
        while (true)
        {
            switch (state)
            {
                case ZombieState.idle:
                    float distance = Vector3.Distance(target.position, transform.position);
                    if (distance < chaseDist)
                    {
                        state = ZombieState.chase;
                        animator.SetBool("Chase", true);
                    }
                    nav.SetDestination(transform.position);
                    break;
                case ZombieState.chase:
                    distance = Vector3.Distance(target.position, transform.position);
                    if (distance > chaseDist)
                    {
                        state = ZombieState.idle;
                        animator.SetBool("Chase", false);
                    }
                    nav.SetDestination(target.position);
                    break;
                default:
                    break;

            }

            yield return new WaitForSeconds(0.2f);
        }
    }
}

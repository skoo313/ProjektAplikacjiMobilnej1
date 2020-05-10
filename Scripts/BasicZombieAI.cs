using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicZombieAI : MonoBehaviour
{
    NavMeshAgent nav;
    public Transform target;

    public enum ZombieState { idle, walk, chase, attack, die }
    public ZombieState state = ZombieState.idle;
    public float chaseDist = 10f;
    public float attackDist = 1f;
    int walkRadious;

    public int health = 100;

    public Animator animator;
    public playerStats player;

    Vector3 walkDest;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        StartCoroutine(Think());
        target = GameObject.FindWithTag("Player").transform;
        player = GameObject.FindObjectOfType<playerStats>();
        walkRadious = Random.Range(100,500);
        walkDest = RandomNavmeshLocation(walkRadious);
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        
        if (health <= 0)
        {
            GameplayController.instance.AddScore();
            Die();
        }
        else
            health -= damage;
    }

    void Die()
    {
        
        state = ZombieState.die;
        animator.SetBool("Dead", true);
        Destroy(gameObject, 1.5f);
    }

    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

    IEnumerator Think()
    {
        while (true)
        {
            if(state!=ZombieState.die)
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

                    int goSomewhere = Random.Range (0, 30);
                    
                    if(goSomewhere==1)
                    {
                            animator.SetBool("Chase", true);
                            state = ZombieState.walk;
                    }
                        

                    break;

                case ZombieState.walk:
                        distance = Vector3.Distance(target.position, transform.position);
                        if (distance < chaseDist)
                        {
                            state = ZombieState.chase;
                            animator.SetBool("Chase", true);
                            break;
                        }

                        if (transform.position==walkDest)
                        {
                            state = ZombieState.idle;
                            walkRadious = Random.Range(100, 500);
                        }
                        else
                            nav.SetDestination(RandomNavmeshLocation(walkRadious));

                        break;

                case ZombieState.chase:
                    distance = Vector3.Distance(target.position, transform.position);
                    if (distance > chaseDist)
                    {
                        state = ZombieState.idle;
                        animator.SetBool("Chase", false);
                    }
                    else if(distance<=attackDist)
                    {
                        state = ZombieState.attack;
                        animator.SetBool("Attack", true);
                    }
                    nav.SetDestination(target.position);
                    break;
                case ZombieState.attack:
                    player.TakeDamage(1);
                        yield return new WaitForSeconds(0.5f);
                        distance = Vector3.Distance(target.position, transform.position);
                    
                    if(distance > attackDist)
                    {
                        state = ZombieState.chase;
                        animator.SetBool("Attack", false);
                    }
                        if (distance > chaseDist)
                        {
                            state = ZombieState.idle;
                            animator.SetBool("Chase", false);
                            animator.SetBool("Attack", false);
                        }
                        break;

                default:
                    break;

            }

            yield return new WaitForSeconds(0.2f);
        }
    }
}

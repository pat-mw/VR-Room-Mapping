using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{

    NavMeshAgent zombieAgent;
    Animator zombieAnimator;


    [SerializeField] bool active = true;
    [SerializeField] float destinationRefreshTime = 1f;
    [SerializeField] float defaultZombieSpeed = 0.6f;
    [SerializeField] float health = 1f;
    [SerializeField] int zombieValue = 1;

    public Transform targetTransform;

    Vector3 targetPosition;
    private void Awake()
    { 
        zombieAgent = GetComponent<NavMeshAgent>();
        zombieAnimator = GetComponent<Animator>();
        targetPosition = targetTransform.position;
        zombieAgent.SetDestination(targetPosition);
        StartCoroutine("SlowUpdate");
    }


    private void OnEnable()
    {
        active = true;
        zombieAgent.gameObject.SetActive(true);
        zombieAgent.speed = defaultZombieSpeed;
        StartCoroutine("SlowUpdate");
    }

    private void OnDisable()
    {
        zombieAgent.speed = 0;
        zombieAgent.gameObject.SetActive(false);
        active = false;
    }

    private IEnumerator SlowUpdate()
    {
        while (active)
        {
            if (targetTransform.position != targetPosition)
            {
                //Debug.Log("reset destination");
                zombieAgent.SetDestination(targetTransform.position);
            }

            yield return new WaitForSeconds(destinationRefreshTime);
        }
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            ZombieDead();
        }
    }

    private void ZombieDead()
    {
        Score.Instance.AddScore(zombieValue);
        Destroy(this.gameObject);
    }
}

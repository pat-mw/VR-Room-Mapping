using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{

    NavMeshAgent zombieAgent;
    [SerializeField] bool active = true;
    [SerializeField] float destinationRefreshTime = 1f;
    [SerializeField] float defaultZombieSpeed = 0.6f;

    public Transform targetTransform;

    Vector3 targetPosition;
    private void Awake()
    { 
        zombieAgent = GetComponent<NavMeshAgent>();
        targetPosition = targetTransform.position;
        zombieAgent.SetDestination(targetPosition);
        StartCoroutine("SlowUpdate");
    }


    private void OnEnable()
    {
        active = true;
        zombieAgent.speed = defaultZombieSpeed;
        StartCoroutine("SlowUpdate");
    }

    private void OnDisable()
    {
        active = false;
        zombieAgent.speed = 0;
    }

    private IEnumerator SlowUpdate()
    {
        while (active)
        {
            if (targetTransform.position != targetPosition)
            {
                Debug.Log("reset destination");
                zombieAgent.SetDestination(targetTransform.position);
            }

            yield return new WaitForSeconds(destinationRefreshTime);
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private float health = 1.0f;
    [SerializeField] private float zombieDamage = 0.5f;
    [SerializeField] private float refreshTime = 0.1f;
    private bool _refreshing;

    private void OnCollisionEnter(Collision collision)
    {
        Collider other = collision.collider;
        Debug.Log("Collided");
        if (other.CompareTag("Zombie"))
        {
            if (!_refreshing)
            {
                TakeDamage(zombieDamage);
                StartCoroutine("Refresh", refreshTime);
            }
            
        }
    }

    IEnumerator Refresh(float time)
    {
        _refreshing = true;
        yield return new WaitForSeconds(time);
        _refreshing = false;
    }


    private void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        Health.Instance.AddHealth(-damageAmount);
        if (health <= 0)
        {
            PlayerDead();
        }
    }

    private void PlayerDead()
    {
        Destroy(this.gameObject);
    }
}

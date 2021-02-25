using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    [SerializeField] float damageAmount = 1f;
    [SerializeField] float maxBulletLifetime = 5f;

    private void Awake()
    {
        StartCoroutine("DestroyAfter", maxBulletLifetime);
    }

    IEnumerator DestroyAfter(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Zombie"))
        {
            collision.collider.GetComponent<Zombie>().TakeDamage(damageAmount);
            var hit = Instantiate(hitEffect);
            hit.transform.position = collision.GetContact(0).point;
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Rigidbody _bulletRB;
    public float receivedDamage;
    public float _damage;
    void Start()
    {
        _damage = receivedDamage;
        _bulletRB = gameObject.GetComponent<Rigidbody>();
        _bulletRB.AddForce(transform.forward * 3000f);
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.GetComponent<Rigidbody>())
        {
            var hp = collision.gameObject.GetComponent<Health>();
            hp.CurrentHealth -= _damage;
            Debug.Log($"Heath = {collision.gameObject.GetComponent<Health>().CurrentHealth}");
        }
        if(!collision.gameObject.CompareTag("Bullet"))
            Destroy(gameObject);
    }
}

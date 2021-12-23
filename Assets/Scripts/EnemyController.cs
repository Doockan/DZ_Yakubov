using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject Bullet;
    public float moveSpeed;
    public float Damage;
    public float shotCD;

    float _hp;
    float _shotTime;
    GameObject _firePoint;
    void Start()
    {
        _firePoint = gameObject.transform.GetChild(0).gameObject;
        _shotTime = shotCD;
    }
    void Update()
    {
        _shotTime += 1 * Time.deltaTime;

        _hp = transform.GetComponent<Health>().CurrentHealth;
        if (_hp <= 0)
        {
            Debug.Log("KILL");
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 target = other.transform.position;
            transform.LookAt(target);
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);


            if (_shotTime >= shotCD)
            {
                var bt = Instantiate(Bullet, _firePoint.transform.position, _firePoint.transform.rotation);
                var dm = bt.GetComponent<bullet>();
                dm.receivedDamage = Damage;

                _shotTime = 0f;
            }
        }
    }
}

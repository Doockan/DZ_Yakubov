using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float movementSpeed;
    public float force;
    public float Damage;
    public float shotCD;
    public GameObject bullet;

    float _shotTime;
    bool _isGround = false;
    Rigidbody _player;
    GameObject _firePoint;
    float _hp;



    void Start()
    {
        _player = GetComponent<Rigidbody>();
        _firePoint = gameObject.transform.GetChild(0).gameObject;
        _shotTime = shotCD;
    }

    void Update()
    {
        _hp = transform.GetComponent<Health>().CurrentHealth;
        if (_hp <= 0)
        {
            Time.timeScale = 0;
            Debug.Log("END");
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        transform.Translate(0, 0, vertical);
        float horizontal = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        transform.Translate(horizontal, 0, 0);


        if (Input.GetKey(KeyCode.Space) && _isGround)
        {
            _player.AddForce(Vector3.up * force);
            _isGround = false;
        }

        _shotTime += Time.deltaTime;
        if (Input.GetMouseButton(0) && _shotTime >= shotCD)
        {
            var bt = Instantiate(bullet, _firePoint.transform.position, _firePoint.transform.rotation);
            var dm = bt.GetComponent<bullet>();
            dm.receivedDamage = Damage;

            _shotTime = 0f;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            _isGround = true;
        }
    }
}

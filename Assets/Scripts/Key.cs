using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private DoorType Door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var k = other.GetComponent<Keys>();
            k.GiveKey(Door);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 20, Space.World);
    }
}

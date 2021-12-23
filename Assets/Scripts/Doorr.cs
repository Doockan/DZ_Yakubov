using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorr : MonoBehaviour
{
    [SerializeField] private DoorType Door;

    float _open;

    private void Start()
    {
        _open = transform.rotation.y;
        _open += -90f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var k = other.GetComponent<Keys>();
            if (k.HasKey(Door))
            {
                transform.rotation = Quaternion.Euler(0, _open, 0);
            }
        }
    }
}

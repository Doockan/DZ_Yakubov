using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public float Damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var hp = other.GetComponent<Health>();
            Debug.Log("BOOOOOM");
            hp.CurrentHealth -= Damage;
            Destroy(gameObject);
        }
    }
}

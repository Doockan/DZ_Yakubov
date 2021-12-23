using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject EnemyPrefab;
    [SerializeField] private Transform[] patrolPoints;
    void Start()
    {
        var e01 = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
        e01.GetComponent<Patrol>().Points = patrolPoints;
    }
}

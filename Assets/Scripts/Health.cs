using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float MaxHealth;
    
    [HideInInspector] public float CurrentHealth;
    
    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }
}

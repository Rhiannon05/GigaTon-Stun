using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{
    [SerializeField] private float _health;
    private Animator _anim;

    
    
    

    private float stunTime;
    public bool isStunned; 
    
    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    public void TakeDamage(float damage, float stunTimeR)
    {
        _health -= damage;
        if (stunTime < stunTimeR)
        {
            stunTime = stunTimeR; 
        }
        //flash white
        
    }

    private void Update()
    {
        ManageStun();
    }

    private void ManageStun()
    {
        if (stunTime > 0)
        {
            stunTime -= Time.deltaTime;
            isStunned = true;
        }
        else
        {
            isStunned = false; 
        }
        
        _anim.SetBool("IsHit", isStunned);
    }
}

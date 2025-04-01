using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{
    [SerializeField] private float _health;
    private Animator _anim;
    private PushManagement _push;



    private MoveScript _move;

    private float stunTime;
    public bool isStunned; 
    
    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _push = GetComponent<PushManagement>();
        _move = GetComponent<MoveScript>();
    }

    public void TakeDamage(float damage, float stunTimeR)
    {
        _health -= damage;
        if (stunTime < stunTimeR)
        {
            stunTime = stunTimeR; 
        }
        //flash white
        
        _push.Pushback(5);
        _move._isAttacking = false;
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

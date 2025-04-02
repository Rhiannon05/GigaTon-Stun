using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{
    [Header("health")]
    [SerializeField]  float _health, max_health = 100f;
    [SerializeField] HpBar hp;
    [SerializeField] GameObject fill;
    [Header("anim&push")]
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
        _health = max_health;
        hp = GetComponentInChildren<HpBar>();
        hp.UpdateBar(_health, max_health);
    }

    public void TakeDamage(float damage, float stunTimeR, float pushed)
    {
        _health -= damage;
        hp.UpdateBar(_health, max_health);
        if (stunTime < stunTimeR)
        {
            stunTime = stunTimeR; 
        }
        //flash white
        
        
        
        //This one hates me 
        _push.Pushback(pushed);

        if (_health <= 0)
        {
            fill.SetActive(false);
        }

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
            _move._isAttacking = false;
            isStunned = true;
        }
        else
        {
            isStunned = false; 
        }
        
        _anim.SetBool("IsHit", isStunned);
    }
}

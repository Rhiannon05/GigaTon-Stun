using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{
    [Header("health")]
    [SerializeField]  float _health, max_health = 100f;
    [SerializeField] MeterBar hp;
    [SerializeField] GameObject fill;
    [Header("anim&push")]
    private Animator _anim;
    private PushManagement _push;



    private MoveScript _move;

    public float stunTime;
    public bool isStunned; 
    
    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _push = GetComponent<PushManagement>();
        _move = GetComponent<MoveScript>();
        _health = max_health;
        hp = GetComponentInChildren<MeterBar>();
        hp.UpdateBar(_health, max_health);
    }

    public void TakeDamage(float damage, float stunTimeR, float pushed, bool launched)
    {

        if (_move.invulnerable) return;
        
        _health -= damage;
        hp.UpdateBar(_health, max_health);
        if (stunTime < stunTimeR)
        {
            stunTime = stunTimeR; 
        }
        //flash white

        if (!launched)
        {
            //This one hates me 
                    _push.Pushback(pushed);
        }
        else
        {
            //Launch player in the air
            _move.isLaunched = true;
        }
        
        

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
        if (_move.isLaunched) return;
        
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

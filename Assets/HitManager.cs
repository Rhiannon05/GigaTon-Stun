using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitManager : MonoBehaviour
{
    [Header("health")]
    [SerializeField]  float _health, max_health = 100f; //Health values
    [SerializeField] MeterBar hp;
    [SerializeField] GameObject fill;
    
    
    //References
    [Header("anim&push")]
    private Animator _anim;
    private PushManagement _push;
    private MoveScript _move;
   


    public float stunTime;
    public bool isStunned; 
    
    private void Start()
    {
        //Get appropriate references
        _anim = GetComponentInChildren<Animator>();
        _push = GetComponent<PushManagement>();
        _move = GetComponent<MoveScript>();
        hp = GetComponentInChildren<MeterBar>();
       
        
        //Set health to max health
        _health = max_health;
        
        
        hp.UpdateBar(_health, max_health);
    }

    //When damaged this method gets called
    public void TakeDamage(float damage, float stunTimeR, float pushed, bool launched)
    {
        //Ignore if invincible
        if (_move.invulnerable) return;
        
        //Take damage here
        _health -= damage;
        hp.UpdateBar(_health, max_health);
        
        //Timer fo rbeing stunned
        if (stunTime < stunTimeR)
        {
            stunTime = stunTimeR; 
        }
        

        if (!launched)
        {
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
            SceneManager.LoadScene("WinScreen");
        }

    }

    private void Update()
    {
        ManageStun();
    }

    private void ManageStun()
    {
        if (_move.isLaunched) return;
        
        //Timer for being stunned
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
        
        //Set animator 
        _anim.SetBool("IsHit", isStunned);
    }
}

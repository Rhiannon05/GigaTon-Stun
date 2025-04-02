using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxManager : MonoBehaviour
{


    private BoxCollider2D _hitBox;
    private MoveScript _move;
    private PushManagement _push; 
    private float damageDealt;
    private float stunDuration;

    private float pushback = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        _hitBox = GetComponent<BoxCollider2D>();
        _move = GetComponentInParent<MoveScript>();
        _push = GetComponentInParent<PushManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LightPunch()
    {
        _hitBox.offset = new Vector2(1.4f, 1.1f);
        _hitBox.size = new Vector2(6.1f, 3.6f);
        damageDealt = 5;
        stunDuration = 0.65f;
        pushback = 5;
        ActivateHitbox();
    }

    public void MediumPunch()
    {
        _hitBox.offset = new Vector2(0f, 0.9f);
        _hitBox.size = new Vector2(10.5f, 9.1f);
        damageDealt = 99;
        stunDuration = 0.85f;
        pushback = 22;
        ActivateHitbox();
    }

    public void OBLITERATIONKICK()
    {
        _hitBox.offset = new Vector2(4.6f, 0f);
        _hitBox.size = new Vector2(8.6f, 2.9f);
        damageDealt = 10;
        stunDuration = 1.3f;
        pushback = 45;
        ActivateHitbox();
    }
    
    private void ActivateHitbox()
    {
        
        _hitBox.enabled = true; 
    }

    public void DisableHitbox()
    {
        _hitBox.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player " + _move._opponentNumber))
        {
            HitManager _hitOpp = other.gameObject.GetComponent<HitManager>(); 
            
            _move.HitCOnfirmable();
            
            _hitOpp.TakeDamage(damageDealt, stunDuration, pushback);
            
            //This one works
            _push.Pushback(pushback);
            
        }
    }
}

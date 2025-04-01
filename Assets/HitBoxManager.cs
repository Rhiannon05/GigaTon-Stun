using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxManager : MonoBehaviour
{


    private BoxCollider2D _hitBox;
    private MoveScript _move;
    private float damageDealt;
    private float stunDuration;
    
    // Start is called before the first frame update
    void Start()
    {
        _hitBox = GetComponent<BoxCollider2D>();
        _move = GetComponentInParent<MoveScript>();
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
        stunDuration = 0.75f;
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
            
            
            _hitOpp.TakeDamage(damageDealt, stunDuration);
        }
    }
}

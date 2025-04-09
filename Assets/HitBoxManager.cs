using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitBoxManager : MonoBehaviour
{


    private BoxCollider2D _hitBox;
    private MoveScript _move;
    private PushManagement _push; 
    private float damageDealt;
    private float stunDuration;
    public float Meter, MaxMeter = 12;
    public Image SuperMeterBar;
    private float pushback = 0;
    private bool willLaunch;
    
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
        SuperMeterBar.fillAmount = Meter / MaxMeter;
    }

    public void LightPunch()
    {
        _hitBox.offset = new Vector2(1.04f, 1.1f);
        _hitBox.size = new Vector2(5.4f, 3.6f);
        damageDealt = 5;
        //meter += 1;
        stunDuration = 0.15f;
        pushback = 20;
        willLaunch = false;
        ActivateHitbox();
    }

    public void MediumPunch()
    {
        _hitBox.offset = new Vector2(-1f, 3f);
        _hitBox.size = new Vector2(8.6f, 5f);
        damageDealt = 99;
        //Meter += 2;
        stunDuration = 0.35f;
        pushback = 35;
        willLaunch = false;
        ActivateHitbox();
    }

    public void OBLITERATIONKICK()
    {
        _hitBox.offset = new Vector2(1.85f, 0f);
        _hitBox.size = new Vector2(3.1f, 2.9f);
        damageDealt = 10;
        //Meter += 3;
        stunDuration = 0.65f;
        pushback = 45;
        willLaunch = true;
        ActivateHitbox();
    }
    
    public void CouchingLight()
    {
        _hitBox.offset = new Vector2(1.1f, 1.3f);
        _hitBox.size = new Vector2(4.7f, 2f);
        damageDealt = 4;
        //Meter += 1;
        stunDuration = 0.3f;
        pushback = 20;
        willLaunch = false;
        ActivateHitbox();
    }
    
    public void CouchingMedium()
    {
        _hitBox.offset = new Vector2(1.8f, -1.9f);
        _hitBox.size = new Vector2(5.2f, 1.9f);
        damageDealt = 6;
        //Meter += 2;
        stunDuration = 0.65f;
        pushback = 15;
        willLaunch = false;
        ActivateHitbox();
    }
    
    public void CouchingHeavy()
    {
        _hitBox.offset = new Vector2(3.1f, 1.8f);
        _hitBox.size = new Vector2(2.7f, 4.1f);
        damageDealt = 20;
        //Meter += 3;
        stunDuration = 0.9f;
        pushback = 45;
        willLaunch = true;
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
            
            _hitOpp.TakeDamage(damageDealt, stunDuration, pushback, willLaunch);
            
            Meter += 2;

            //This one works
            _push.Pushback(pushback);
            
        }
    }
}

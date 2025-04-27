using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TinManHitBoxMNG : MonoBehaviour
{
    //References to components
    private BoxCollider2D _hitBox;
    private MoveScript _move;
    private PushManagement _push;

    //Attack properties
    private float damageDealt; //Damage of attack
    private float stunDuration; //Stun length
    public float Meter, MaxMeter = 12;
    public Image SuperMeterBar;
    private float pushback = 0; //Pushback of the attack
    private bool willLaunch; //If the attack will launch opponent

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
        //Every attack will have this setup with each one dealing different damages and stats
        _hitBox.offset = new Vector2(1.99f, 2.21f); //Set hitbox size
        _hitBox.size = new Vector2(5.2f, 3.7f); //Set hitbox size
        damageDealt = 5; //Set damage
        stunDuration = 0.15f; //Set stun
        pushback = 10; //Set pushback
        willLaunch = false; //Will launch?
        ActivateHitbox(); //Enable hitbox
    }

    public void MediumPunch()
    {
        _hitBox.offset = new Vector2(1.99f, 2.21f);
        _hitBox.size = new Vector2(5.2f, 3.7f);
        damageDealt = 8;
        stunDuration = 0.35f;
        pushback = 20;
        willLaunch = false;
        ActivateHitbox();
    }

    public void HeavyPunch()
    {
        _hitBox.offset = new Vector2(1.22f, 2.29f);
        _hitBox.size = new Vector2(3.7f, 1.7f);
        damageDealt = 10;
        stunDuration = 0.65f;
        pushback = 30;
        willLaunch = true;
        ActivateHitbox();
    }

    public void CouchingLight()
    {
        _hitBox.offset = new Vector2(1.1f, 1.3f);
        _hitBox.size = new Vector2(4.7f, 2f);
        damageDealt = 5;
        stunDuration = 0.3f;
        pushback = 20;
        willLaunch = false;
        ActivateHitbox();
    }

    public void CouchingMedium()
    {
        _hitBox.offset = new Vector2(1.8f, -1.9f);
        _hitBox.size = new Vector2(5.2f, 1.9f);
        damageDealt = 8;
        stunDuration = 0.65f;
        pushback = 15;
        willLaunch = false;
        ActivateHitbox();
    }

    public void CouchingHeavy()
    {
        _hitBox.offset = new Vector2(3.1f, 1.8f);
        _hitBox.size = new Vector2(2.7f, 4.1f);
        damageDealt = 10;
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

    //On collision with the other player do damage
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player " + _move._opponentNumber))
        {
            //Get other player
            HitManager _hitOpp = other.gameObject.GetComponent<HitManager>();

            //Allow hitconfirming
            _move.HitCOnfirmable();

            //Opponent takes damage
            _hitOpp.TakeDamage(damageDealt, stunDuration, pushback, willLaunch);

            //Gain meter
            Meter += 2;

            //This one works
            _push.Pushback(pushback);

        }
    }
}

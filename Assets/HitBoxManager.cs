using UnityEngine;
using UnityEngine.UI;

public class HitBoxManager : MonoBehaviour
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
        _hitBox.offset = new Vector2(1.04f, 1.1f); //Set hitbox size
        _hitBox.size = new Vector2(5.4f, 3.6f); //Set hitbox size
        damageDealt = 5; //Set damage
        stunDuration = 0.15f; //Set stun
        pushback = 10; //Set pushback
        willLaunch = false; //Will launch?
        ActivateHitbox(); //Enable hitbox
    }

    public void MediumPunch()
    {
        _hitBox.offset = new Vector2(-1f, 3f);
        _hitBox.size = new Vector2(8.6f, 5f);
        damageDealt = 8;
        stunDuration = 0.35f;
        pushback = 20;
        willLaunch = false;
        ActivateHitbox();
    }

    public void HeavyPunch()
    {
        _hitBox.offset = new Vector2(1.85f, 0f);
        _hitBox.size = new Vector2(3.1f, 2.9f);
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

    public void TinManLight()
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

    public void TinManMedium()
    {
        _hitBox.offset = new Vector2(1.99f, 2.21f);
        _hitBox.size = new Vector2(5.2f, 3.7f);
        damageDealt = 8;
        stunDuration = 0.35f;
        pushback = 20;
        willLaunch = false;
        ActivateHitbox();
    }

    public void TinManHeavy()
    {
        _hitBox.offset = new Vector2(1.22f, 2.29f);
        _hitBox.size = new Vector2(3.7f, 1.7f);
        damageDealt = 10;
        stunDuration = 0.65f;
        pushback = 30;
        willLaunch = true;
        ActivateHitbox();
    }

    public void TinManCL()
    {
        _hitBox.offset = new Vector2(1.1f, 1.3f);
        _hitBox.size = new Vector2(4.7f, 2f);
        damageDealt = 5;
        stunDuration = 0.3f;
        pushback = 20;
        willLaunch = false;
        ActivateHitbox();
    }

    public void TinManCM()
    {
        _hitBox.offset = new Vector2(1.8f, -1.9f);
        _hitBox.size = new Vector2(5.2f, 1.9f);
        damageDealt = 8;
        stunDuration = 0.65f;
        pushback = 15;
        willLaunch = false;
        ActivateHitbox();
    }

    public void TinManCH()
    {
        _hitBox.offset = new Vector2(3.1f, 1.8f);
        _hitBox.size = new Vector2(2.7f, 4.1f);
        damageDealt = 10;
        stunDuration = 0.9f;
        pushback = 45;
        willLaunch = true;
        ActivateHitbox();
    }

    public void AbsoLight()
    {
        //Every attack will have this setup with each one dealing different damages and stats
        _hitBox.offset = new Vector2(1.31f, 1.95f); //Set hitbox size
        _hitBox.size = new Vector2(3.54f, 1.27f); ; //Set hitbox size
        damageDealt = 5; //Set damage
        stunDuration = 0.15f; //Set stun
        pushback = 10; //Set pushback
        willLaunch = false; //Will launch?
        ActivateHitbox(); //Enable hitbox
    }

    public void AbsoMedium()
    {
        _hitBox.offset = new Vector2(1.31f, 1.95f);
        _hitBox.size = new Vector2(3.54f, 1.27f);
        damageDealt = 8;
        stunDuration = 0.35f;
        pushback = 20;
        willLaunch = false;
        ActivateHitbox();
    }

    public void AbsoHeavy()
    {
        _hitBox.offset = new Vector2(1.31f, 1.95f);
        _hitBox.size = new Vector2(3.54f, 1.27f);
        damageDealt = 10;
        stunDuration = 0.65f;
        pushback = 30;
        willLaunch = true;
        ActivateHitbox();
    }

    public void AbsoCL()
    {
        _hitBox.offset = new Vector2(1.31f, 1.95f);
        _hitBox.size = new Vector2(3.54f, 1.40f);
        damageDealt = 5;
        stunDuration = 0.3f;
        pushback = 20;
        willLaunch = false;
        ActivateHitbox();
    }

    public void AbsoCM()
    {
        _hitBox.offset = new Vector2(1.31f, 1.95f);
        _hitBox.size = new Vector2(3.54f, 1.40f);
        damageDealt = 8;
        stunDuration = 0.65f;
        pushback = 15;
        willLaunch = false;
        ActivateHitbox();
    }

    public void AbsoCH()
    {
        _hitBox.offset = new Vector2(1.31f, 1.95f);
        _hitBox.size = new Vector2(3.54f, 1.40f);
        damageDealt = 10;
        stunDuration = 0.9f;
        pushback = 45;
        willLaunch = true;
        ActivateHitbox();
    }

    public void WernerLight()
    {
        //Every attack will have this setup with each one dealing different damages and stats
        _hitBox.offset = new Vector2(1.69f, 1.64f); //Set hitbox size
        _hitBox.size = new Vector2(3.30f, 1.90f); ; //Set hitbox size
        damageDealt = 8; //Set damage
        stunDuration = 0.15f; //Set stun
        pushback = 10; //Set pushback
        willLaunch = false; //Will launch?
        ActivateHitbox(); //Enable hitbox
    }

    public void WernerMedium()
    {
        _hitBox.offset = new Vector2(1.69f, 1.64f); 
        _hitBox.size = new Vector2(3.30f, 1.90f); ; 
        damageDealt = 10;
        stunDuration = 0.35f;
        pushback = 20;
        willLaunch = false;
        ActivateHitbox();
    }

    public void WernerHeavy()
    {
        _hitBox.offset = new Vector2(1.69f, 1.64f); 
        _hitBox.size = new Vector2(3.30f, 1.90f); ; 
        damageDealt = 12;
        stunDuration = 0.65f;
        pushback = 30;
        willLaunch = true;
        ActivateHitbox();
    }

    public void WernerCL()
    {
        _hitBox.offset = new Vector2(1.69f, 0.68f); 
        _hitBox.size = new Vector2(3.30f, 1.30f); ; 
        damageDealt = 8;
        stunDuration = 0.3f;
        pushback = 20;
        willLaunch = false;
        ActivateHitbox();
    }

    public void WernerCM()
    {
        _hitBox.offset = new Vector2(1.69f, 0.68f); 
        _hitBox.size = new Vector2(3.30f, 1.30f); ; 
        damageDealt = 10;
        stunDuration = 0.65f;
        pushback = 15;
        willLaunch = false;
        ActivateHitbox();
    }

    public void WernerCH()
    {
        _hitBox.offset = new Vector2(1.69f, 0.68f); 
        _hitBox.size = new Vector2(3.30f, 1.30f); ; 
        damageDealt = 12;
        stunDuration = 0.9f;
        pushback = 45;
        willLaunch = true;
        ActivateHitbox();
    }

    public void FeatherLight()
    {
        //Every attack will have this setup with each one dealing different damages and stats
        _hitBox.offset = new Vector2(1.06f, 0.88f); //Set hitbox size
        _hitBox.size = new Vector2(2.86f, 1.18f); ; //Set hitbox size
        damageDealt = 2; //Set damage
        stunDuration = 0.15f; //Set stun
        pushback = 10; //Set pushback
        willLaunch = false; //Will launch?
        ActivateHitbox(); //Enable hitbox
    }

    public void FeatherMedium()
    {
        _hitBox.offset = new Vector2(1.86f, 0.88f);
        _hitBox.size = new Vector2(2.86f, 1.18f);
        damageDealt = 5;
        stunDuration = 0.35f;
        pushback = 20;
        willLaunch = false;
        ActivateHitbox();
    }

    public void FeatherHeavy()
    {
        _hitBox.offset = new Vector2(1.86f, 0.88f);
        _hitBox.size = new Vector2(2.86f, 1.18f);
        damageDealt = 7;
        stunDuration = 0.65f;
        pushback = 30;
        willLaunch = true;
        ActivateHitbox();
    }

    public void FeatherCL()
    {
        _hitBox.offset = new Vector2(1.06f, -0.33f);
        _hitBox.size = new Vector2(2.86f, 1.36f);
        damageDealt = 2;
        stunDuration = 0.3f;
        pushback = 20;
        willLaunch = false;
        ActivateHitbox();
    }

    public void FeatherCM()
    {
        _hitBox.offset = new Vector2(1.06f, -0.33f);
        _hitBox.size = new Vector2(2.86f, 1.36f);
        damageDealt = 5;
        stunDuration = 0.65f;
        pushback = 15;
        willLaunch = false;
        ActivateHitbox();
    }

    public void FeatherCH()
    {
        _hitBox.offset = new Vector2(1.06f, -0.33f);
        _hitBox.size = new Vector2(2.86f, 1.36f);
        damageDealt = 7;
        stunDuration = 0.9f;
        pushback = 45;
        willLaunch = true;
        ActivateHitbox();
    }

    public void SpecialLightPunch()
    {
        Debug.Log("Special Light Hitbox Activated"); // Debug log
        _hitBox.offset = new Vector2(2.0f, 2.0f); // Example values - adjust as needed
        _hitBox.size = new Vector2(6.0f, 4.0f);   // Example values - adjust as needed
        damageDealt = 15; // Example damage
        stunDuration = 0.5f; // Example stun duration
        pushback = 25; // Example pushback
        willLaunch = false; // Example launch property
        Meter -= 4;
        ActivateHitbox();
    }

    // Special Medium Attack Hitbox Properties
    public void SpecialMediumPunch()
    {
        Debug.Log("Special Medium Hitbox Activated"); // Debug log
        _hitBox.offset = new Vector2(2.5f, 3.0f); // Example values - adjust as needed
        _hitBox.size = new Vector2(7.0f, 5.0f);   // Example values - adjust as needed
        damageDealt = 20; // Example damage
        stunDuration = 0.7f; // Example stun duration
        pushback = 35; // Example pushback
        willLaunch = true; // Example launch property
        Meter -= 6;
        ActivateHitbox();
    }

    // Special Heavy Attack Hitbox Properties
    public void SpecialHeavyPunch()
    {
        Debug.Log("Special Heavy Hitbox Activated"); // Debug log
        _hitBox.offset = new Vector2(3.0f, 1.0f); // Example values - adjust as needed
        _hitBox.size = new Vector2(8.0f, 6.0f);   // Example values - adjust as needed
        damageDealt = 25; // Example damage
        stunDuration = 1.0f; // Example stun duration
        pushback = 50; // Example pushback
        willLaunch = true; // Example launch property
        Meter -= 8;
        ActivateHitbox();
    }

    public void AbsoSpecialLightPunch()
    {
        Debug.Log("Special Light Hitbox Activated"); // Debug log
        _hitBox.offset = new Vector2(1.3f, 2.0f); // Example values - adjust as needed
        _hitBox.size = new Vector2(4.0f, 2.5f);   // Example values - adjust as needed
        damageDealt = 15; // Example damage
        stunDuration = 0.5f; // Example stun duration
        pushback = 25; // Example pushback
        willLaunch = false; // Example launch property
        Meter -= 4;
        ActivateHitbox();
    }

    // Special Medium Attack Hitbox Properties
    public void AbsoSpecialMediumPunch()
    {
        Debug.Log("Special Medium Hitbox Activated"); // Debug log
        _hitBox.offset = new Vector2(-0.5f, 3.0f); // Example values - adjust as needed
        _hitBox.size = new Vector2(3.0f, 1.4f);   // Example values - adjust as needed
        damageDealt = 20; // Example damage
        stunDuration = 0.7f; // Example stun duration
        pushback = 35; // Example pushback
        willLaunch = true; // Example launch property
        Meter -= 6;
        ActivateHitbox();
    }

    // Special Heavy Attack Hitbox Properties
    public void AbsoSpecialHeavyPunch()
    {
        Debug.Log("Special Heavy Hitbox Activated"); // Debug log
        _hitBox.offset = new Vector2(0.5f, 3.0f); // Example values - adjust as needed
        _hitBox.size = new Vector2(2.0f, 3.0f);   // Example values - adjust as needed
        damageDealt = 25; // Example damage
        stunDuration = 1.0f; // Example stun duration
        pushback = 50; // Example pushback
        willLaunch = true; // Example launch property
        Meter -= 8;
        ActivateHitbox();
    }

    // Special Light Attack Hitbox Properties
    public void TinmanSpecialLightPunch()
    {
        Debug.Log("Special Light Hitbox Activated"); // Debug log
        _hitBox.offset = new Vector2(2.0f, 2.4f); // Example values - adjust as needed
        _hitBox.size = new Vector2(5.0f, 2.0f);   // Example values - adjust as needed
        damageDealt = 18; // Example damage
        stunDuration = 0.5f; // Example stun duration
        pushback = 25; // Example pushback
        willLaunch = false; // Example launch property
        Meter -= 4;
        ActivateHitbox();
    }

    // Special Medium Attack Hitbox Properties
    public void TinmanSpecialMediumPunch()
    {
        Debug.Log("Special Medium Hitbox Activated"); // Debug log
        _hitBox.offset = new Vector2(2.0f, 3.0f); // Example values - adjust as needed
        _hitBox.size = new Vector2(5.0f, 2.0f);   // Example values - adjust as needed
        damageDealt = 23; // Example damage
        stunDuration = 0.7f; // Example stun duration
        pushback = 35; // Example pushback
        willLaunch = true; // Example launch property
        Meter -= 6;
        ActivateHitbox();
    }

    // Special Heavy Attack Hitbox Properties
    public void TinmanSpecialHeavyPunch()
    {
        Debug.Log("Special Heavy Hitbox Activated"); // Debug log
        _hitBox.offset = new Vector2(2.0f, -0.2f); // Example values - adjust as needed
        _hitBox.size = new Vector2(6.0f, 2.0f);   // Example values - adjust as needed
        damageDealt = 28; // Example damage
        stunDuration = 1.0f; // Example stun duration
        pushback = 50; // Example pushback
        willLaunch = true; // Example launch property
        Meter -= 8;
        ActivateHitbox();
    }

    public void WernerSpecialLightPunch()
    {
        Debug.Log("Special Light Hitbox Activated"); // Debug log
        _hitBox.offset = new Vector2(0.03f, 0.48f); // Example values - adjust as needed
        _hitBox.size = new Vector2(6.63f, 7.69f);   // Example values - adjust as needed
        damageDealt = 20; // Example damage
        stunDuration = 0.5f; // Example stun duration
        pushback = 25; // Example pushback
        willLaunch = false; // Example launch property
        Meter -= 4;
        ActivateHitbox();
    }

    // Special Medium Attack Hitbox Properties
    public void WernerSpecialMediumPunch()
    {
        Debug.Log("Special Medium Hitbox Activated"); 
        _hitBox.offset = new Vector2(1.25f, 1.57f); 
        _hitBox.size = new Vector2(4.18f, 3.13f);   
        damageDealt = 25; // Example damage
        stunDuration = 0.7f; // Example stun duration
        pushback = 35; // Example pushback
        willLaunch = true; // Example launch property
        Meter -= 6;
        ActivateHitbox();
    }

    // Special Heavy Attack Hitbox Properties
    public void WernerSpecialHeavyPunch()
    {
        Debug.Log("Special Heavy Hitbox Activated"); // Debug log
        _hitBox.offset = new Vector2(-0.37f, 1.82f); // Example values - adjust as needed
        _hitBox.size = new Vector2(4.37f, 4.95f);   // Example values - adjust as needed
        damageDealt = 30; // Example damage
        stunDuration = 1.0f; // Example stun duration
        pushback = 50; // Example pushback
        willLaunch = true; // Example launch property
        Meter -= 8;
        ActivateHitbox();
    }

    public void FeatherSpecialLightPunch()
    {
        Debug.Log("Special Light Hitbox Activated"); // Debug log
        _hitBox.offset = new Vector2(1.63f, 0.90f); // Example values - adjust as needed
        _hitBox.size = new Vector2(4.00f, 0.93f);   // Example values - adjust as needed
        damageDealt = 10; // Example damage
        stunDuration = 0.5f; // Example stun duration
        pushback = 25; // Example pushback
        willLaunch = false; // Example launch property
        Meter -= 4;
        ActivateHitbox();
    }

    // Special Medium Attack Hitbox Properties
    public void FeatherSpecialMediumPunch()
    {
        Debug.Log("Special Medium Hitbox Activated"); // Debug log
        _hitBox.offset = new Vector2(1.63f, 0.90f); // Example values - adjust as needed
        _hitBox.size = new Vector2(4.00f, 0.93f);   // Example values - adjust as needed
        damageDealt = 15; // Example damage
        stunDuration = 0.7f; // Example stun duration
        pushback = 35; // Example pushback
        willLaunch = true; // Example launch property
        Meter -= 6;
        ActivateHitbox();
    }

    // Special Heavy Attack Hitbox Properties
    public void FeatherSpecialHeavyPunch()
    {
        Debug.Log("Special Heavy Hitbox Activated"); // Debug log
        _hitBox.offset = new Vector2(1.63f, 0.90f); // Example values - adjust as needed
        _hitBox.size = new Vector2(4.00f, 0.93f);   // Example values - adjust as needed
        damageDealt = 20; // Example damage
        stunDuration = 1.0f; // Example stun duration
        pushback = 50; // Example pushback
        willLaunch = true; // Example launch property
        Meter -= 8;
        ActivateHitbox();
    }

    // Super Attack Hitbox Properties
    public void AbsoSuperAttack()
    {
        Debug.Log("Super Attack Hitbox Activated"); 
        _hitBox.offset = new Vector2(0f, 0f); 
        _hitBox.size = new Vector2(10f, 10f); 
        damageDealt = 40; 
        stunDuration = 2.0f;
        pushback = 100; 
        willLaunch = true; 
        Meter -= 10;
        ActivateHitbox();
    }

    public void TinManSuperAttack()
    {
        Debug.Log("Super Attack Hitbox Activated");
        _hitBox.offset = new Vector2(0f, 0f);
        _hitBox.size = new Vector2(10f, 10f);
        damageDealt = 50;
        stunDuration = 2.0f;
        pushback = 100;
        willLaunch = true;
        Meter -= 10;
        ActivateHitbox();
    }

    public void FeatherSuperAttack()
    {
        Debug.Log("Super Attack Hitbox Activated");
        _hitBox.offset = new Vector2(0f, 0f);
        _hitBox.size = new Vector2(10f, 10f);
        damageDealt = 35;
        stunDuration = 2.0f;
        pushback = 100;
        willLaunch = true;
        Meter -= 10;
        ActivateHitbox();
    }

    public void WernerSuperAttack()
    {
        Debug.Log("Super Attack Hitbox Activated");
        _hitBox.offset = new Vector2(0f, 0f);
        _hitBox.size = new Vector2(10f, 10f);
        damageDealt = 60;
        stunDuration = 2.0f;
        pushback = 100;
        willLaunch = true;
        Meter -= 10;
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

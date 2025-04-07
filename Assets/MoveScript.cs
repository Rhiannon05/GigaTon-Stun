using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer _playerSprite;
    private Animator _anim;
    private Rigidbody2D _rb;
    [SerializeField] private GameObject _otherPlayer;
    private HitManager _hit;
    private HitBoxManager _hitBox;

    [Header("Crouching")] private bool isCrouching;
    
    
    [Header("Walking ")]
    private bool _walking = false;
    private bool _backWalking = false;
    [SerializeField] private float _playerSpeed;
    
    [Header("Input")]
    [SerializeField] private float _playerHorizontal;
    [SerializeField] private float _playerVertical;
    public bool _isAttacking = false;

    [Header("Attack Info")] public bool canInput;
    [SerializeField] private int attackStrength;
    [SerializeField] private bool inputBuffer = false;
    [SerializeField] private bool hitConfirm = false;
    
    [Header("PlayerData")]
    [SerializeField] private int _playerNumber;
    public int _opponentNumber;
    public bool _otherPlayerIsToTheRight;


    [Header("Disadvantage State")] public bool isLaunched = false;
    public bool invulnerable;
    
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _walking = true;
        _rb = GetComponent<Rigidbody2D>();
        _hit = GetComponent<HitManager>();
        _hitBox = GetComponentInChildren<HitBoxManager>();
        
        if (_playerNumber == 1)
        {
            _opponentNumber = 2;
        } else if (_playerNumber == 2)
        {
            _opponentNumber = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {

       Movement();
       Attacking();

       ManageOrientation();
       GetOpponentPosition();


       Crouching();
       LaunchManager();
    }

    public void LaunchManager()
    {
       //Play animation of being launched
       //Become intangible during launch
       _anim.SetBool("isLaunched", isLaunched);
    }
    
    private void Crouching()
    {
        if (_playerNumber == 1)
        {
            _playerVertical = Input.GetAxisRaw("Vertical " + _playerNumber);
        }
        else
        {
            _playerVertical = Input.GetAxis("Vertical " + _playerNumber);
        }

        Debug.Log(_playerVertical + " Gameobject; " + gameObject);

        if (_playerVertical < 0)
        {
            //Crouching

            isCrouching = true;

        }
        else
        {
            isCrouching = false;
        }
        
        _anim.SetBool("isCrouching", isCrouching);
    }
    
    private void GetOpponentPosition()
    {
        if (_otherPlayer.gameObject.transform.position.x > transform.position.x)
        {
            //Other player is to the right
            _otherPlayerIsToTheRight = true;
        }
        else
        {
            _otherPlayerIsToTheRight = false; 
            
        }
    }
    

    private void ManageOrientation()
    {
        var pos = _otherPlayer.transform.position;

        if (pos.x > transform.position.x)
        {
            //Other player is to the left

            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            //other player is to the right
            
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void Movement()
    {
        _anim.SetBool("Walking", _walking);
        _anim.SetBool("BackWalk", _backWalking);
        
        if (_isAttacking || _hit.isStunned)
        {
            return;
        }
        
         if (_playerNumber == 1)
         {
             _playerHorizontal = Input.GetAxisRaw("Horizontal " + _playerNumber);
         }
         else
         {
             _playerHorizontal = Input.GetAxis("Horizontal " + _playerNumber);
         }
         
         //crouching
         
         
         
         if (_playerHorizontal > 0)
         {
             //Right



             if (_otherPlayerIsToTheRight)
             {
                 _walking = true;
                 _backWalking = false;
             }
             else
             {
                 _backWalking = true;
                 _walking = false;
             }
             
             
             //_playerSprite.flipX = false;
                    
             _rb.velocity = new Vector2(_playerSpeed, 0);
         } 
         else if (_playerHorizontal <  0)
         { 
             _walking = true;
        
             //_playerSprite.flipX = true;
        
             if (!_otherPlayerIsToTheRight)
             {
                 _walking = true;
                 _backWalking = false;
             }
             else
             {
                 _backWalking = true;
                 _walking = false;
             }
             
             
             
             
             _rb.velocity = new Vector2(-_playerSpeed, 0);
         }
         else
         { 
             _walking = false;
             _backWalking = false;       
             
             StopMovement();
         }
    }

    private void StopMovement()
    {
        //_rb.velocity = new Vector2(0, 0);
        _walking = false; 
        _backWalking = false;
    }
    
    private void Attacking()
    {
        _anim.SetBool("isAttacking", _isAttacking);
        _anim.SetBool("CanInput", canInput);
        
        if (!_isAttacking)
        {
            canInput = true; 
        }
        
        if ((_isAttacking && !inputBuffer) || _hit.isStunned) return;
        
        if (Input.GetButtonDown("Light " + _playerNumber))
        {

              
            
              _hitBox.DisableHitbox();
              _anim.SetTrigger("LightAttack");
              attackStrength = 1;
              canInput = false;
              inputBuffer = false;
        }

        if (Input.GetButtonDown("Medium " + _playerNumber))
        {
            if (hitConfirm && attackStrength < 2)
            {
                canInput = true;
                _anim.SetBool("CanInput", canInput);
            }
            
            _hitBox.DisableHitbox();
            _anim.SetTrigger("MediumAttack");
            attackStrength = 2;
            canInput = false;
            inputBuffer = false;
        }
        
        if (Input.GetButtonDown("Heavy " + _playerNumber))
        {
            if (hitConfirm && attackStrength < 3)
            {
                canInput = true;
                _anim.SetBool("CanInput", canInput);
            }
            
            _hitBox.DisableHitbox();
            _anim.SetTrigger("HeavyAttack");
            attackStrength = 3;
            canInput = false;
            inputBuffer = false;
        }
    }

    public void AttackEnded()
    {
        _isAttacking = false;
        attackStrength = 0;
        hitConfirm = false;
    }

    public void AttackStarted()
    {
        
        _isAttacking = true;
        canInput = false;
        StopMovement();
        
    }

    public void Buffer()
    {
        inputBuffer = true; 
    }

    public void HitCOnfirmable()
    {
        hitConfirm = true;
        inputBuffer = true;
    }
}

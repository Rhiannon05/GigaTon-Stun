using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class MoveScript : MonoBehaviour
{

    [SerializeField] private SpriteRenderer _playerSprite;
    private Animator _anim;
    private bool _walking = false;
    [SerializeField] private float _playerSpeed;

    private Rigidbody2D _rb;


    [SerializeField] private float _playerHorizontal;
    [SerializeField] private float _playerVertical;
    

    private bool _isAttacking = false;

    [SerializeField] private int _playerNumber;

    public int _opponentNumber;


    [SerializeField] private GameObject _otherPlayer;


    private HitManager _hit;
    
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _walking = true;
        _rb = GetComponent<Rigidbody2D>();
        _hit = GetComponent<HitManager>();
        
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
        if (_isAttacking) return; 
        
         _anim.SetBool("Walking", _walking);

         if (_playerNumber == 1)
         {
             _playerHorizontal = Input.GetAxisRaw("Horizontal " + _playerNumber);
         }
         else
         {
             _playerHorizontal = Input.GetAxis("Horizontal " + _playerNumber);
         }
         
         
         if (_playerHorizontal > 0)
         {
             //Forward
             _walking = true;
             //_playerSprite.flipX = false;
                    
             _rb.velocity = new Vector2(_playerSpeed, 0);
         } 
         else if (_playerHorizontal <  0)
         { 
             _walking = true;
        
             //_playerSprite.flipX = true;
        
             _rb.velocity = new Vector2(-_playerSpeed, 0);
         }
         else
         { 
             _walking = false;
                    
             StopMovement();
         }
    }

    private void StopMovement()
    {
        _rb.velocity = new Vector2(0, 0);
    }
    
    private void Attacking()
    {
        _anim.SetBool("isAttacking", _isAttacking);
        
        if (Input.GetButtonDown("Light " + _playerNumber))
        {
              _anim.SetTrigger("LightAttack");
              
        }

        if (Input.GetButtonDown("Medium " + _playerNumber))
        {
            _anim.SetTrigger("MediumAttack");
        }
        
        if (Input.GetButtonDown("Heavy " + _playerNumber))
        {
            _anim.SetTrigger("HeavyAttack");
        }
    }

    public void AttackEnded()
    {
        _isAttacking = false;
    }

    public void AttackStarted()
    {
        StopMovement();
        _isAttacking = true;
    }
}

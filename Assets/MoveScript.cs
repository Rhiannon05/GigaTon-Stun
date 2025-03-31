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
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _walking = true;
        _rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {

       Movement();
       Attacking();
       
    }

    private void Movement()
    {
        if (_isAttacking) return; 
        
         _anim.SetBool("Walking", _walking);


         _playerHorizontal = Input.GetAxis("Horizontal " + _playerNumber);
         
         if (_playerHorizontal > 0)
         {
             //Forward
             _walking = true;
             _playerSprite.flipX = false;
                    
             _rb.velocity = new Vector2(_playerSpeed, 0);
         } 
         else if (_playerHorizontal <  0)
         { 
             _walking = true;
        
             _playerSprite.flipX = true;
        
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

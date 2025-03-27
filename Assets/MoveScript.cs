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

        _anim.SetBool("Walking", _walking);
        
        if (Input.GetKey(KeyCode.D))
        {
            //Forward 
            _walking = true;
            
            _playerSprite.flipX = false;
            
            _rb.velocity = new Vector2(_playerSpeed, 0);
        } 
        else if (Input.GetKey(KeyCode.A))
        {
            _walking = true;

            _playerSprite.flipX = true;

            _rb.velocity = new Vector2(-_playerSpeed, 0);
        }
        else
        {
            _walking = false;
            
            _rb.velocity = new Vector2(0, 0);
        }
    }
}

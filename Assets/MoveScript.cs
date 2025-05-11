using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer _playerSprite; //The character sprite
    private Animator _anim; //Animator reference
    private Rigidbody2D _rb; //Rigidbofy reference
    [SerializeField] private GameObject _otherPlayer; //Reference to the other player (this is so the sprite will automatically become the correct orientation)
    private HitManager _hit; //Hitbox manager ref
    private HitBoxManager _hitBox; //More manager

    [Header("Crouching")] private bool isCrouching; //Bool for crouching


    [Header("Walking ")] //Bools for direction player is walking
    private bool _walking = false;
    private bool _backWalking = false;
    [SerializeField] private float _playerSpeed;

    [Header("Input")]
    [SerializeField] private float _playerHorizontal; //L/R movement
    [SerializeField] private float _playerVertical; //Crouch detection
    public bool _isAttacking = false;

    [Header("Attack Info")] public bool canInput; //The player can press a button and perform an action
    [SerializeField] private int attackStrength; //Moves can be canceled into moves with higher attack strengths, by pressing the a higher attack strength button
    [SerializeField] private bool inputBuffer = false; //When true the player can press a button and have it register
    [SerializeField] private bool hitConfirm = false; //When true the player can press a button on hit to do another button

    [Header("PlayerData")] //Info about which player has which ID
    [SerializeField] private int _playerNumber;
    public int _opponentNumber;
    public bool _otherPlayerIsToTheRight;

    //Stats that manage whether the player is launched and/or invincible
    [Header("Disadvantage State")] public bool isLaunched = false;
    public bool invulnerable; //When true cannot be hit

    // Start is called before the first frame update
    void Start()
    {
        //Get appropriate references
        _anim = GetComponentInChildren<Animator>();
        _walking = true;
        _rb = GetComponent<Rigidbody2D>();
        _hit = GetComponent<HitManager>();
        _hitBox = GetComponentInChildren<HitBoxManager>();

        //Set opponents number
        if (_playerNumber == 1)
        {
            _opponentNumber = 2;
        }
        else if (_playerNumber == 2)
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

        //Based on the player number,get controls from the correct control source
        //Player 1 = Keyboard
        //Player 2 - COnroller
        if (_playerNumber == 1)
        {
            _playerVertical = Input.GetAxisRaw("Vertical " + _playerNumber);
        }
        else
        {
            _playerVertical = Input.GetAxis("Vertical " + _playerNumber);
        }


        //Player crouches when down is pressed
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

    private void GetOpponentPosition() // This method will track the position of the opponent so that each player can face the correct direction
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


    private void ManageOrientation() // This method will track the position of the opponent so that each player can face the correct direction
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
        //Set animators
        _anim.SetBool("Walking", _walking);
        _anim.SetBool("BackWalk", _backWalking);

        //If the player is attacking or being hit they cannot move and this below function skips the rest of this method
        if (_isAttacking || _hit.isStunned)
        {
            return;
        }

        //Get input from the correct controller source
        if (_playerNumber == 1)
        {
            _playerHorizontal = Input.GetAxisRaw("Horizontal " + _playerNumber);
        }
        else
        {
            _playerHorizontal = Input.GetAxis("Horizontal " + _playerNumber);
        }

        //Based on the position of the opponent, if this player is moving set the appropriate bools
        if (_playerHorizontal > 0)
        {
            //Right

            if (_otherPlayerIsToTheRight)
            {
                _walking = true;
                _backWalking = false;
            }
            else //Left
            {
                _backWalking = true;
                _walking = false;
            }

            //Set players speed right       
            _rb.velocity = new Vector2(_playerSpeed, 0);
        }
        else if (_playerHorizontal < 0)
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

            //Set players speed left
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
        _walking = false;
        _backWalking = false;
    }

    private void Attacking()
    {
        //Constantly set animators
        _anim.SetBool("isAttacking", _isAttacking);
        _anim.SetBool("CanInput", canInput);

        //If player is attacking stop this function
        if (!_isAttacking)
        {
            canInput = true;
        }

        //If the player is under any of the below conditions return out of this method
        if ((_isAttacking && !inputBuffer) || _hit.isStunned) return;

        //Light attack was pressed
        if (Input.GetButtonDown("Light " + _playerNumber))
        {
            //<<ATTACK PROPS>>
            _hitBox.DisableHitbox(); //Disable any lingering/present hitboxes
            _anim.SetTrigger("LightAttack"); //Set animator
            attackStrength = 1; //Attack strength
            canInput = false; //Player can no longer do inputs during attack
            inputBuffer = false; //No buffer window
        }

        //Medium attack was pressed
        if (Input.GetButtonDown("Medium " + _playerNumber))
        {
            //If this attack hits, you can press a stronger attack to cancel the remaining end lag of the current attack
            if (hitConfirm && attackStrength < 2)
            {
                canInput = true;
                _anim.SetBool("CanInput", canInput);
            }

            //Same as above attack props
            _hitBox.DisableHitbox();
            _anim.SetTrigger("MediumAttack");
            attackStrength = 2;
            canInput = false;
            inputBuffer = false;
        }

        //Heavy attack was pressed 
        if (Input.GetButtonDown("Heavy " + _playerNumber))
        {
            if (hitConfirm && attackStrength < 3)
            {
                canInput = true;
                _anim.SetBool("CanInput", canInput);
            }

            //Same as above attack props
            _hitBox.DisableHitbox();
            _anim.SetTrigger("HeavyAttack");
            attackStrength = 3;
            canInput = false;
            inputBuffer = false;


        }

        //Special Light attack was pressed 
        if (Input.GetButton("Special " + _playerNumber))
        {
            if (Input.GetButtonDown("Light " + _playerNumber))
            {
                if (hitConfirm && attackStrength < 4)
                {
                    canInput = true;
                    _anim.SetBool("CanInput", canInput);
                }

                //Same as above attack props
                _hitBox.DisableHitbox();
                _anim.SetTrigger("SpLightAttack");
                attackStrength = 4;
                canInput = false;
                inputBuffer = false;

            }
        }

        //Special Medium attack was pressed 
        if (Input.GetButton("Special " + _playerNumber))
        {
            if (Input.GetButtonDown("Medium " + _playerNumber))
            {
                if (hitConfirm && attackStrength < 4)
                {
                    canInput = true;
                    _anim.SetBool("CanInput", canInput);
                }

                //Same as above attack props
                _hitBox.DisableHitbox();
                _anim.SetTrigger("SpMediumAttack");
                attackStrength = 4;
                canInput = false;
                inputBuffer = false;

            }
        }

        //Special Heavy attack was pressed 
        if (Input.GetButton("Special " + _playerNumber))
        {
            if (Input.GetButtonDown("Heavy " + _playerNumber))
            {
                if (hitConfirm && attackStrength < 4)
                {
                    canInput = true;
                    _anim.SetBool("CanInput", canInput);
                }

                //Same as above attack props
                _hitBox.DisableHitbox();
                _anim.SetTrigger("SpHeavyAttack");
                attackStrength = 4;
                canInput = false;
                inputBuffer = false;

            }
        }

        //Super attack was pressed 
        if (Input.GetButton("Special " + _playerNumber))
        {
            if (Input.GetButtonDown("Super " + _playerNumber))
            {
                if (hitConfirm && attackStrength < 5)
                {
                    canInput = true;
                    _anim.SetBool("CanInput", canInput);
                }

                //Same as above attack props
                _hitBox.DisableHitbox();
                _anim.SetTrigger("Super");
                attackStrength = 5;
                canInput = false;
                inputBuffer = false;

            }
        }

    }



    //Attack has concluded to reset properties
    public void AttackEnded()
    {
        _isAttacking = false;
        attackStrength = 0; //Reset attack strength
        hitConfirm = false;
    }

    //Make it so players cannot do stuff when an attack is started
    public void AttackStarted()
    {
        _isAttacking = true;
        canInput = false;
        StopMovement();
    }

    //Set it so the player can uffer an attack
    public void Buffer()
    {
        inputBuffer = true;
    }

    //On hit the player can press another button to start another attack early
    public void HitCOnfirmable()
    {
        hitConfirm = true;
        inputBuffer = true;
    }
}

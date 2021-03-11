using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    [Header("ForMovment")]
    [SerializeField] private float MovmentSpeed;
    [Header("ForJump")]
    [SerializeField] private LayerMask TypeOfGround;
    [SerializeField] private Transform FeetPosition;
    [SerializeField] private float JumpForce;
    [SerializeField] private float RadiusOfCheckingGround;
    [SerializeField] private bool IsGrounded;
    [Header("Swimming")]
    [SerializeField] private LayerMask TypeOfWall;
    [SerializeField] private LayerMask TypeOfWater;
    [SerializeField] private Transform FloorPosition;
    [SerializeField] private Transform PlayerPosition;
    [SerializeField] private bool IsSwimming;
    [SerializeField] private bool IsTouchingFloor;
    [SerializeField] private float RadiusOfCheckingWater;
    [SerializeField] private float BreaststrokeSpeed;
    [Header("Climbing")]
    public bool IsClimbing;
    [SerializeField] private float ClimbingSpeed;

    private Animator _Animator;
    private float MoveDirection;
    private bool LookingRight = true;
    private Rigidbody2D _Rigidbody2D;
    private CapsuleCollider2D _CapsuleCollider2D;
    //private Animator Animator;


    void Start()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
        _CapsuleCollider2D = GetComponent<CapsuleCollider2D>();
        _Animator = GetComponent<Animator>();
        //Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        IsSwimming = Physics2D.OverlapCircle(FloorPosition.position, RadiusOfCheckingWater, TypeOfWater);
        IsTouchingFloor = Physics2D.OverlapCircle(PlayerPosition.position, RadiusOfCheckingWater, TypeOfWall);
        IsGrounded = Physics2D.OverlapCircle(FeetPosition.position, RadiusOfCheckingGround, TypeOfGround);
        MoveDirection = Input.GetAxisRaw("Horizontal");
        //Movment

        if (!LookingRight && MoveDirection > 0)
        {
            Flip();
        }
        else if (LookingRight && MoveDirection < 0)
        {
            Flip();  
        }

        Jump();
        Swimming();
        LadderClimbing();
        _Animator.SetFloat("RuningSpeed", Mathf.Abs(MoveDirection));
    }
    private void FixedUpdate()
    {
        _Rigidbody2D.velocity = new Vector2(MoveDirection * MovmentSpeed, _Rigidbody2D.velocity.y);//speed
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platforma")
        {
            gameObject.transform.parent = collision.gameObject.transform;
        }
      
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platforma")
        {
            gameObject.transform.parent = null;
        }
    }


    private void LadderClimbing()
    {
        if (IsClimbing==true)
        {
            Debug.Log("ddd");
            if (Input.GetKey(KeyCode.W))
            {
                _Rigidbody2D.velocity = (new Vector2(_Rigidbody2D.velocity.x, BreaststrokeSpeed));
            }
            else if (Input.GetKey(KeyCode.S))
            {
                _Rigidbody2D.velocity = (new Vector2(_Rigidbody2D.velocity.x, -BreaststrokeSpeed));
            }
            else
            {
                _Rigidbody2D.velocity = new Vector2(0f, 0f);
            }
        }
    } 
    private void Jump()
    {
        if (IsGrounded && Input.GetKeyDown(KeyCode.W) && IsClimbing == false)
        {
            _Animator.SetTrigger("Jump");
            _Rigidbody2D.AddForce(new Vector2(_Rigidbody2D.velocity.x, JumpForce));
        }
    }
    private void Swimming()
    {

        if (IsSwimming == true && IsGrounded== false)
        {
            _Rigidbody2D.velocity = new Vector2(0f, 0f);
            _CapsuleCollider2D.enabled = false;
            Breaststroke();
        }
        else
        {
            _CapsuleCollider2D.enabled = true;
        }
        if (IsSwimming == true && IsGrounded == true)
        {
            _CapsuleCollider2D.enabled = true;
        }
        else if (IsSwimming == true && IsTouchingFloor == true)
        {
            _CapsuleCollider2D.enabled = true;
        }
    }
    private void Breaststroke()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _Rigidbody2D.velocity=(new Vector2(_Rigidbody2D.velocity.x, ClimbingSpeed));
        }
        else if(Input.GetKey(KeyCode.S))
        {
            _Rigidbody2D.velocity=(new Vector2(_Rigidbody2D.velocity.x, -ClimbingSpeed));
        }
    }

    private void Flip()
    {
        LookingRight = !LookingRight;
        Vector3 Transformer = transform.localScale;
        Transformer.x *= -1;
        transform.localScale = Transformer;
    }


    private void OnDrawGizmosSelected()
    {
        if (FeetPosition == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(FeetPosition.position, RadiusOfCheckingGround);

        if (PlayerPosition.position == null)
        {
            return;
        }
        Gizmos.DrawSphere(PlayerPosition.position, RadiusOfCheckingWater);
    }
}

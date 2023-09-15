using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
  public int health = 100;

  public CharacterController2D controller;
  public Animator animator;
  public Rigidbody2D rb;
  public BoxCollider2D bc;

  public float runSpeed = 40f;
  float horizontalMove = 0f;

  bool canMove = true;
  bool isAlive = true;
  bool jump = false;

  [Header("Climb")]
  [HideInInspector] public bool ledgeDetected;

  [Header("Ledge info")]
  [SerializeField] public Vector2 offset1;
  [SerializeField] public Vector2 offset2;
  [SerializeField] public Vector2 offset2Left;

  private Vector2 climbBegunPosition;
  private Vector2 climbOverPosition;

  private bool canGrabLedge = true;
  private bool canClimb;

  // Update is called once per frame
  void Update()
  {
    if(isAlive)
    {
      if (canMove)
      {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if(Input.GetButton("Run"))
        {
          horizontalMove = horizontalMove * 2;
        }
        else if(Input.GetButtonUp("Run"))
        {
          horizontalMove = horizontalMove / 2;
        }
      }
      //Shoot Animation Change
      if(Input.GetButton("Fire1"))
      { 
        animator.SetBool("isShooting", true);
        canMove = false;
        horizontalMove = 0f;
      }
      if(Input.GetButtonUp("Fire1"))
      {
        animator.SetBool("isShooting", false);
        canMove = true;
      }
      animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }
    Debug.Log(ledgeDetected);
    if(Input.GetButton("Jump"))
    {
      CheckForLedge();
    }
    AnimationControllers();
    Debug.Log(GetComponent<CharacterController2D>().m_FacingRight);
  }

  void FixedUpdate()
  {
    controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
    jump = false;
  }

  //Check for ledge logic xd
  private void CheckForLedge()
  {
    if(ledgeDetected && canGrabLedge)
    {
      canGrabLedge = false;

      Vector2 ledgePositon = GetComponentInChildren<LedgeDetection>().transform.position;
      bool facingRigth = GetComponent<CharacterController2D>().m_FacingRight;
      if(facingRigth == true)
      {
        climbBegunPosition = ledgePositon + offset1;
        climbOverPosition = ledgePositon + offset2;
      }
      else
      {
        climbBegunPosition = ledgePositon + offset1;
        climbOverPosition = ledgePositon + offset2Left;
      }

      canClimb = true;
    }

    if(canClimb)
    {
      transform.position = climbBegunPosition;
    }
  }

  private void LedgeClimbOver()
  {
    canClimb = false;
    transform.position = climbOverPosition;
    Invoke("AllowLedgeClimb", .1f);
  }

  private void AllowLedgeClimb() => canGrabLedge = true;

  private void AnimationControllers()
  {
    animator.SetBool("canClimb", canClimb);
  }

  public void TakeDamage (int damage)
  {
    health -= damage;
    animator.SetTrigger("TakeDamage");
    if(health <= 0)
    {
      Die();
    }
  }
  void Die()
  {
    animator.SetBool("isDeath", true);
    isAlive = false;
  }
}

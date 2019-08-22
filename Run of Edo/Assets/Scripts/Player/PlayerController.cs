using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using EZCameraShake;

public class PlayerController : PhysicsObject
{

    protected float maxSpeed = 0;
    [SerializeField]
    protected float jumpTakeOffSpeed = 8;
    protected bool ForceAlive;

    [SerializeField]
    protected TapController JumpBtn;

    protected SpriteRenderer spriteRenderer;
    //protected Animator animator;
    
    //States
    public bool IsHurt { get; set; }
    public bool IsDead { get; set; }

    public bool Jumping {
        get
        {
            return Input.GetButtonDown("Jump") || JumpBtn.IsPressed;
        }
    }
    //Bonus
    private bool speedUp;
    public bool SpeedUp
    {
        get
        {
            return speedUp;
        }
        set
        {
            speedUp = value;
            //animator.SetBool("speedUp", value);
            transform.GetComponent<Collider2D>().enabled = !value;

            if (speedUp)
            {
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            }
            else
            {
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }

    protected override void Awake()
    {
        base.Awake();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //animator = GetComponent<Animator>();

    }

    protected override void Update()
    {
        //Debug.Log("Input : " + Input.GetButtonDown("Jump"));
        //Debug.Log("Btn : " + JumpBtn.IsPressed);
        if (!IsDead && GameManager.IsStart)
        {
            base.Update();
        }
        if (ForceAlive)
        {
            Relive();
        }
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Vector2.right.x;
        if (Jumping && isGrounded)
        {
            Jump(jumpTakeOffSpeed);
        }
        else if (Jumping)
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * .25f;
            }
        }
        bool flipSprite = (spriteRenderer.flipX ? move.x > 0.01f : move.x < -0.01f);
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        //animator.SetBool("Grounded", isGrounded);
        //animator.SetFloat("VelocityY", velocity.y);
        TargetVelocity = move * maxSpeed;

    }

    public void Jump(float jumpValue)
    {
        velocity.y = jumpValue;
        isGrounded = true;
    }

    public void Dead()
    {
        this.IsDead = true;
        CameraShaker.Instance.ShakeOnce(4f, 4f, .25f, .25f);
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        //animator.SetBool("IsDead", this.IsDead);
        GameManager.EndGame();

    }

    public void Relive()
    {
        this.IsDead = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        //animator.SetBool("IsDead", this.IsDead);
        GameManager.StartGame();
    }

    public void Hurt()
    {
        IsHurt = !IsHurt;
        //animator.SetBool("Hurt", IsHurt);
    }

}

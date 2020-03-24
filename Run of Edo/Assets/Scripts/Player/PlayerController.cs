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
    protected Animator animator;
    public Animator GetAnimator()
    {
        return this.animator;
    }

    protected AudioManager AudioManager { get; set; }

    //States
    public bool IsHurt { get; set; }
    public bool IsDead { get; set; }

    public bool Jumping {
        get
        {
            return Input.GetButtonDown("Jump") || JumpBtn.IsPressed;
        }
    }
    public bool jumped;
    //Bonus
    private bool speedUp;

    protected override void Start()
    {
        base.Start();
        AudioManager = FindObjectOfType<AudioManager>();
    }

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
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
        //animator = GetComponent<Animator>();

    }

    protected override void Update()
    {
        //Debug.Log("Input : " + Input.GetButtonDown("Jump"));
        //Debug.Log("Btn : " + JumpBtn.IsPressed);
        if (!IsDead)
        {
            if (GameManager.IsStart)
            {


                jumped = Jumping;
                base.Update();

                lastPosition = gameObject.transform.position;
            }
            else
            {

                gameObject.transform.position = lastPosition;
            }
        }
        if (ForceAlive)
        {
            Relive();
        }
    }
    Vector3 lastPosition;
    protected override void ComputeVelocity()
    {
        if (GameManager.IsStart)
        {
            Vector2 move = Vector2.zero;

            if (jumped && isGrounded && !JumpBtn.NeedToReleaseJump)
            {
                JumpBtn.NeedToReleaseJump = true;
                Jump(jumpTakeOffSpeed);
            }
            else if (jumped)
            {
                //if (velocity.y > 0)
                //{
                //    velocity.y = velocity.y * .25f;
                //}
                //jumped = false;
            }

            bool flipSprite = (spriteRenderer.flipX ? move.x > 0.01f : move.x < -0.01f);
            if (flipSprite)
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }

            animator.SetFloat("Jump", Mathf.Abs(velocity.y));
            TargetVelocity = move * maxSpeed;
        }else
        {
        }

    }
    public void Freeze()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

    }
    public void Unfreeze()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    public void StopAnimation()
    {
        GetComponentInChildren<Animator>().enabled = false;
    }
    public void StartAnimation()
    {
        GetComponentInChildren<Animator>().enabled = true;
    }
    public void Jump(float jumpValue)
    {
        velocity.y = jumpValue;
        isGrounded = true;
    }

    public void Dead()
    {
        this.IsDead = true;
        this.animator.SetBool("IsDead", true);
        CameraShaker.Instance.ShakeOnce(4f, 4f, .25f, .25f);
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        //animator.SetBool("IsDead", this.IsDead);
        this.AudioManager.Play("Dead");
        GameManager.EndGame();

    }

    public void Relive()
    {
        this.animator.SetBool("IsDead", false);
        this.IsDead = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        //animator.SetBool("IsDead", this.IsDead);
        GameManager.StartGame();
    }

    public void Hurt()
    {
        IsHurt = !IsHurt;
        animator.SetTrigger("Damage");
    }

}

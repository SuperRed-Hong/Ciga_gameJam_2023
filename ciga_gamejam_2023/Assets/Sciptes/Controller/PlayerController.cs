using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected GameObject currentOneWayPlayform;
    [SerializeField] protected CapsuleCollider2D palyerCollider;
    protected BoxCollider2D playerController;
    protected Rigidbody2D rb2D;
    Animator animator;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float jumpForce;
    protected bool _isJumping = false;
    protected bool _isFalling = false;
    protected bool _isRunning = false;
    protected bool isFacingRight = true;
    protected bool _isStunned = false;
    protected Skill currentSkill;

    protected bool isFalling
    {
        get
        {
            return _isFalling;
        }
        set
        {
            _isFalling = value;
            animator.SetBool("isFalling", value);

        }
    }

    public bool isJumping
    {
        get
        {
            return _isJumping;
        }
        protected set
        {
            _isJumping = value;
            animator.SetBool("isJumping", value);
        }
    }
    protected float moveHorizontal;
    protected float moveVertical;
    public bool isRunning
    {
        get
        {
            return _isRunning;
        }
        protected set
        {
            _isRunning = value;
            animator.SetBool("isRunning", value);
        }
    }
    protected void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }
    void Start()
    {


    }
    protected void FixedUpdate()
    {
        if (!_isStunned) {
            if (moveHorizontal > 0.1f || moveHorizontal < -0.1f)
            {

                rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
                isRunning = true;
            }
            else
            {
                isRunning = false;
            }

            if (!isJumping && moveVertical > 0.1f)
            {
                rb2D.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);

            }

            onFalling();
            FlipFace();
        }
        

    }
    protected GameObject OnCollisionEnter2D(Collision2D collision)

    {
        if ((collision.gameObject.tag == "OneWayPlatform" || collision.gameObject.tag == "Platform") && gameObject.transform.position.y - collision.gameObject.transform.position.y > 0 && rb2D.velocity.y == 0)
        {
            isJumping = false;
            currentOneWayPlayform = collision.gameObject;
        }
        return collision.gameObject;
    }

    protected void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "OneWayPlatform" || collision.gameObject.tag == "Platform")
        {
            isJumping = true;
            currentOneWayPlayform = null;

        }
    }
    protected void onFalling()
    {
        if (rb2D.velocity.y < 0f)
        {
            isFalling = true;

        }
        else
        {
            isFalling = false;
        }
    }


    protected IEnumerator DisableCollision()
    {
        BoxCollider2D platformCollider = currentOneWayPlayform.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(palyerCollider, platformCollider);
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreCollision(palyerCollider, platformCollider, false);
    }
    protected void FlipFace()
    {
        if (isFacingRight && moveHorizontal < 0f || !isFacingRight && moveHorizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public void onStunned()
    {
        _isStunned = true;
    }
    public void offStunned()
    {
        _isStunned = false;
    }
    public void SetSkill(Skill skill)
    {
        currentSkill = skill;
    }
}

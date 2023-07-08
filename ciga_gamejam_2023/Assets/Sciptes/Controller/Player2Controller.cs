using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    private GameObject currentOneWayPlayform;
    [SerializeField] private CapsuleCollider2D palyerCollider;
    private BoxCollider2D playerController;
    private Rigidbody2D rb2D;
    Animator animator;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    private bool _isJumping = false;
    private bool _isFalling = false;
    private bool _isRunning = false;
    private bool isFacingRight = true;


    private bool isFalling
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
        private set
        {
            _isJumping = value;
            animator.SetBool("isJumping", value);
        }
    }
    private float moveHorizontal;
    private float moveVertical;
    public bool isRunning
    {
        get
        {
            return _isRunning;
        }
        private set
        {
            _isRunning = value;
            animator.SetBool("isRunning", value);
        }
    }
    private void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        moveHorizontal = Input.GetAxisRaw("Horizontal2");
        moveVertical = Input.GetAxisRaw("Vertical2");
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentOneWayPlayform != null && currentOneWayPlayform.tag != "Platform")
            {
                StartCoroutine(DisableCollision());
            }
        }



    }
    private void FixedUpdate()
    {
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
    private GameObject OnCollisionEnter2D(Collision2D collision)

    {
        if ((collision.gameObject.tag == "OneWayPlatform" || collision.gameObject.tag == "Platform") && gameObject.transform.position.y - collision.gameObject.transform.position.y > 0 && rb2D.velocity.y == 0)
        {
            isJumping = false;
            currentOneWayPlayform = collision.gameObject;
        }
        return collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "OneWayPlatform" || collision.gameObject.tag == "Platform")
        {
            isJumping = true;
            currentOneWayPlayform = null;

        }
    }
    private void onFalling()
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


    private IEnumerator DisableCollision()
    {
        BoxCollider2D platformCollider = currentOneWayPlayform.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(palyerCollider, platformCollider);
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreCollision(palyerCollider, platformCollider, false);
    }
    private void FlipFace()
    {
        if (isFacingRight && moveHorizontal < 0f || !isFacingRight && moveHorizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}

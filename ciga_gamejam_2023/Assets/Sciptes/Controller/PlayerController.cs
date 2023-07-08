using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    private GameObject currentOneWayPlayform;
    [SerializeField] private CapsuleCollider2D playerCollider;
    private PlayerController opponent;
    private Rigidbody2D rb2D;
    Animator animator;
    [SerializeField] private float basicMoveSpeed;
    private float moveSpeed;
    [SerializeField] private float jumpForce;
    private bool _isJumping = false;
    private bool _isFalling = false;
    private bool _isRunning = false;
    private bool isFacingRight = true;
    private bool _isStunned = false;
    private Skill currentSkill;
    [SerializeField] private bool character;
    private bool _isCollision;

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
        //character=false;
        moveSpeed=basicMoveSpeed;
    }
    void Update()
    {
        if(character){
            moveHorizontal = Input.GetAxisRaw("Horizontal1");
            moveVertical = Input.GetAxisRaw("Vertical1");
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (!_isStunned && currentOneWayPlayform != null && currentOneWayPlayform.tag != "Platform")
                {
                    StartCoroutine(DisableCollision());
                }
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!_isStunned && currentSkill != null)
                {
                    currentSkill.UseSkill();
                    currentSkill=null;
                }
            }
        }else{
            moveHorizontal = Input.GetAxisRaw("Horizontal2");
            moveVertical = Input.GetAxisRaw("Vertical2");
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (!_isStunned&&currentOneWayPlayform != null && currentOneWayPlayform.tag != "Platform")
                {
                    StartCoroutine(DisableCollision());
                }
            }
            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                if (!_isStunned && currentSkill != null)
                {
                    currentSkill.UseSkill();
                    currentSkill=null;
                }
            }
        }
        

    }
    private void FixedUpdate()
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

    private void OnTriggerStay2D(Collider2D collision)

    {
        if (_isCollision == false)
        {
            if ((collision.gameObject.tag == "OneWayPlatform" || collision.gameObject.tag == "Platform")  /*gameObject.transform.position.y - collision.gameObject.transform.position.y > 0 */ && rb2D.velocity.y == 0)
            {
                isJumping = false;
                currentOneWayPlayform = collision.gameObject;
            }
        }
        
        
    }
   

    private void OnTriggerExit2D(Collider2D collision)
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
    { if (currentOneWayPlayform.GetComponent<BoxCollider2D>() != null)
        {
            TilemapCollider2D platformCollider = currentOneWayPlayform.GetComponent<TilemapCollider2D>();
            Physics2D.IgnoreCollision(palyerCollider, platformCollider);
            yield return new WaitForSeconds(0.2f);
            Physics2D.IgnoreCollision(palyerCollider, platformCollider, false);
        }
        else
        {
            Debug.Log("can't get currentOneWayPlayForm");
        }
        
    }
    private void FlipFace()
    {
        if (isFacingRight && moveHorizontal < 0f || !isFacingRight && moveHorizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            this.gameObject.GetComponent<SpriteRenderer>().flipX=!this.gameObject.GetComponent<SpriteRenderer>().flipX;
        }
    }

    public PlayerController GetOpponent(){
        return opponent;
    }

    public void SetOpponent(PlayerController opponent){
        this.opponent=opponent;
    }

    public void onStunned()
    {
        _isStunned = true;
    }
    public void offStunned()
    {
        _isStunned = false;
    }
    public void ChangeSpeed(float ratio){
        moveSpeed=basicMoveSpeed*ratio;
    }
    public void ResetSpeed(){
        moveSpeed=basicMoveSpeed;
    }
    public void SetSkill(Skill skill)
    {
        currentSkill = skill;
    }
    public void SetCharacter(bool c){
        character=c;
    }
    public void FlipCharacter(){
        character=!character;
    }
}

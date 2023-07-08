using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    protected GameObject currentOneWayPlayform;
    [SerializeField] protected CapsuleCollider2D playerCollider;
    protected BoxCollider2D playerController;
    protected Rigidbody2D rb2D;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float jumpForce;
    protected bool isJumping;
    protected float moveHorizontal;
    protected float moveVertical;
    void Start()
    {
        rb2D  =gameObject.GetComponent<Rigidbody2D>();
       
        isJumping = false;
        

    }

    
    protected void FixedUpdate()
    {
        if(moveHorizontal> 0.1f || moveHorizontal < 0.1f)
        {
            rb2D.AddForce(new Vector2(moveHorizontal* moveSpeed, 0f) , ForceMode2D.Impulse);
        }
        if (!isJumping&&moveVertical > 0.1f)
        {
            rb2D.AddForce(new Vector2(0f, moveVertical* jumpForce), ForceMode2D.Impulse);

        }

    }
    protected void OnCollisionEnter2D(Collision2D collision)

    {
        if ((collision.gameObject.tag == "OneWayPlatform"|| collision.gameObject.tag == "Platform") && gameObject.transform.position.y - collision.gameObject.transform.position.y>0 && rb2D.velocity.y ==0)
        {
            isJumping = false;
            currentOneWayPlayform = collision.gameObject;
        }
    }

    protected void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "OneWayPlatform" || collision.gameObject.tag == "Platform")
        {
            isJumping = true;
            currentOneWayPlayform = null;

        }
    }

    protected IEnumerator DisableCollision()
    {
        BoxCollider2D platformCollider = currentOneWayPlayform.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreCollision(playerCollider, platformCollider,false);
    }

    public void Dizziness(){

    }
}

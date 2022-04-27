using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float speed;
    private float horizontalAxis;
    private bool jump;
    private float jumpSpeed = 5;
    private bool grounded;
    private BoxCollider2D boxCollider2d;
    [SerializeField] private LayerMask groundLayerMask;
    
    [SerializeField] private Animator animator;

    //jumping stuff
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    [Range(1,10)]
    public float jumpVelocity;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider2d = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        // controls
        horizontalAxis = Input.GetAxis("Horizontal");  // GetAxisRaw
        jump = Input.GetKey(KeyCode.Space);

        //mirror sprite if player turns around and faces the other way. deprecated, use quaternion
        //if (horizontalAxis < 0) transform.localScale = new Vector3(-1, 1, 1);
        //else if (horizontalAxis > 0) transform.localScale = new Vector3(1, 1, 1);

        animator.SetBool("running", horizontalAxis != 0);

        //fire point stuff
        if (horizontalAxis < 0) transform.localRotation = Quaternion.Euler(0,180,0);
        else if (horizontalAxis > 0) transform.localRotation = Quaternion.Euler(0,0,0);
        //using this works better than the code above because it also rotates the firing point
    }

    void FixedUpdate()
    {
        // left/right movement
        if (horizontalAxis > 0 && !checkRightCollision()){
            body.velocity = new Vector2(horizontalAxis*speed, body.velocity.y);
        }
        if (horizontalAxis < 0 && !checkLeftCollision()){
            body.velocity = new Vector2(horizontalAxis*speed, body.velocity.y);
        }        

        // check if player is falling
        checkGroundForFallingAnim();

        // jump
        if (isGrounded() && jump){
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);
        }
    }

    bool isGrounded(){
        float extraHeight = 0.05f;
        //RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2d.bounds.center, Vector2.down, boxCollider2d.bounds.extents.y + extraHeight, groundLayerMask);
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, extraHeight, groundLayerMask);
        return (raycastHit.collider != null);
    }

    void checkGroundForFallingAnim(){
        float extraHeight = 0.05f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, extraHeight, groundLayerMask);
        if (raycastHit.collider != null){
            animator.SetBool("jumping", false);
        }
        else if (raycastHit.collider == null){
            animator.SetBool("jumping", true);
        }
    }

    bool checkLeftCollision(){
        float extraHeight = 0.05f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.left, extraHeight, groundLayerMask);
        return (raycastHit.collider != null);
    }

    bool checkRightCollision(){
        float extraHeight = 0.01f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.right, extraHeight, groundLayerMask);
        return (raycastHit.collider != null); 
    }
}

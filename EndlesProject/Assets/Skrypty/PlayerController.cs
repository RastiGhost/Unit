using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float JumpForce;

    private Rigidbody2D myRigibody;

    public bool grounded;
    public LayerMask whatIsGround;

    private Collider2D myCollider;
    private Animator myAnimator;


    // Use this for initialization
    void Start () {
        myRigibody = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        myRigibody.velocity = new Vector2(moveSpeed, myRigibody.velocity.y);


        if (Input.GetKeyDown(KeyCode.Space )) {
            if (grounded) {
                myRigibody.velocity = new Vector2(myRigibody.velocity.x, JumpForce);
            }
           
        }
        
        myAnimator.SetFloat("Speed", myRigibody.velocity.x);
        myAnimator.SetBool("Grounded", grounded);
	}
}

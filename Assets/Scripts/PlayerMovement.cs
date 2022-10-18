using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private  float speed;
    [SerializeField] private float jumpSpeed;
    private Animator animator;
    private bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        grounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed,body.velocity.y);

        // flip the character while moving
        if (horizontalInput>00.1f)
            transform.localScale = Vector3.one;
        else if (horizontalInput <= -00.1f) 
                transform.localScale = new Vector3(-1,1,1);

        if (Input.GetKey(KeyCode.Space) && grounded) {
            jump();
        }

        animator.SetBool("run", horizontalInput != 0);
        animator.SetBool("grounded", grounded);
    }

    void jump() {
        body.velocity = new Vector2(body.velocity.x, jumpSpeed);
        grounded = false;
        animator.SetTrigger("jump");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        grounded = true;
    }
}

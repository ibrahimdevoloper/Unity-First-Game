using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private  float speed;
    [SerializeField] private float jumpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal")*speed,body.velocity.y);

        if (Input.GetKey(KeyCode.Space)) {
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);
        }
    }
}

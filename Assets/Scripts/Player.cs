using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Properties & Fields

    public int level;
    public int hp;
    public int mp;
    public int speed;
    public float jumpForce;

    private float movement;
    private bool isJumping;

    private Rigidbody2D rig;
    private Animator anim;

    #endregion

    #region Main Methods

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        UpdateInitialValues();
    }

    void Update()
    {
        Move();
        Jump();
    }

    #endregion

    #region Methods

    private void Move()
    {
        movement = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(movement * speed, rig.velocity.y);

        //TODO - We need to do animations to work fine

        //if (movement > 0)
        //{
        //    anim.SetInteger("transition", 1);
        //    transform.eulerAngles = new Vector3(0, 0, 0);
        //}
        //if (movement < 0)
        //{
        //    anim.SetInteger("transition", 1);
        //    transform.eulerAngles = new Vector3(0, 180, 0);
        //}

        //if (movement == 0)
        //    anim.SetInteger("transition", 0);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJumping)
            {
                rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                isJumping = true;
            }
        }
    }

    private void UpdateInitialValues()
    {
        //TODO - After database defined, these values will receive directly from the database.
        level = 1;
        hp = 200;
        mp = 50;
        speed = 5;
        jumpForce = 12;
    }

    #endregion

    #region Events

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isJumping = false;
        }
    }

    #endregion
}

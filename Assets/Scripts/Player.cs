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

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        UpdateInitialValues();
    }

    void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {

        //TODO - We need to do animations to work fine
        movement = Input.GetAxis("Horizontal");

        rig.velocity = new Vector2(movement * speed, rig.velocity.y);

        if (movement > 0)
        {
            anim.SetInteger("transition", 1);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (movement < 0)
        {
            anim.SetInteger("transition", 1);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (movement == 0)
            anim.SetInteger("transition", 0);
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isJumping)
            {
                anim.SetInteger("transition", 2);
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
        jumpForce = 3;
    }
}

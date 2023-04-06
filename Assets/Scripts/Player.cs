using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int level;
    public int hp;
    public int mp;
    public int speed;
    public float jumpPower;

    private Rigidbody2D rig;
    private Animator anim;

    void Start()
    {
        UpdateInitialValues();
    }

    void FixedUpdate()
    {
        
    }

    private void Jump()
    {

    }

    private void UpdateInitialValues()
    {
        level = 1;
        hp = 200;
        mp = 50;
        speed = 5;
        jumpPower = 3;
    }
}

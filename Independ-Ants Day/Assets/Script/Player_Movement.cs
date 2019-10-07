using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public float runSpeed = 3f;
    public Rigidbody2D RB2D;
    public Animator Anim;
    public SpriteRenderer Splat;
    public GameManagerScript GMScript;

    // Start is called before the first frame update
    void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        Splat = transform.Find("Splat").GetComponent<SpriteRenderer>();
        GMScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        RB2D.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);

        if (RB2D.velocity.x > 0 && RB2D.velocity.y == 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, 270);
        }

        else if (RB2D.velocity.x < 0 && RB2D.velocity.y == 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, 90);
        }

        else if (RB2D.velocity.y > 0 && RB2D.velocity.x == 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }

        else if (RB2D.velocity.y < 0 && RB2D.velocity.x == 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, 180);
        }

        else if (RB2D.velocity.x > 0 && RB2D.velocity.y > 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, -45);
        }

        else if (RB2D.velocity.x > 0 && RB2D.velocity.y < 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, -135);
        }

        else if (RB2D.velocity.x < 0 && RB2D.velocity.y > 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, 45);
        }

        else if (RB2D.velocity.x < 0 && RB2D.velocity.y < 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, 135);
        }

        if (RB2D.velocity.x == 0 && RB2D.velocity.y == 0 || GMScript.GameOver == false)
        {
            Anim.SetBool("IsMoving", false);
        }

        else if (RB2D.velocity.x > 0 || RB2D.velocity.x < 0 || RB2D.velocity.y > 0 || RB2D.velocity.y < 0 && GMScript.GameOver == false)
        {
            Anim.SetBool("IsMoving", true);
        }

        else if (GMScript.GameOver == true)
        {
            Anim.SetBool("IsMoving", false);
        }

    }
}

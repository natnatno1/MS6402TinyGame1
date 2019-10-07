using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass_Fire_Laser : MonoBehaviour
{
    public Transform Ant;

    public int R_R_min;
    public int R_R_max;

    public Vector3 Attacking_place;
    public Vector3 Resting_place;

    public float glass_rotate_speed;
    public float glass_move_speed;

    private bool Movement_possible;

    private int glass_move = 60;

    private Transform laser_beam;

    public bool dothing;

    public float x = 0.0f;
    public float y = 0.1f;
    public float z = 0.0f;

    public GameManagerScript GMScript;

    private void Start()
    {
        laser_beam = gameObject.transform.Find("laser_beam");

        Movement_possible = false;

        dothing = true;

        GMScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    void Update()
    {
        if (dothing == true)
        {
            if (glass_move == Random.Range(R_R_min, R_R_max))
            {
                Movement_possible = true;
            }

            if (Movement_possible == true)
            {
                float move_speed = Time.deltaTime * glass_move_speed;

                transform.position = Vector3.MoveTowards(transform.position, Attacking_place, move_speed);

                Vector3 targetDirection = Ant.position - transform.position;

                float laser_speed = Time.deltaTime * glass_rotate_speed;

                Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, laser_speed, 0.0f);

                transform.rotation = Quaternion.LookRotation(newDirection);

                Invoke("go_back", 30);

                if (laser_beam.transform.localScale.y < 15f)
                {
                    laser_beam.transform.localScale += new Vector3(x, y, z);
                }

                if (laser_beam.transform.localScale.y >= 15f)
                {
                    laser_beam.transform.localScale += new Vector3(0f, 0f, 0f);
                }
            }
        }

        if (Movement_possible == false)
        {
            float move_speed = Time.deltaTime * glass_move_speed;

            transform.position = Vector3.MoveTowards(transform.position, Resting_place, move_speed);

            if (laser_beam.transform.localScale.y >= 1f)
            {
                laser_beam.transform.localScale += new Vector3(x, -y, z);
            }

            if (laser_beam.transform.localScale.y < 1f)
            {
                laser_beam.transform.localScale += new Vector3(0f, 0f, 0f);
            }

        }

    }

    void go_back()
    {
        Movement_possible = false;

        dothing = false;

        Invoke("reset", 5);
    }

    private void reset()
    {
        dothing = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GMScript.GameOver = true;
            other.gameObject.GetComponentInParent<Rigidbody2D>().velocity = new Vector2(0, 0);
            other.gameObject.GetComponentInParent<Player_Movement>().enabled = false;
            other.gameObject.GetComponentInParent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        }
    }
}
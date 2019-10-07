using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spidey_Boi_Behaviour : MonoBehaviour
{

    public GameObject Player;
    public Transform PlayerPosition;
    public float speed;
    public float step;
    public Rigidbody2D RB2D;
    public float DistanceToPlayer;
    public float DangerZone;
    public Animator Anim;
    public Vector3 OldEularAngles;
    public GameManagerScript GMScript;
    public SpriteRenderer Splat;

    // Start is called before the first frame update
    void Start()
    {
        GMScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        RB2D = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        OldEularAngles = transform.rotation.eulerAngles;
        Player = GameObject.Find("Ant-Boi");
        PlayerPosition = Player.transform;
        Splat = transform.Find("Splat").GetComponent<SpriteRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
        DistanceToPlayer = Vector3.Distance(Player.transform.position, transform.position);

        if (DistanceToPlayer < DangerZone)
        {
            var newRotation = Quaternion.LookRotation(transform.position - Player.transform.position, Vector3.forward);
            newRotation.x = 0;
            newRotation.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 8);
            step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, PlayerPosition.position, step);

        }

        if (RB2D.velocity.x == 0 && RB2D.velocity.y == 0 && OldEularAngles == transform.rotation.eulerAngles)
        {
            Anim.SetBool("IsMoving", false);
            
        }
        
        else
        {
            OldEularAngles = transform.rotation.eulerAngles;
            Anim.SetBool("IsMoving", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GMScript.GameOver = true;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            collision.gameObject.GetComponent<Player_Movement>().enabled = false;
            collision.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        }
    }
}

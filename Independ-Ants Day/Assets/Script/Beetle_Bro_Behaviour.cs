using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beetle_Bro_Behaviour : MonoBehaviour
{
    
    public GameObject Waypoints;
    public Vector3 NewDirection;
    public float step;
    public float speed;
    public List<GameObject> children = new List<GameObject>();
    public GameManagerScript GMScript;

    // Start is called before the first frame update
    void Start()
    {
        GMScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

        Waypoints = GameObject.Find("Waypoints");

        //Transform[] Waypoint = Waypoints.GetComponentsInChildren<Transform>();

        foreach (Transform t in Waypoints.transform)
        {
            children.Add(t.gameObject);
        }

        NewDirection = children[Random.Range(0, 9)].transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position == NewDirection)
        {
            NewDirection = children[Random.Range(0, children.Count)].transform.position;
        }

        else
        {
            var newRotation = Quaternion.LookRotation(transform.position - NewDirection, Vector3.forward);
            newRotation.x = 0;
            newRotation.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 8);
            step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, NewDirection, step);
            



        }

       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.transform.localScale.x < transform.localScale.x)
            {
                GMScript.GameOver = true;
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                collision.gameObject.GetComponent<Player_Movement>().enabled = false;
                collision.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            }

            else
            {
                Destroy(gameObject);
            }
        }
    }
}

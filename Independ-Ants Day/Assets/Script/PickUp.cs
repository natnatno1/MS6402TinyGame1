using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject Player;
    public GameObject AntHill;
    public GameManagerScript GMScript;

    // Start is called before the first frame update
    void Start()
    {
        GMScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent == Player)
        {
            transform.position = Player.transform.position;
            transform.rotation = Player.transform.rotation;
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.parent = collision.transform;
        }

        else if (collision.gameObject.tag == "Anthill")
        {

            Destroy(gameObject);
            GMScript.Score++;
            GMScript.SendMessage("SpawnSugarCube");
            GMScript.SendMessage("GrowAnt");
        }
    }
    
}

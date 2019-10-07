using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flippy_Boi_Carnage : MonoBehaviour
{
    public GameManagerScript GMScript;

    // Start is called before the first frame update
    void Start()
    {
        GMScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
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

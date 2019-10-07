using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntBoiZCollision : MonoBehaviour
{
    public GameObject AntBoi;
    public GameObject Flippy;
    public GameManagerScript GMScript;

    // Start is called before the first frame update
    void Start()
    {
        Flippy = GameObject.Find("Flippy-Boi-Object");
        GMScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = AntBoi.transform.position;
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "FlippyBoi")
        {
            //if (Flippy.transform.localPosition.z > -3f)
            //{
            //    Debug.LogFormat("DeleteDis");
            //}

            //if (collision.gameObject.transform.position.z > -3f)
            //  {
            //      Debug.LogFormat("DeleteDis");
            // }

            if (collision.gameObject.transform.localPosition.z >= -3f)
            {
                Debug.LogFormat("DELETEDISNAO");
            }

            

        }

        else if (collision.gameObject.tag == "Laser")
        {
            Debug.LogFormat("HEDEADBITCH");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Flippy)
        {
            GMScript.GameOver = true;
            GetComponentInParent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GetComponentInParent<Player_Movement>().enabled = false;
            GetComponentInParent<Player_Movement>().Splat.color = new Color(1f, 1f, 1f, 1f);
            Debug.LogFormat("nfreighreousih87rsyeog");
        }
    }


}

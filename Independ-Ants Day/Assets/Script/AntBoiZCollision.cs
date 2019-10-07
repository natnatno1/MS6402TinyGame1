using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntBoiZCollision : MonoBehaviour
{
    public GameObject AntBoi;
    public GameObject Flippy;

    // Start is called before the first frame update
    void Start()
    {
        Flippy = GameObject.Find("Flippy-Boi-Object");
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
    }
}

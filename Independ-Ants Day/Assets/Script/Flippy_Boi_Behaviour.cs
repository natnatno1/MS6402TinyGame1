using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flippy_Boi_Behaviour : MonoBehaviour
{
    public GameObject Shadow;
    public GameObject FlippyBoi;
    public Vector3 NewDirection;
    public Vector3 ShadowGrowth;
    public SpriteRenderer ShadowSprite;
    public float speed;
    public float step;
    public float Timer;
    public bool Enter;
    public bool Exit;

    // Start is called before the first frame update
    void Start()
    {
        NewDirection = new Vector3((Random.Range(-7.5f, 5.5f)), (Random.Range(-3.5f, 0.5f)), -14f);

        ShadowSprite = Shadow.GetComponent<SpriteRenderer>();

        Enter = true;

        Exit = false;
    }

    // Update is called once per frame
    void Update()
    {
        step = speed * Time.deltaTime;

        Timer = Timer += Time.deltaTime;

        if (transform.position.z == -4.5f)
        {
            Enter = false;
        }

        if (Timer < 3 && Enter == true && Exit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, NewDirection, step);

            Shadow.transform.position = new Vector3(transform.position.x, transform.position.y, Shadow.transform.position.z);

            if (transform.position == NewDirection)
            {
                NewDirection = new Vector3((Random.Range(-7.5f, 5.5f)), (Random.Range(-3.5f, 0.5f)), -14f);

            }
        }

        else if (Timer > 3 && Enter == true && Exit == false)
        {
            NewDirection = new Vector3(transform.position.x, transform.position.y, -4.5f);

            transform.position = Vector3.MoveTowards(transform.position, NewDirection, step * 10);

            ShadowGrowth = new Vector3(transform.position.x, transform.position.y, -9.78f);

            Shadow.transform.position = Vector3.MoveTowards(Shadow.transform.position, ShadowGrowth, step);
            
          
        }

        else if (Timer >3 && Enter == false && Exit == false)
        {
            NewDirection = new Vector3(transform.position.x, transform.position.y, -14f);

            transform.position = Vector3.MoveTowards(transform.position, NewDirection, step * 10);

            ShadowGrowth = new Vector3(transform.position.x, transform.position.y, 0);

            Shadow.transform.position = Vector3.MoveTowards(Shadow.transform.position, ShadowGrowth, step);

            if (transform.position == NewDirection)
            {
                Exit = true;
            }
        }
        
        else if (Timer > 3 && Enter == false && Exit == true)
        {
            Destroy(gameObject.GetComponent<BoxCollider>());

            NewDirection = new Vector3(transform.position.x, -10, transform.position.z);

            transform.position = Vector3.MoveTowards(transform.position, NewDirection, step);

            ShadowGrowth = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            Shadow.transform.position = Vector3.MoveTowards(Shadow.transform.position, ShadowGrowth, step);

            if (transform.position.y == -10)
            {
                Destroy(FlippyBoi.gameObject);
            }
        }

        if (Shadow.transform.position.z <= transform.position.z)
        {
            ShadowSprite.color = new Color(1f, 1f, 1f, 0f);
        }

        else
        {
            ShadowSprite.color = new Color(1f, 1f, 1f, 0.5f);
        }
        
    }

}

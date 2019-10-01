using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public int Score;
    public float Timer;
    public GameObject SugarCubes;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        Timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
    }

    void SpawnSugarCube()
    {
        Instantiate(SugarCubes, new Vector3(Random.Range(-5, 5), Random.Range(-4, 4), -2.015f), Quaternion.identity);
    }

    void GrowAnt()
    {
        Player.transform.localScale = new Vector3((Player.transform.localScale.x + 0.01f), (Player.transform.localScale.y + 0.01f), (Player.transform.localScale.z + 0.01f));

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public int Score;
    public float Timer;
    public GameObject SugarCubes;
    public GameObject Player;
    public bool GameOver;
    public Canvas InGameUI;

    // Start is called before the first frame update
    void Start()
    {
        GameOver = false;
        Score = 0;
        Timer = 0;
        Player.GetComponent<Player_Movement>().enabled = true;
        Player.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
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

    public void RestartScene()
    {
        SceneManager.LoadScene(1);
        GameOver = false;
        Score = 0;
        Timer = 0;
        Player.GetComponent<Player_Movement>().enabled = true;
        Player.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        Player.GetComponent<Rigidbody2D>().transform.position = new Vector3(3.5f, 3.56f, -2.015f);
        Debug.LogFormat("Restarting");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);

    }
}

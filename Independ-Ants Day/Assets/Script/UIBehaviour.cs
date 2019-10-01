using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour
{
    public Text TimerText;
    public Text ScoreText;
    public GameManagerScript GMScript;

    // Start is called before the first frame update
    void Start()
    {
        GMScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        TimerText.text = "" + GMScript.Timer.ToString("f0");
        ScoreText.text = "" + GMScript.Score;
    }

}

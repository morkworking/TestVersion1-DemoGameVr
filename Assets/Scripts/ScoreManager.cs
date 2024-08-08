using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int scoreAmount;
    private Text score;

    void Start()
    {
        scoreAmount = 0;
        score = GetComponent<Text>();
    }
    public void Update()
    {
        score.text = scoreAmount.ToString();
    }

    public void AddScore()
    {
        scoreAmount += 1;
    }
}

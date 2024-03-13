using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static bool isGameOver = false;
    public static float countDown;
    public static bool gameStart = false;

    void Start()
    {
        countDown = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            if (countDown > 0)
            {
                countDown -= Time.deltaTime;
            }
            else
            {
                gameStart = true;
            }
        }
    }

    public void RaceComplete()
    {
        isGameOver = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public static float levelDuration = 180.0f;
    public Text timerText;
    public static float countDown;
    public static bool gameStart = false;
    static bool transportPlayer = false;
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        countDown = levelDuration;
        SetTimerText();
        timerText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart)
        {
            timerText.gameObject.SetActive(true);
            if (countDown > 0)
            {
                countDown -= Time.deltaTime;
            }
            else
            {
                countDown = 0.0f;
            }
            SetTimerText();
        }
    }

    private void FixedUpdate()
    {
        if (transportPlayer)
        {
            teleportPlayer();
        }
    }

    void SetTimerText()
    {
        timerText.text = countDown.ToString("0.00"); // 0.00 or f2
    }

    public static void doorIsClosed()
    {
        transportPlayer = true;
    }

    void teleportPlayer()
    {
        Debug.Log("tp");
        player.transform.position = new Vector3(-2.86599994f, 17.5160007f, 7.1500001f);
        Debug.Log(player.transform.position);
        transportPlayer = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGateBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (LevelManager.gameStart)
        {
            if(transform.localPosition.y >= 0)
            {
                Vector3 temp = new Vector3(0, -0.01f * Time.deltaTime, 0);
                transform.localPosition += temp;
            }
        }
        if (LevelManager.isGameOver)
        {
        }
    }
}

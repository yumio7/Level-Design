using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene("Interior");
        }
    }

    private void OnCollisionEnter(Collision col) 
    {
        if (col.gameObject.CompareTag("Loading Point")) {
            SceneManager.LoadScene("SampleScene");
        }
    }
}

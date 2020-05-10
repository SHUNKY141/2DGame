using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameExit : MonoBehaviour
{
    public int numberScene;
    public string playerTag;

    private void OnTriggerEnter2D(Collider2D other)

    {
        Debug.Log("!");
        if (other.tag == playerTag)
        {
            SceneManager.LoadScene(numberScene);
        }
    }
    }


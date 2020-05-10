using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Die : MonoBehaviour
{
    private PlayerController _player;
    void Start()
    {
        _player = GameObject.FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _player.ResetPosition();
    }
}
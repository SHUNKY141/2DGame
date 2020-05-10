using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform _player;
    private int deltaX = 2;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        if (h < 0) deltaX = -2;
        if (h > 0) deltaX = 2;
        transform.position = new Vector3
            (Mathf.Lerp(transform.position.x, _player.position.x + deltaX, Time.deltaTime * 3),
             Mathf.Lerp(transform.position.y, _player.position.y, Time.deltaTime * 5),
             transform.position.z);
    }
}

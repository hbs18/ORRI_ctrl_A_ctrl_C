using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private GameObject Player;
    private Vector3 offset = new Vector3(0f, 1f, -1f);

    void Awake()
    {
        Player = GameObject.Find("Player");
    }

    void LateUpdate()
    {
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, 0) + offset;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private float speed = 1f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(player.transform.position+new Vector3(0f,0f,-10f), Vector3.zero, speed * Time.deltaTime);
    }
}

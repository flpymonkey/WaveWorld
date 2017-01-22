using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMotion : MonoBehaviour {

    public float origY = 0;
    public GameObject player;
    float height;
    float width;
    // Use this for initialization
    void Start()
    {
        height = 2f * Camera.main.orthographicSize;
        width = height * Camera.main.aspect;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Camera.main.GetComponent<Transform>().position = new Vector3(player.transform.position.x + width/4, player.transform.position.y + 2, -10);
    }
}

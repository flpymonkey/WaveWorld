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
      
    }

    // Update is called once per frame
    void LateUpdate()
    {
        gameObject.GetComponent<Transform>().position = new Vector3(player.transform.position.x, origY);
    }
}

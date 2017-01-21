using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMotion : MonoBehaviour {


    public GameObject[] controls = new GameObject[5];

    private float goalHeight;

	// Use this for initialization
	void Start () {
        this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        this.gameObject.GetComponent<Rigidbody2D>().mass = 100;
    }
	
	// Update is called once per frame
	void Update () {
        goalHeight = 0;

        for (int i = 0; i < controls.Length; i++)
        {
            if (controls[i] != null)
            {
                float waveHeight = controls[i].GetComponent<WaveControlScript>().waveHeight;
                int waveWidth = controls[i].GetComponent<WaveControlScript>().waveWidth;

                goalHeight += waveHeight / (1 +
                    (Mathf.Pow((this.gameObject.transform.position.x - controls[i].GetComponent<WaveControlScript>().transform.position.x), 2) / waveWidth));
            }
        }
        float v = (goalHeight - this.gameObject.transform.position.y) *
            controls[0].GetComponent<WaveControlScript>().velocity;

        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, v);
        
	}
}

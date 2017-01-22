using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dholder : MonoBehaviour {

    public string dialogue;
    private DialogManager dMan;

	// Use this for initialization
	void Start () {
        dMan = FindObjectOfType<DialogManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.name == "player")
        {
              dMan.showBox(dialogue); 
              
        }
    }
}

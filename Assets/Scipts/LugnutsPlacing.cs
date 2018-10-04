using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LugnutsPlacing : MonoBehaviour {

    public int lugnuts;
    public Vector3 target;
	// Use this for initialization
	void Start () {
        lugnuts = 5;
	}
	
	// Update is called once per frame
	void Update () {
		if(lugnuts == 5)
        {
            target = new Vector3(0.14f, 0.78f);
        } else if(lugnuts == 4)
        {
            target = new Vector3(0.05f, 0.48f);
        }
        else if (lugnuts == 3)
        {
            target = new Vector3(0.3f, 0.67f);
        }
        else if (lugnuts == 2)
        {
            target = new Vector3(-0.02f, 0.67f);
        }
        else if (lugnuts == 1)
        {
            target = new Vector3(0.24f, 0.48f);
        }
        else if (lugnuts == 0)
        {
            // next Scene
            SceneManager.LoadScene(4);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TotalLugnuts : MonoBehaviour {

    public int lugnut;
	// Use this for initialization
	void Start () {
        lugnut = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(lugnut == 5)
        {
            SceneManager.LoadScene(2);
        }
	}
}

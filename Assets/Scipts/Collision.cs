using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {
    public GameObject car;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == car)
        {
            Vector3 shift = new Vector3(car.transform.position.x, car.transform.position.y + 0.1f, car.transform.position.z);
            car.transform.position = shift;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

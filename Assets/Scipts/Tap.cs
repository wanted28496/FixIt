using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap : MonoBehaviour {

    public GameObject piston;
    bool cooldownActivated;
    float spinningTime;
    float timeStarted;

    Quaternion rotateA;
    Quaternion rotateB;
    public bool atLocation = true;
    int count = 1;

    void RunCooldownTimer()
    {
        float timeSinceStarted = Time.time - timeStarted;
        float percentageComplete = timeSinceStarted / spinningTime;
        transform.rotation = Quaternion.Lerp(rotateA, rotateB, percentageComplete);

        if (percentageComplete >= 1)
        {
            cooldownActivated = false;
        }
    }

    public void Activate()
    {
        spinningTime = 0.5f;
        cooldownActivated = true;
        timeStarted = Time.time;
        float degree = 0;
        count++;
        if(count % 2 == 0)
        {
            degree = 20;
        }
        Transform thistransform = gameObject.transform;
        rotateA.eulerAngles = transform.rotation.eulerAngles;
        rotateB.eulerAngles = rotateA * new Vector3(0, 0, degree);
        

    }

	// Use this for initialization
	void Start () {
        
	}
	



	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0) && cooldownActivated == false && atLocation == true)
        {
            
            Activate();
            cooldownActivated = true;
            if(count > 2 && count % 2 != 0)
            {
                //Debug.Log("x");
                piston.transform.position = new Vector3(piston.transform.position.x, piston.transform.position.y + 0.1f, piston.transform.position.z);
                if(piston.transform.position.y > 2.0f)
                {

                }
            }
        } 
        if(cooldownActivated)
        {
            RunCooldownTimer();
        }

	}
}

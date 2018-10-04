using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackDown : MonoBehaviour
{
    public GameObject car;
    public GameObject piston;
    public GameObject Jack;
    bool cooldownActivated;
    float spinningTime;
    float timeStarted;
    int carDown = 0;
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
        float degree = 20;
        count++;
        if (count % 2 == 0)
        {
            degree = 0;
        }
        Transform thistransform = gameObject.transform;
        rotateA.eulerAngles = transform.rotation.eulerAngles;
        rotateB.eulerAngles = rotateA * new Vector3(0, 0, degree);


    }

    // Use this for initialization
    void Start()
    {
    }




    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && cooldownActivated == false && atLocation == true)
        {

            Activate();
            cooldownActivated = true;
            if (count > 2 && count % 2 != 0)
            {
                piston.transform.position = new Vector3(piston.transform.position.x, piston.transform.position.y - 0.1f, piston.transform.position.z);
                
                if(carDown < 3)
                {
                    car.transform.position = new Vector3(car.transform.position.x, car.transform.position.y - 0.1f, car.transform.position.z);
                }
                if (carDown >= 3)
                {
                    Debug.Log(piston.transform.position.y);
                    GetComponent<JackDown>().enabled = false;
                    Jack.GetComponent<RemoveJack>().enabled = true;
                    atLocation = false;

                }
                carDown++;
            }
        }
        if (cooldownActivated)
        {
            RunCooldownTimer();
        }

    }
}

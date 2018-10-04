using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapLugnut : MonoBehaviour
{
    public bool isReversed = false;
    bool cooldownActivated;
    float spinningTime;
    float timeStarted;
    Quaternion rotateA;
    Quaternion rotateB;
    public bool done = false;
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
        float degree;
        if (!isReversed)
        {
            degree = -30f;
        }
        else
        {
            degree = 30f;
        }
        Transform thistransform = gameObject.transform;
        rotateA.eulerAngles = transform.rotation.eulerAngles;
        rotateB.eulerAngles = rotateA * new Vector3(0, 0, degree * count);

        count++;
    }

    // Use this for initialization
    void Start()
    {

    }




    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && cooldownActivated == false && done == false)
        {
            Activate();
            cooldownActivated = true;
        }
        if (cooldownActivated)
        {
            RunCooldownTimer();
        }
        if (count == 6)
        {
            GetComponent<MoveLugnut>().enabled = true;
            done = true;

        }

    }
}

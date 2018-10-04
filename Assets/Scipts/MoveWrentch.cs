using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWrentch : MonoBehaviour {

    public Camera cam;
    public GameObject[] lugnuts = new GameObject[5];
    public Vector3 start;
    bool isDragging = false;
    bool isSet = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        getLocation(collision);
    }

    private void getLocation(Collider2D collision)
    {
        if (collision.gameObject == lugnuts[0] && !lugnuts[0].GetComponent<Wrentched>().done)
        {
            Vector3 pos = new Vector3(lugnuts[0].transform.position.x, lugnuts[0].transform.position.y, 10);
            transform.position = pos;
            isSet = true;
            GetComponent<MoveWrentch>().enabled = false;
            GetComponent<TapWrentch>().lugnet = lugnuts[0];
            GetComponent<TapWrentch>().enabled = true;
        }
        else if (collision.gameObject == lugnuts[1] && !lugnuts[1].GetComponent<Wrentched>().done)
        {
            Vector3 pos = new Vector3(lugnuts[1].transform.position.x, lugnuts[1].transform.position.y, 10);
            transform.position = pos;
            isSet = true;
            GetComponent<MoveWrentch>().enabled = false;
            GetComponent<TapWrentch>().lugnet = lugnuts[1];
            GetComponent<TapWrentch>().enabled = true;
        }
        else if (collision.gameObject == lugnuts[2] && !lugnuts[2].GetComponent<Wrentched>().done)
        {
            Vector3 pos = new Vector3(lugnuts[2].transform.position.x, lugnuts[2].transform.position.y, 10);
            transform.position = pos;
            isSet = true;
            GetComponent<MoveWrentch>().enabled = false;
            GetComponent<TapWrentch>().lugnet = lugnuts[2];
            GetComponent<TapWrentch>().enabled = true;
        }
        else if (collision.gameObject == lugnuts[3] && !lugnuts[3].GetComponent<Wrentched>().done)
        {
            Vector3 pos = new Vector3(lugnuts[3].transform.position.x, lugnuts[3].transform.position.y, 11);
            transform.position = pos;
            isSet = true;
            GetComponent<MoveWrentch>().enabled = false;
            GetComponent<TapWrentch>().lugnet = lugnuts[3];
            GetComponent<TapWrentch>().enabled = true;
        }
        else if (collision.gameObject == lugnuts[4] && !lugnuts[4].GetComponent<Wrentched>().done)
        {
            Vector3 pos = new Vector3(lugnuts[4].transform.position.x, lugnuts[4].transform.position.y, 10);
            transform.position = pos;
            isSet = true;
            GetComponent<MoveWrentch>().enabled = false;
            GetComponent<TapWrentch>().lugnet = lugnuts[4];
            GetComponent<TapWrentch>().enabled = true;

        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        getLocation(collision);
    }

    // Use this for initialization
    void Start () {
        start = transform.position;
    }


    void OnMouseDrag()
    {
        isDragging = true;
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        Vector3 obj = cam.ScreenToWorldPoint(mousePos);
        transform.position = obj;
    }
    void OnMouseUp()
    {
        if(isSet)
        {
            Debug.Log("x");
        }    
    }
    // Update is called once per frame
    void Update () {
		
	}
}

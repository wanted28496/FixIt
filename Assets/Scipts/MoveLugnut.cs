using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLugnut : MonoBehaviour {
    public GameObject placer;
    public Camera cam;
    public Vector3 start;
    bool isDragging = false;

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
        isDragging = false;
        Vector3 pos = transform.position;
        if (pos.y <= -0.66 && pos.y >= -1 && pos.x >= -0.193 && pos.x <= 0.5)
        {
            GetComponent<MoveLugnut>().enabled = false;
            placer.GetComponent<TotalLugnuts>().lugnut += 1;
        }
        else
        {
            transform.position = start;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}

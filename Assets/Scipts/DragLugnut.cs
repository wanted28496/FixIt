using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragLugnut : MonoBehaviour
{
    public GameObject placer;
    public Camera cam;
    public Vector3 start;
    bool isDragging = false;
    public bool isDone = false;

    // Use this for initialization
    void Start()
    {
        start = transform.position;
    }

    void OnMouseDrag()
    {
        if (!isDone)
        {
            isDragging = true;
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            Vector3 obj = cam.ScreenToWorldPoint(mousePos);
            transform.position = obj;
        }  
    }

    void OnMouseUp()
    {
        if(!isDone)
        {
            Vector3 target = placer.GetComponent<LugnutsPlacing>().target;
            isDragging = false;
            Vector3 pos = transform.position;
            float minx = target.x - 0.08f;
            float maxx = target.x + 0.08f;
            float miny = target.y - 0.08f;
            float maxy = target.y + 0.08f;
            if (pos.y >= miny && pos.y <= maxy && pos.x >= minx && pos.x <= maxx)
            {
                transform.position = new Vector3(target.x, target.y, 0);
                GetComponent<DragLugnut>().enabled = false;
                GetComponent<SpinLugnuts>().enabled = true;
                isDone = true;
            }
            else
            {
                transform.position = start;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}

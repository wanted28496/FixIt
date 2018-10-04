using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragJack : MonoBehaviour {

    public GameObject car;
    public GameObject lever;
    public Camera cam;
    bool isDragging = false;
    Vector3 start;
    void Start()
    {
        start = transform.position;    
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(isDragging && collision.gameObject == car)
        {
            //fail logic
        }
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
        if(pos.y <= -1.5 && pos.y >= -1.6 && pos.x <= -1.8 && pos.x >= -2.5)
        {
            GetComponent<DragJack>().enabled = false;
            Tap tx = lever.GetComponent<Tap>();
            tx.enabled = true;
        }else
        {
            transform.position = start;
        }
    }
}

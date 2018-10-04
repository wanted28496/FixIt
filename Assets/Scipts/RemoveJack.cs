using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RemoveJack : MonoBehaviour
{

    public GameObject car;
    public Camera cam;
    bool isDragging = false;
    Vector3 start;
    void Start()
    {
        start = transform.position;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDragging && collision.gameObject == car)
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
        if (pos.y <= -3)
        {
            Debug.Log("Made It");
            GetComponent<DragJack>().enabled = false;
            SceneManager.LoadScene(5);
        }
        else
        {
            transform.position = start;
        }
    }
}

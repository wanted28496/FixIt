using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScaleAndDrag : MonoBehaviour {

    public GameObject otherTire;
    public bool isReversed = false;
    public Camera cam;
    public Vector3 start;
    bool isDragging = false;
    // Use this for initialization
    void Start () {
        start = transform.position;
    }


    void OnMouseDrag()
    {
        if(!isReversed)
        {
            transform.localScale = new Vector3(0.3f, 0.3f, 1f);
        } else
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        }
        isDragging = true;
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        Vector3 obj = cam.ScreenToWorldPoint(mousePos);
        transform.position = obj;
    }

    void OnMouseUp()
    {
        isDragging = false;
        Vector3 pos = transform.position;
        if(!isReversed)
        {
            if (pos.y >= -3.2 && pos.y <= -2.8 && pos.x >= -0.22 && pos.x <= 0.25)
            {
                GetComponent<ScaleAndDrag>().enabled = false;
                otherTire.GetComponent<ScaleAndDrag>().enabled = true;
            }
            else
            {
                transform.localScale = new Vector3(0.5f, 0.5f, 1f);
                transform.position = start;
            }
        } else
        {
            if (pos.x >= 0 && pos.x <= 0.50 && pos.y >= 0.3 && pos.y <= 0.8)
            {
                pos = new Vector3(0.162f, 0.617f, 0);
                transform.position = pos;
                GetComponent<ScaleAndDrag>().enabled = false;
                // Next Scene
                SceneManager.LoadScene(3);
            }
            else
            {
                transform.localScale = new Vector3(0.3f, 0.3f, 1f);
                transform.position = start;
            }
        }
        
    }


    // Update is called once per frame
    void Update () {
		
	}
}

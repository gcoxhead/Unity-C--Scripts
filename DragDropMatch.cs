using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropMatch: MonoBehaviour
{
    //This script should be attached to gameobject that is to be dragged.
    
    //This gameobject is the position or item that you intent the object to be dropped to
    public GameObject correctForm;
    public bool moving;
    
    //This is the starting position of the draggable game object
    private float startPosX;
    private float startPosY;

    // Adjustments to required object drop accuracy
    public float XDropAccuracy;
    public float YDropAccuracy;
    
    //variable to hold transform values of the draggable object when the scene is loaded 
    private Vector3 resetPosition;

    // Start is called before the first frame update
    void Start()
    {
        resetPosition = this.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(moving)
        {
            MoveObjectWithMouse();
            ///TO DO ... Extract into a function
            //Vector3 mousePos;
            //mousePos = Input.mousePosition;
            //mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            //this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.localPosition.z);
        }
        
    }

    private void MoveObjectWithMouse()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.localPosition.z);

    }


    private void OnMouseDown()
    {
        Debug.Log("Mouse Down");
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        startPosX = mousePos.x - this.transform.localPosition.x;
        startPosY = mousePos.y - this.transform.localPosition.y;

        moving = true;

    }

    private void OnMouseUp()
    {
        moving = false;
        Debug.Log("On Mouse Up");

        if (Mathf.Abs(this.transform.localPosition.x - correctForm.transform.localPosition.x)<=XDropAccuracy &&
            Mathf.Abs(this.transform.localPosition.y - correctForm.transform.localPosition.y) <= YDropAccuracy)
        {
            this.transform.localPosition = new Vector3(correctForm.transform.localPosition.x, correctForm.transform.localPosition.y, correctForm.transform.localPosition.z);
        }
        else
        {
            this.transform.localPosition = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
        }
        
    }
}

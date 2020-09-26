using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public float gridSize = 0.5f;
    public bool snapToGrid = true;
    public bool smartDrag = true;
    public bool isDraggable = true;
    public bool isDragged = false;
    Vector2 initialPositionMouse;
    Vector2 initialPositionObject;
    
 
    // Update is called once per frame
    void Update()
    {
        if(isDragged)
        {
            if(!smartDrag)
            {
                transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            else
            {
                transform.position = initialPositionObject + (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - initialPositionMouse;
            }
            if(snapToGrid)
            {
                transform.position = new Vector2(Mathf.RoundToInt(transform.position.x/gridSize)*gridSize, Mathf.RoundToInt(transform.position.y/gridSize)*gridSize);
            }
           // RectTransform rt = (RectTransform)transform;
           // float width = rt.rect.width/2;
           // float height = rt.rect.height/2;
           // transform.position = new Vector2(Mathf.Clamp(transform.position.x,1.5f,12.5f),Mathf.Clamp(transform.position.y,3.0f,6.5f));
          /*  Vector2 myPosition = transform.position;
            Vector2 boundary = new Vector2(7, 3);
            myPosition.x = Mathf.Clamp(myPosition.x, boundary.x, boundary.x * -1);
            myPosition.y = Mathf.Clamp(myPosition.y, boundary.y, boundary.y * -1);
            transform.position = myPosition;
            */
                 if (transform.position.x<1)
                     transform.position = new Vector2(1.0f, Mathf.RoundToInt(transform.position.y));
                 if (transform.position.y < 2)
                     transform.position = new Vector2(Mathf.RoundToInt(transform.position.x), 2.0f);
                 if (transform.position.y > 6)
                     transform.position = new Vector2(Mathf.RoundToInt(transform.position.x), 6.0f);
                 if (transform.position.x > 12)
                     transform.position = new Vector2(12.0f, Mathf.RoundToInt(transform.position.y));
        }
    }


    private void OnMouseOver()
    {
        if(isDraggable && Input.GetMouseButtonDown(0))
        {
            if(smartDrag)
            {
                initialPositionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                initialPositionObject = transform.position;
            }
            isDragged = true;
        }
       
    }
    public void OnMouseUp()
    {
        isDragged = false;
    }
}
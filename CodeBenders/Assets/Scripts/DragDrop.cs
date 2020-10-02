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
        float tileWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        float tileHeight = GetComponent<SpriteRenderer>().bounds.size.y;
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
            if ((transform.position.x - tileWidth/2)<-17.15)
              transform.position = new Vector2(-17.15f+tileWidth/2, Mathf.RoundToInt(transform.position.y));
            if ((transform.position.y - tileHeight/2) < 1.85)
              transform.position = new Vector2(Mathf.RoundToInt(transform.position.x), 1.85f+tileHeight/2);
            if ((transform.position.y+tileHeight/2) > 9.85)
              transform.position = new Vector2(Mathf.RoundToInt(transform.position.x), 9.85f-tileHeight/2);
            if ((transform.position.x+tileWidth/2) > -8.15)
              transform.position = new Vector2(-8.15f-tileWidth/2, Mathf.RoundToInt(transform.position.y));
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

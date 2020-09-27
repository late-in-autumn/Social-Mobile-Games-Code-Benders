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
            if ((transform.position.x - tileWidth/2)<1)
              transform.position = new Vector2(1.0f+tileWidth/2, Mathf.RoundToInt(transform.position.y));
            if ((transform.position.y - tileHeight/2) < 2)
              transform.position = new Vector2(Mathf.RoundToInt(transform.position.x), 2.0f+tileHeight/2);
            if ((transform.position.y+tileHeight/2) > 8)
              transform.position = new Vector2(Mathf.RoundToInt(transform.position.x), 8.0f-tileHeight/2);
            if ((transform.position.x+tileWidth/2) > 13)
              transform.position = new Vector2(13.0f-tileWidth/2, Mathf.RoundToInt(transform.position.y));
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

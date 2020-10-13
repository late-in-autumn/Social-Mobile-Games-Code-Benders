using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public float gridSize = 0.5f;
    public bool snapToGrid = true;
    public bool smartDrag = true;
    public bool isDraggable = true;
    public bool isDragged = false;
    private Vector2 initialPositionMouse;
    private Vector2 initialPositionObject;


    // Update is called once per frame
    private void Update()
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
            // Constrains Player 1's objects to the grid
            // Takes into account grid's offset in coordinate system
            if(gameObject.tag == "BuildingBlock" || gameObject.tag == "Enemy")
            {
              if ((transform.position.x - tileWidth/2)<-17.15)
                transform.position = new Vector2(-17.15f+tileWidth/2, Mathf.RoundToInt(transform.position.y));
              if ((transform.position.y - tileHeight/2) < 1.85)
                transform.position = new Vector2(Mathf.RoundToInt(transform.position.x), 1.85f+tileHeight/2);
              if ((transform.position.y+tileHeight/2) > 9.85)
                transform.position = new Vector2(Mathf.RoundToInt(transform.position.x), 9.85f-tileHeight/2);
              if ((transform.position.x+tileWidth/2) > -8.15)
                transform.position = new Vector2(-8.15f-tileWidth/2, Mathf.RoundToInt(transform.position.y));
            }
            // Constrains Player 2's objects to the grid
            else
            {
              if ((transform.position.x - tileWidth/2)<11.4)
                transform.position = new Vector2(11.4f+tileWidth/2, Mathf.RoundToInt(transform.position.y));
              if ((transform.position.y - tileHeight/2) < 1.85)
                transform.position = new Vector2(Mathf.RoundToInt(transform.position.x), 1.85f+tileHeight/2);
              if ((transform.position.y+tileHeight/2) > 9.85)
                transform.position = new Vector2(Mathf.RoundToInt(transform.position.x), 9.85f-tileHeight/2);
              if ((transform.position.x+tileWidth/2) > 20.4)
                transform.position = new Vector2(20.4f-tileWidth/2, Mathf.RoundToInt(transform.position.y));
            }
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
        if(snapToGrid)
        {
            // Snapping Player 1's objects to grid
            // takes into account the grid's offset from the coordinate system
            if(gameObject.tag == "BuildingBlock" || gameObject.tag == "Enemy")
            {
              if (transform.position.x - (int) transform.position.x < 0.45)
                if (transform.position.y - (int) transform.position.y < 0.15 || transform.position.y - (int) transform.position.y > 0.65)
                  transform.position = new Vector2(Mathf.Floor(transform.position.x) + 0.335f, Mathf.RoundToInt(transform.position.y) + 0.375f);
                else
                  transform.position = new Vector2(Mathf.Floor(transform.position.x) + 0.335f, Mathf.Floor(transform.position.y) + 0.375f);
              else if (transform.position.x - (int) transform.position.x > 0.95)
                if (transform.position.y - (int) transform.position.y < 0.15 || transform.position.y - (int) transform.position.y > 0.65)
                  transform.position = new Vector2(Mathf.Floor(transform.position.x) - 0.665f, Mathf.RoundToInt(transform.position.y) + 0.375f);
                else
                  transform.position = new Vector2(Mathf.Floor(transform.position.x) - 0.665f, Mathf.Floor(transform.position.y) + 0.375f);
              else
                if (transform.position.y - (int) transform.position.y < 0.15 || transform.position.y - (int) transform.position.y > 0.65)
                  transform.position = new Vector2(Mathf.Ceil(transform.position.x) + 0.335f, Mathf.RoundToInt(transform.position.y) + 0.375f);
                else
                  transform.position = new Vector2(Mathf.Ceil(transform.position.x) + 0.335f, Mathf.Floor(transform.position.y) + 0.375f);
            }
            // Snapping Player 2's objects to grid
            else
            {
              if (transform.position.x - (int) transform.position.x < 0.5)
                if (transform.position.y - (int) transform.position.y < 0.15 || transform.position.y - (int) transform.position.y > 0.65)
                  transform.position = new Vector2(Mathf.Floor(transform.position.x - 1.0f) + 0.9f, Mathf.RoundToInt(transform.position.y) + 0.375f);
                else
                  transform.position = new Vector2(Mathf.Floor(transform.position.x - 1.0f) + 0.9f, Mathf.Floor(transform.position.y) + 0.375f);
              else
                if (transform.position.y - (int) transform.position.y < 0.15 || transform.position.y - (int) transform.position.y > 0.65)
                  transform.position = new Vector2(Mathf.Floor(transform.position.x) + 0.9f, Mathf.RoundToInt(transform.position.y) + 0.375f);
                else
                  transform.position = new Vector2(Mathf.Floor(transform.position.x) + 0.9f, Mathf.Floor(transform.position.y) + 0.375f);
            }
        }
        isDragged = false;
    }
}

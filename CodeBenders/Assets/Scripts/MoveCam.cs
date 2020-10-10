using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{

    public Transform[] views;
    public float transitionSpeed;
    Transform currentView;
    public int[] sizes;
    int currentSize;
    public bool buildMode = true;

    // Start is called before the first frame update
    void Start()
    {
        currentView = views[1];
        currentSize = sizes[1];
    }

    // Update is called once per frame
    void Update()
    {
        /* Manual Camera Switching*/
         
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            currentView = views[0];
            currentSize = sizes[0];
        }

        if(Input.GetKeyDown(KeyCode.Alpha2)) {
            currentView = views[1];
            currentSize = sizes[1];
        }
        
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);
        Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, currentSize, Time.deltaTime * transitionSpeed);
    }

    public void EnterBuildMode()
    {
        if (buildMode != true)
            buildMode = true;

        currentView = views[1];
        currentSize = sizes[1];

    }

    public void ExitBuildMode()
    {
        if (buildMode != false)
            buildMode = false;

        currentView = views[0];
        currentSize = sizes[0];
    }

}
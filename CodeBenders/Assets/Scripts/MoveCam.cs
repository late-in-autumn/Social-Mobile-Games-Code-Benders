using UnityEngine;

public class MoveCam : MonoBehaviour
{

    public Transform[] views;
    public float transitionSpeed;
    private Transform currentView;
    public int[] sizes;
    private int currentSize;
    public int buildMode = 0;

    // Start is called before the first frame update
    private void Start()
    {
        SwitchCameraMode(1);
    }

    // Update is called once per frame
    private void Update()
    {
        /* Manual Camera Switching*/
         
/*
         if(Input.GetKeyDown(KeyCode.Alpha1)) {
            currentView = views[0];
            currentSize = sizes[0];
        }

        if(Input.GetKeyDown(KeyCode.Alpha2)) {
            currentView = views[1];
            currentSize = sizes[1];
        } 
*/
        
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);
        Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, currentSize, Time.deltaTime * transitionSpeed);
    }

    public void SwitchCameraMode(int mode){
        buildMode = mode;
        foreach(Transform t in views){
            Debug.Log(t.ToString());
        }
        currentView = views[mode];
        currentSize = sizes[mode];
    }

    /* Legacy Code
    public void Player1BuildMode(){
        buildMode = 1;

        currentView = views[1];
        currentSize = sizes[1];

    }

    public void Player2BuildMode(){
        buildMode = 2;

        currentView = views[2];
        currentSize = sizes[2];
    }

    public void BattleMode(){
        buildMode = 0;

        currentView = views[0];
        currentSize = sizes[0];

    } 
    */

}
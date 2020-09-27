// To use this example, attach this script to an empty GameObject.
// Create three buttons (Create>UI>Button). Next, select your
// empty GameObject in the Hierarchy and click and drag each of your
// Buttons from the Hierarchy to the Your First Button, Your Second Button
// and Your Third Button fields in the Inspector.
// Click each Button in Play Mode to output their message to the console.
// Note that click means press down and then release.

using UnityEngine;
using System;
using UnityEngine.UI;

public class tryButton : MonoBehaviour
{
    //Make sure to attach these Buttons in the Inspector
    public Button Battle;
    public Rigidbody2D[] buildingBlocks;
    public MoveCam moveCam;
    public GameObject[] enemies;

    void Start()
    {
        Battle.onClick.AddListener(TaskOnClick);

    }

    void TaskOnClick()
    {
        //Output this to console when Button1 or Button3 is clicked
        //Debug.Log("You have clicked the button!");
        buildingBlocks = FindObjectsOfType(typeof(Rigidbody2D)) as Rigidbody2D[];
        foreach (Rigidbody2D buildingBlock in buildingBlocks)
        {
            if (buildingBlock.tag == "BuildingBlock")
            {
                buildingBlock.constraints = RigidbodyConstraints2D.None;
            }
        }
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            enemy.GetComponent<Enemy>().enabled = true;
            enemy.GetComponent<DragDrop>().enabled = false;

        }
        moveCam.ExitBuildMode();
    }
    
}
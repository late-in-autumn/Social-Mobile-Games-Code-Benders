using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D[] buildingBlocks;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonInteract()
    {
       // Debug.Log("Our button was clicked");
        buildingBlocks = FindObjectsOfType(typeof(Rigidbody2D)) as Rigidbody2D[];
        foreach (Rigidbody2D buildingBlock in buildingBlocks)
        {
            if (buildingBlock.tag == "BuildingBlock")
            {
                buildingBlock.constraints = RigidbodyConstraints2D.None;
            }
        }
    }
}
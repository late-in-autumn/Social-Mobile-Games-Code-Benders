using System.Collections;
using System.Collections.Generic;
 using UnityEngine;

 using UnityEngine.UI;

public class Check : MonoBehaviour
{
	public GameObject but;

	
    // Start is called before the first frame update
    void Start()
    {
        but = GameObject.FindWithTag("Battle");
        but.GetComponent<Button> ().interactable = false;
    }

    // Update is called once per frame
    public void Change(int player)
    {
    	Debug.Log("here in change");
        but = GameObject.FindWithTag("Battle");
        string blockTagname = (player == 1) ? "BuildingBlock" : "BuildingBlockP2";
        string targetTagname = (player == 1) ? "Enemy" : "EnemyP2";
    	GameObject[] buildingBlocks = GameObject.FindGameObjectsWithTag(blockTagname);
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTagname);
    	
    	int count = 0;
        for(int i =0;i<buildingBlocks.Length;i++)
        {
        	if(buildingBlocks[i].GetComponent<Block>().insideGrid == true)
            
            {
                count +=1;
            }
        }

        for(int i =0;i<targets.Length;i++)
        {
            if(targets[i].GetComponent<Target>().inside_grid == true)
            
            {
                count +=1;
            }
        }
        Debug.Log(count);
        if(count == 12) {
        	but.GetComponent<Button> ().interactable = true;
        }
        
        
    }

    public void click() {
        but = GameObject.FindWithTag("Battle");
        but.GetComponent<Button> ().interactable = false;
    }
}


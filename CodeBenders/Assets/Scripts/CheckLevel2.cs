using UnityEngine;

 using UnityEngine.UI;

public class CheckLevel2 : MonoBehaviour
{
	public GameObject but;
    
    // Start is called before the first frame update
    void Start()
    {
        but = GameObject.FindWithTag("Battle");
        but.GetComponent<Button>().interactable = false;
    }

    // Update is called once per frame
    public void Change(int player)
    {
    	Debug.Log("here in change");
        but = GameObject.FindWithTag("Battle");
        string stoneBlockTagname = (player == 1) ? "BuildingBlock" : "BuildingBlockP2";
        string woodenBlockTagname = (player == 1) ? "WoodenP1" : "WoodenP2";
        string targetTagname = (player == 1) ? "Enemy" : "EnemyP2";
    	GameObject[] stoneBuildingBlocks = GameObject.FindGameObjectsWithTag(stoneBlockTagname);
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTagname);
        GameObject[] woodenBuildingBlocks = GameObject.FindGameObjectsWithTag(woodenBlockTagname);
    	
    	int count = 0;
        for(int i =0;i<stoneBuildingBlocks.Length;i++)
        {
        	if(stoneBuildingBlocks[i].GetComponent<Block>().insideGrid == true)
            {
                count +=1;
            }
        }

        for(int i=0;i<woodenBuildingBlocks.Length; i++) {
        	if(woodenBuildingBlocks[i].GetComponent<Block>().insideGrid == true)
            
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

    public void Click() {
        but = GameObject.FindWithTag("Battle");
        but.GetComponent<Button> ().interactable = false;
    }
}


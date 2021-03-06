﻿using UnityEngine;
using UnityEngine.UI;

public class ControlButton : MonoBehaviour
{
    //Make sure to attach these Buttons in the Inspector
    public Button battle;
    public Rigidbody2D[] buildingBlocks;
    public MoveCam moveCam;
    public GameObject[] enemiesP1;
    public GameObject[] enemiesP2;
    public GameObject[] blocksP1;
    public GameObject[] blocksP2;
    private bool _player2Build = false;

    private void Start()
    {
        battle.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        switch(_player2Build){
            case false:
                GameObject.FindWithTag("Battle").GetComponentInChildren<Text>().text = "Start Battle!";
                _player2Build = true;
                moveCam.SwitchCameraMode(2);
                break;

            case true:
                //Output this to console when Button1 or Button3 is clicked
                //Debug.Log("You have clicked the button!");

                // Once 'Start Battle' Button has been Clicked, Disable the Button as it is no longer needed!
                battle.gameObject.SetActive(false);
                GameObject[] grids = GameObject.FindGameObjectsWithTag("TileMap");
                for(int i=0; i < grids.Length; i++) {
                    grids[i].SetActive(false);
                }
                
                buildingBlocks = FindObjectsOfType(typeof(Rigidbody2D)) as Rigidbody2D[];
                if (buildingBlocks != null)
                    foreach (Rigidbody2D buildingBlock in buildingBlocks)
                    {
                        if (buildingBlock.tag.Contains("BuildingBlock")
                            || buildingBlock.tag.Contains("Wooden"))
                        {
                            buildingBlock.constraints = RigidbodyConstraints2D.None;
                        }
                    }

                // enable enemies for player 1
                enemiesP1 = GameObject.FindGameObjectsWithTag("Enemy");
                foreach(GameObject enemy in enemiesP1)
                {
                    enemy.GetComponent<Enemy>().enabled = true;
                    enemy.GetComponent<Enemy>().battleMode = true;
                    enemy.GetComponent<DragDrop>().enabled = false;

                }
                blocksP1 = GameObject.FindGameObjectsWithTag("BuildingBlock");
                foreach(GameObject block in blocksP1)
                {
                    block.GetComponent<DragDrop>().enabled = false;
                    block.GetComponent<Block>().battleMode = true;
                }
                
                blocksP1 = GameObject.FindGameObjectsWithTag("WoodenP1");
                foreach(GameObject block in blocksP1)
                {
                    block.GetComponent<DragDrop>().enabled = false;
                    block.GetComponent<Block>().battleMode = true;
                }

                // enable slingshot reload for player 1
                // only player 1 is enabled because player 1 goes first
                GameObject.FindWithTag("SlingshotP1").SendMessage("EnableSlingshotReloading");

                // enable enemies for player 2
                // **should be moved till after 2nd player build phase**
                enemiesP2 = GameObject.FindGameObjectsWithTag("EnemyP2");
                foreach(GameObject enemy in enemiesP2)
                {
                    enemy.GetComponent<Enemy>().enabled = true;
                    enemy.GetComponent<Enemy>().battleMode = true;
                    enemy.GetComponent<DragDrop>().enabled = false;
                }

                blocksP2 = GameObject.FindGameObjectsWithTag("BuildingBlockP2");
                foreach(GameObject block in blocksP2)
                {
                    block.GetComponent<DragDrop>().enabled = false;
                    block.GetComponent<Block>().battleMode = true;
                }
                
                blocksP2 = GameObject.FindGameObjectsWithTag("WoodenP2");
                foreach(GameObject block in blocksP2)
                {
                    block.GetComponent<DragDrop>().enabled = false;
                    block.GetComponent<Block>().battleMode = true;
                }

                moveCam.SwitchCameraMode(0);
                break;
        }
    }

}

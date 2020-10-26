using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    public string pl1;
    public string pl2;
    // Start is called before the first frame update
    public Rigidbody2D[] buildingBlocks;

    private void Start()
    {
        pl1 = GameObject.FindWithTag("pl1").GetComponent<InputField>().text;
        pl2 = GameObject.FindWithTag("pl2").GetComponent<InputField>().text;
        GameObject.FindWithTag("Menu").GetComponent<Canvas>().enabled = false;
        GameObject.FindWithTag("gameOver").GetComponent<Canvas>().enabled = false;
        GameObject.FindWithTag("DisplayPl1").GetComponent<Text>().text = pl1;
        GameObject.FindWithTag("DisplayPl2").GetComponent<Text>().text = pl2;

    }
    // Update is called once per frame
    private void Update()
    {

    }

    public void ButtonInteract()
    {
       // Debug.Log("Our button was clicked");
        buildingBlocks = FindObjectsOfType(typeof(Rigidbody2D)) as Rigidbody2D[];
        foreach (Rigidbody2D buildingBlock in buildingBlocks)
        {
            if (buildingBlock.tag.Contains("BuildingBlock"))
            {
                buildingBlock.constraints = RigidbodyConstraints2D.None;
            }
        }
    }
}

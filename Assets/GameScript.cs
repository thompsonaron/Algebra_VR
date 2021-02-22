using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    public GameObject[] toys;
    public GameObject[] spawnPoints;
    public Text info;
    public Text info2;
    public GameObject winPanel;

    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        RandomSpawnItem();
        info.text = "Found " + counter + " toys.";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Toy")
        {
            Debug.Log("WOOPTOY");
            other.gameObject.tag = "Untagged";
            Destroy(other.gameObject, 1.5f);
            counter++;
            info.text = "Found " + counter + " toys.";
            if (counter == 4)
            {
                info.text = "Found all the toys!!";
                winPanel.SetActive(true);
            }
            else
            {
                RandomSpawnItem();
 
            }
        }
       
    }

    public void RandomSpawnItem()
    {
        int toyIDRandom = Random.Range(0, 3);
        int posRand = Random.Range(0, 3);


        Instantiate(toys[toyIDRandom], spawnPoints[posRand].transform.position, Quaternion.identity);
        info2.text = "Find the " + toys[toyIDRandom].name + " and put it in the chest";


    }

}

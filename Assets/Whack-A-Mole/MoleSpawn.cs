using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MoleSpawn : MonoBehaviour
{
    public GameObject molePrefab;
    public Transform[] spawnPoints;
    public float gameTime;
    public Text gameText;


    public void spawn()
    {
        GameObject mole = Instantiate(molePrefab) as GameObject;
        mole.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;

    }


    // Start is called before the first frame update
    void Start()
    {
        spawn();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        gameTime -= Time.deltaTime;
        if (gameTime < 1)
        {
            gameTime = 0;
        }
        gameText.text = gameTime.ToString("0");

        if (gameTime == 0)
        {
            Application.Quit();
        }
    }
       
}

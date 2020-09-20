using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HammerController : MonoBehaviour
{
    public Text scoreText;
    public int score;
    private MoleSpawn ms;
    private GameObject SM;
    float range = 10f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        ms = GetComponent<MoleSpawn>();
        SM = GameObject.FindGameObjectWithTag("ScenarioManager");

    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
        Destroy(other);
        score = score + 1;
        scoreText.text = score.ToString();
        ms.spawn();
    }
}

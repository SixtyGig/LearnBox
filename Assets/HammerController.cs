using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HammerController : MonoBehaviour
{
    public Text scoreText;
    public int score;
    private MoleSpawn ms;
    float range = 10f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        ms = GetComponent<MoleSpawn>();

    }

    // Update is called once per frame
    void Update()
    {
        
       

        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Enemy")
                {
                    Debug.Log("hit");
                    Destroy(hit.collider.gameObject); 
                    score = score +1;
                    scoreText.text = score.ToString();
                    ms.spawn();
            
                }
            }

        }
        Debug.DrawLine(transform.position, transform.forward * range);
        {
            
        }
    }
}

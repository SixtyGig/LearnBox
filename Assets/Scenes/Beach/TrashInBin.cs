using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashInBin : MonoBehaviour
{
    public int trashPicked;
    public int trashTotal;
    private GameObject manager;
    private ScenarioManager scene;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("ScenarioManager");
        scene = manager.GetComponent<ScenarioManager>();
        trashPicked = 0;
        trashTotal = 8;
    }

    // Update is called once per frame
    void Update()
    {
        if (trashPicked >= trashTotal)
        {
            scene.tasklist["PickUpTrash"] = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        trashPicked++;
        Destroy(other.gameObject);
    }
}

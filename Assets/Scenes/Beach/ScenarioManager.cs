using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScenarioManager : MonoBehaviour
{
    // NOTE: This script is applied on an empty game object within the scene that it's applied to an empty GameObject (with the ScenarioManager tag)


    // + MAIN MANAGEMENT SOFTWARE +


    // Extra Variables
    private string scene;
    
    private bool checklistComplete = false;
    

    // GameObjects to Locate
    private GameObject scenarioManager;
    private GameObject gameTimer;
    private GameObject descriptionUI; // An object in the scene that contains a task description



    // Task list
    // Each entry into the tasklist must contain a [String - Name of task] and a [True/False value] expressing if a task has been completed or not
    private Dictionary<string, bool> tasklist = new Dictionary<string, bool>();
    
    // Task Instructions
    // Each entry contains the [TaskName] and [The text we'd like to display as instructions]
    private Dictionary<string, string> taskInstruct = new Dictionary<string, string>()
    {
        // Main Menu
        { "StartApp" , "Welcome to LearnBox! This is an educational environment where you can learn how " },
        { "ChooseLocation" , "Give it a go! Select one of the following options to get started!" },
        // Beach Activity
        { "CountClouds" , "Wow, it's a great day out today! Could you please help me count the clouds?" },
        { "PickUpTrash" , "" },
        { "LocateWaterBottles" , "" },
        // Whack-A-Mole Activity
        { "WhackAMole" , "The rats are taking over my home! Would you deal with these pests for me? Thank you!" }
    };


    // + CHECKLISTS AND SETTINGS +
    private void setupMainMenu()
    {
        tasklist.Add("StartApp", true);
        tasklist.Add("ChooseLocation", false);
        //WaitFiveSeconds();



    }
    private void setupBeachScene() 
    {
        tasklist.Add("CountClouds", false);
        tasklist.Add("PickUpTrash", false);
        tasklist.Add("LocateWaterBottles", false);
    }
    private void setupWhackAMole() 
    {
        tasklist.Add("WhackAMole", false);
    }

    // Pause for 5 seconds, for the user to read the instructions
    IEnumerator WaitFiveSeconds() { yield return new WaitForSeconds(5); }


    // On Update
    public void Update()
    {
        if (scene == "MainMenu")
        {
            
        }
        else if (scene == "Beach")
        {

        }
        else if (scene == "WhackAMole")
        {
            
        }
        else 
        {
            // Do nothing
        }
    }

    // + IN-EDITOR SELECTION +

    // On Awake
    // Locate the Scenario Manager
    private void Awake()
    {
        scenarioManager = GameObject.FindGameObjectWithTag("ScenarioManager");
        gameTimer = GameObject.FindGameObjectWithTag("Timer");
    }

    // On Start
    private void Start()
    {
        // Set Scene Checklist & Settings
        if (scene == "MainMenu")
        {
            Debug.Log(scene + " has been selected");
            setupMainMenu();
            
        }
        else if (scene == "Beach")
        {
            Debug.Log(scene + " has been selected");
            setupBeachScene();
        }
        else if (scene == "WhackAMole")
        {
            Debug.Log(scene + " has been selected");
            setupWhackAMole();
        }
        else
        {
            Debug.Log("No scene has been selected");
        }
    }

    public enum MenuItems 
    {
        MainMenu,   // Main Menu 
        Beach,  // Beach Activity  
        WhackAMole     // Whack-A-Mole Activity
        //To add additional options, type them here along with adding the selection case in MenuSelection
    }
    public MenuItems activity;

    public void MenuSelection() 
    {
        switch (activity) 
        {
            case MenuItems.MainMenu:
                scene = "MainMenu";
                break;
            case MenuItems.Beach:
                scene = "Beach";
                break;
            case MenuItems.WhackAMole:
                scene = "WhackAMole";
                break;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScenarioManager : MonoBehaviour
{
    // NOTE: This script is applied on an empty game object within the scene that it's applied to an empty GameObject (with the ScenarioManager tag)


    // + MAIN MANAGEMENT SOFTWARE +


    // Extra Variables
    private string scene;
    public float gameTime = 20;
    public int gameScore = 0;
    public bool gameOverBool = false;
    private bool checklistComplete = false;
    

    // GameObjects to Locate
    private GameObject scenarioManager;
    // WAM GameObjects
    private GameObject gameTimer;
    private GameObject gameScoreText;


    private GameObject descriptionUI; // An object in the scene that contains a task description



    // Task list
    // Each entry into the tasklist must contain a [String - Name of task] and a [True/False value] expressing if a task has been completed or not
    public Dictionary<string, bool> tasklist = new Dictionary<string, bool>();
    
    // Task Instructions
    // Each entry contains the [TaskName] and [The text we'd like to display as instructions]
    public Dictionary<string, string> taskInstruct = new Dictionary<string, string>()
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
    public void setupMainMenu()
    {
        tasklist.Add("StartApp", true);
        tasklist.Add("ChooseLocation", false);
        //WaitFiveSeconds();



    }
    public void setupBeachScene() 
    {
        tasklist.Add("CountClouds", false);
        tasklist.Add("PickUpTrash", false);
        tasklist.Add("LocateWaterBottles", false);
    }
    public void setupWhackAMole() 
    {
        // Initial Setup - Essentially OnLoad() for WAM
        gameTimer = GameObject.FindGameObjectWithTag("Timer");
        gameScoreText = GameObject.FindGameObjectWithTag("Score");

        // Set gameTime
        gameTimer.GetComponent<Text>().text = gameTime.ToString();
        gameScoreText.GetComponent<Text>().text = gameScore.ToString();

        tasklist.Add("WhackAMole", false);
    }

    // Pause for 5 seconds, for the user to read the instructions
    IEnumerator WaitFiveSeconds() { yield return new WaitForSeconds(5); }

    public void WAMUpdate() 
    {
        if (gameTimer.GetComponent<Text>().text == "0")
        {
            gameTimer.GetComponent<Text>().text = "--";
            gameOverBool = true;
            // Trigger winning condition - Future feature
        }
        else
        {
            if (gameOverBool == false)
            {
                // Running Timer
                gameTime -= Time.deltaTime;
                gameTimer.GetComponent<Text>().text = Mathf.Round(gameTime).ToString();
            }
        }
    }

    // On Update
    public void Update()
    {
        if (scene == "MainMenu")
        {
            // IF the MainMenu scene needs updates, creat and call BeachUpdate();            
        }
        else if (scene == "Beach")
        {
            // IF the Beach scene needs updates, creat and call BeachUpdate();
        }
        else if (scene == "WhackAMole")
        {
            WAMUpdate();
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

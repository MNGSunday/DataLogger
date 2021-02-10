using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManagerScript : MonoBehaviour
{   
    //The name of the file or path of the file that will be used in the project. Can be changed from Unity menu.
    public string Filepath = "log.txt";

    // Start is called before the first frame update
    void Start()
    {   
        //Create a file if it doesn't already exist and read its contents out on the Debug window of Unity.
        CreateFile();
        ReadFile();

        //Generate the message to be used when the Application is started.
        string StringForApplicationLoad = "Application was loaded at: ";
        DateTime TimeOfApplicationLoad = DateTime.Now;

        //Use the WriteFile method to write out the timestamped message in the file.
        WriteFile(StringForApplicationLoad, TimeOfApplicationLoad);
    }

    // Update is called once per frame, and will run continuously until the Application is no longer running.
    void Update()
    {
        //If the user presses the Spacebar at any point while the Application is running
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Generate the message to be used when the Spacebar is pressed.
            string StringForSpacebarPress = "The Spacebar key was pressed at: ";
            DateTime TimeOfSpacebarPress = DateTime.Now;

            //Use the WriteFile method to write out the timestamped message in the file.
            WriteFile(StringForSpacebarPress, TimeOfSpacebarPress);
        }
    }

    //If the user presses the Button in the Unity Game window as the Application is running
    public void OnClick()
    {
        //Generate the message to be used when the Button is pressed in Unity.
        string StringForButtonPress = "The Button in Unity's Game Window was pressed at: ";
        DateTime TimeOfButtonPress = DateTime.Now;

        //Use the WriteFile method to write out the timestamped message into the file.
        WriteFile(StringForButtonPress, TimeOfButtonPress);
    }

    //Occur when the user closes the Application.
    void OnApplicationQuit()
    {
        //Generate the message to be used when the User quits the application.
        string StringForApplicationQuit = "Application was closed at: ";
        DateTime TimeOfApplicationQuit = DateTime.Now;

        //Use the WriteFile method to write out the timestamped message into the file.
        WriteFile(StringForApplicationQuit, TimeOfApplicationQuit);
    }

    //Creates a file if the directory or name of the file does not exist.
    private void CreateFile()
    {
        //If the directory or name of the file does not exist
        if (!File.Exists(Filepath))
        {
            //Create a new directory or file using the directory or filename stored in "Filepath."
            File.Create(Filepath).Close();
        }
    }

    //Displays the contents of the file onto the Unity Debugger Window
    private void ReadFile()
    {
        //"Open" a StreamReader using the desired directory or file, and "Close" when the method finishes.
        using (StreamReader reader = new StreamReader(Filepath))
        {
            //Continue going through the lines of the file until the end is reached
            while(!reader.EndOfStream)
            {
                //Print out the contents of the file's current line onto the Unity Debugger Window.
                Debug.Log(reader.ReadLine());
            }
        }
    }

    //Appends a message to the next possible line in the directory or file, utilizing a string and object DateTime to represent the message and timestamp to be written in the file 
    private void WriteFile(string TextToWrite, DateTime TimeOfEvent)
    {
        //"Open" a StreamWriter using the desired directory or file, and "Close" once the method finishes. "true" allows the file to append lines to the bottom of a file if it already exists.
        using (StreamWriter writer = new StreamWriter(Filepath, true))
        {
            //On the next available line in the file, write out the Text describing the event (TextToWrite) followed by its timestamp (TimeOfEvent).
            writer.WriteLine(TextToWrite + TimeOfEvent);
        }
    }
}

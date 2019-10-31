using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// this gives us saving/loading functionality
using System;
// essentially unreadable by players because its in binary
// unlike the playerprefs alternative
using System.Runtime.Serialization.Formatters.Binary;
// input/output for saving/loading
using System.IO;

public class GameManager : MonoBehaviour
{

    public float health;
    public float experience;

    public static GameManager control;

    public Text healthText;
    public Text XPtext;

    string userName;

    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }

    public void changeHealth(int h)
    {
        health += h;
        UpdateText();
    }

    public void changeXP(int x)
    {
        experience += x;
        UpdateText();
    }

    void UpdateText() {
        healthText.text = "Health: " + health.ToString();
        XPtext.text = "XP: " + experience.ToString();
    }

    // could call this in OnDisable() to auto save
    public void Save()
    { // making public so other scripts can call Save();
      // create a file and push data to it
        BinaryFormatter bf = new BinaryFormatter();
        // persistentDataPath = secret filepath in unity, a good place to save stuff you don't want people to save
        // create a file in this file path that we will save to
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat"); 

        // instantiate the class with current data so you can save it
        PlayerData data = new PlayerData();
        data.health = health;
        data.experience = experience;

        bf.Serialize(file, data);  // write player data to file
        file.Close(); // close the file when we finish
    }

    // could call this in OnEnable() to auto load
    public void Load()
    {
        // check if file exists first
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            // opens the file
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            // reads it into an object that we've defined as a player data object
            PlayerData data = (PlayerData)bf.Deserialize(file); 
            file.Close();
            health = data.health;
            experience = data.experience;
        }
        UpdateText();
    }

}

// a clean class object/data container to use to save to a file. 
// cant save GameManager class because its a MonoBehavior. This is a clean one that you can serialize.
[Serializable] // tells unity it is serializable
class PlayerData
{
    public float health;
    public float experience;
}
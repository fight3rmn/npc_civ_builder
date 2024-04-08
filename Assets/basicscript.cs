using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicscript : MonoBehaviour
{
    int i;
    void Start()
    {
        PlayerPrefs.SetInt("numBuildings", 0);
        PlayerPrefs.SetInt("numTaverns", 0);
        PlayerPrefs.SetInt("numLibraries", 0);
        PlayerPrefs.SetInt("numHouses", 0);
        PlayerPrefs.SetInt("newPeople", 0);
        PlayerPrefs.SetInt("tavernBuilt", 0);
        PlayerPrefs.SetInt("libraryBuilt", 0);
        PlayerPrefs.SetInt("stadiumBuilt", 0);
        PlayerPrefs.SetInt("housesNeeded", 0);
        PlayerPrefs.SetInt("buildComplete" + 0, 0);
        PlayerPrefs.SetInt("firstTori", 0);
        PlayerPrefs.SetInt("numStadiums", 0);
        PlayerPrefs.SetInt("numToris", 0);
        for (i = 0; i < 10; i++)
        {
            PlayerPrefs.SetInt("buildingx" + i, 99999);
            PlayerPrefs.SetInt("buildingy" + i, 99999);
        }
        PlayerPrefs.SetInt("firstAdison", 0);
        PlayerPrefs.SetInt("housesFinished", 0);
        PlayerPrefs.SetString("buildingtype" + -500, "nothing, fuck you");
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("newPeople") >= 3)
        {
            PlayerPrefs.SetInt("housesNeeded", PlayerPrefs.GetInt("housesNeeded") + 1);
            PlayerPrefs.SetInt("newPeople", 0);
        }
    }
}

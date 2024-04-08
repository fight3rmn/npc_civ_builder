using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beinBuilt : MonoBehaviour
{
    int buildingNumber;
    public int timeToBuild;
    public GameObject house;
    public GameObject thisAdison;
    public GameObject tavern;
    public GameObject stadium;
    public GameObject library;
    void Start()
    {
        timeToBuild = 0;
        buildingNumber = PlayerPrefs.GetInt("numBuildings");
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("firstAdison") == 0)
        {
            buildingNumber = -500;
            PlayerPrefs.SetInt("firstAdison", 6);
        }
        timeToBuild += PlayerPrefs.GetInt("torisHere" + buildingNumber);
        if(PlayerPrefs.GetString("buildingtype" + buildingNumber).Contains("house") && timeToBuild >= 3800)
        {
            Instantiate(house, transform.position, Quaternion.identity);
            PlayerPrefs.SetInt("housesFinished", PlayerPrefs.GetInt("housesFinished") + 1);
            PlayerPrefs.SetInt("buildComplete" + buildingNumber, 1);
            Destroy(thisAdison);
        }
        if (PlayerPrefs.GetString("buildingtype" + buildingNumber).Contains("tavern") && timeToBuild >= 4300)
        {
            Instantiate(tavern, transform.position, Quaternion.identity);
            PlayerPrefs.SetInt("buildComplete" + buildingNumber, 1);
            PlayerPrefs.SetInt("tavernBuilt", 1);
            Destroy(thisAdison);
        }
        if (PlayerPrefs.GetString("buildingtype" + buildingNumber).Contains("stadium") && timeToBuild >= 7400)
        {
            Instantiate(stadium, transform.position, Quaternion.identity);
            PlayerPrefs.SetInt("buildComplete" + buildingNumber, 1);
            PlayerPrefs.SetInt("stadiumBuilt", 1);
            Destroy(thisAdison);
        }
        if (PlayerPrefs.GetString("buildingtype" + buildingNumber).Contains("library") && timeToBuild >= 6900)
        {
            Instantiate(library, transform.position, Quaternion.identity);
            PlayerPrefs.SetInt("buildComplete" + buildingNumber, 1);
            PlayerPrefs.SetInt("libraryBuilt", 1);
            Destroy(thisAdison);
        }
    }
}

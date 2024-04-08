using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterstats : MonoBehaviour
{
    public GameObject Tavern;
    public GameObject Library;
    public GameObject Home;
    public GameObject Stadium;
    public GameObject thisTori;
    public GameObject inProgress;
    public int fulfillment;
    public int happiness;
    int recreationDist;
    public int sociability;
    int fulfillTime;
    bool hasRelation;
    int negFulfillTime;
    List<int[]> relations = new List<int[]>();
    int recTimer;
    bool sleeping;
    Vector2 closestHouse;
    int statTimer;
    int interactionTimer;
    int recBuilding;
    int sleeptime;
    int buildingworked;
    bool working;
    public int age;
    bool recreation;
    public int socNeed;
    string recBuildingType;
    public int physNeed;
    public int mentNeed;
    public int intelligence;
    int houseDistance;
    int timetobuild;
    int agetime;
    int timeToWork;
    int relationMove;
    int exhaustionTimer;
    int citizenNum;
    int directiontime;
    bool atWork;
    public int athleticism;
    int i = 0;
    public int hp;
    public int exhaustion;
    public int direction;
    void Start()
    {
        PlayerPrefs.SetInt("numToris", PlayerPrefs.GetInt("numToris") + 1);
        citizenNum = PlayerPrefs.GetInt("numToris");
        fulfillment = Random.Range(1, 11);
        happiness = Random.Range(1, 11);
        sociability = Random.Range(1, 11);
        mentNeed = Random.Range(1, 11);
        socNeed = Random.Range(1, 11);
        interactionTimer = 0;
        physNeed = Random.Range(1, 11);
        timetobuild = 0;
        recBuilding = -4;
        recreationDist = 99999;
        fulfillTime = 0;
        hasRelation = false;
        atWork = false;
        recTimer = 0;
        buildingworked = -4;
        statTimer = 0;
        houseDistance = 99999;
        recBuildingType = "";
        timeToWork = 0;
        working = false;
        age = Random.Range(10, 61);
        negFulfillTime = 0;
        intelligence = Random.Range(1, 11);
        exhaustionTimer = 0;
        exhaustion = Random.Range(1, 5);
        sleeptime = 0;
        recreation = false;
        athleticism = Random.Range(1, 11);
        sleeping = false;
        hp = 10;
        directiontime = 0;
        agetime = 0;
        if(PlayerPrefs.GetInt("firstTori")==0)
        {
            age = -99999;
            PlayerPrefs.SetInt("firstTori", 1);
        }
        PlayerPrefs.SetInt("newPeople", PlayerPrefs.GetInt("newPeople") + 1);
    }
    






    void Update()
    {
        if(working.Equals(true))
        {
            recreation = false;
            recTimer = 0;
        }




        if (direction==1) {
            transform.position += new Vector3(-20, 0, 0) * Time.deltaTime;
        }
        else if (direction==2)
        {
            transform.position += new Vector3(20, 0, 0) * Time.deltaTime;
        }
        else if (direction==3)
        {
            transform.position += new Vector3(0, 20, 0) * Time.deltaTime;
        }
        else if (direction==4)
        {
            transform.position += new Vector3(0, -20, 0) * Time.deltaTime;
        }
        if((int)transform.position[0] <= 0)
        {
            direction = 2;
        }
        if ((int)transform.position[0] >= 950)
        {
            direction = 1;
        }
        if ((int)transform.position[1] <= 0)
        {
            direction = 3;
        }
        if ((int)transform.position[1] >= 505)
        {
            direction = 4;
        }
        if(directiontime >= 1500 && sleeping.Equals(false) && working.Equals(false) && recreation.Equals(false))
        {
            direction = Random.Range(0, 5);
            directiontime = 0;
        }
        PlayerPrefs.SetInt("ToriX" + citizenNum, (int)transform.position[0]);
        PlayerPrefs.SetInt("ToriY" + citizenNum, (int)transform.position[1]);
















        if (working.Equals(true) && exhaustion < 4 && Mathf.Abs((int)transform.position[0] - PlayerPrefs.GetInt("buildingx" + buildingworked)) > 10)
        {
            if(PlayerPrefs.GetInt("buildingx" + buildingworked) > (int)transform.position[0])
            {
                direction = 2;
            }
            else
            {
                direction = 1;
            }
        }
        else if (working.Equals(true) && exhaustion < 4 && Mathf.Abs((int)transform.position[1] - PlayerPrefs.GetInt("buildingy" + buildingworked)) > 10)
        {
            if (PlayerPrefs.GetInt("buildingy" + buildingworked) > (int)transform.position[1])
            {
                direction = 3;
            }
            else
            {
                direction = 4;
            }
        }
        if(working.Equals(true) && Mathf.Abs((int)transform.position[0] - PlayerPrefs.GetInt("buildingx" + buildingworked)) <= 10 && Mathf.Abs((int)transform.position[1] - PlayerPrefs.GetInt("buildingy" + buildingworked)) <= 10)
        {
            direction = 0;
            if(atWork.Equals(false))
            {
                PlayerPrefs.SetInt("torisHere" + buildingworked, PlayerPrefs.GetInt("torisHere" + buildingworked) + 1);
                atWork = true;
            }
            exhaustionTimer++;
            fulfillTime++;
            if(fulfillTime >= 600)
            {
                fulfillment++;
                fulfillTime = 0;
            }
            if(exhaustionTimer >= 500)
            {
                exhaustion++;
                exhaustionTimer = 0;
            }
        }
        if(working.Equals(true) && PlayerPrefs.GetInt("buildComplete" + buildingworked) > 0)
        {
            working = false;
            atWork = false;
            buildingworked = -4;
        }












            if (exhaustion < 5 && timetobuild >= 2000 && PlayerPrefs.GetInt("numHouses") <= PlayerPrefs.GetInt("housesNeeded") && working.Equals(false))
        {
            for (i = 0; i <= PlayerPrefs.GetInt("numBuildings"); i++)
            {
                if (Mathf.Abs(PlayerPrefs.GetInt("buildingx" + i) - (int)transform.position[0]) < 60 && Mathf.Abs(PlayerPrefs.GetInt("buildingy" + i) - (int)transform.position[1]) < 75)
                {
                    timetobuild = 0;
                }
            }
            if (timetobuild >= 2000)
            {
                PlayerPrefs.SetInt("numBuildings", PlayerPrefs.GetInt("numBuildings") + 1);
                PlayerPrefs.SetInt("buildingx" + PlayerPrefs.GetInt("numBuildings"), (int)transform.position[0]);
                PlayerPrefs.SetInt("buildingy" + PlayerPrefs.GetInt("numBuildings"), (int)transform.position[1]);
                PlayerPrefs.SetInt("housex" + PlayerPrefs.GetInt("numHouses"), (int)transform.position[0]);
                PlayerPrefs.SetInt("housey" + PlayerPrefs.GetInt("numHouses"), (int)transform.position[1]);
                PlayerPrefs.SetInt("numHouses", PlayerPrefs.GetInt("numHouses") + 1);
                PlayerPrefs.SetString("buildingtype" + PlayerPrefs.GetInt("numBuildings"), "house");
                PlayerPrefs.SetInt("torisHere" + PlayerPrefs.GetInt("numBuildings"), 0);
                PlayerPrefs.SetInt("buildComplete" + PlayerPrefs.GetInt("numBuildings"), 0);
                working = true;
                buildingworked = PlayerPrefs.GetInt("numBuildings");
                Instantiate(inProgress, transform.position, Quaternion.identity);
                timetobuild = 0;
            }
        }










        if (sociability >= 8 && exhaustion < 4 && timetobuild >= 2000 && PlayerPrefs.GetInt("numTaverns") <= 1 && working.Equals(false))
        {
            for(i=0;i<=PlayerPrefs.GetInt("numBuildings");i++)
            {
                if (Mathf.Abs(PlayerPrefs.GetInt("buildingx" + i)-(int)transform.position[0])<100 && Mathf.Abs(PlayerPrefs.GetInt("buildingy" + i) - (int)transform.position[1]) < 75)
                {
                    timetobuild = 0;
                }
            }
            if(timetobuild >= 2000)
            {
                PlayerPrefs.SetInt("numBuildings", PlayerPrefs.GetInt("numBuildings") + 1);
                PlayerPrefs.SetInt("buildingx" + PlayerPrefs.GetInt("numBuildings"), (int)transform.position[0]);
                PlayerPrefs.SetInt("buildingy" + PlayerPrefs.GetInt("numBuildings"), (int)transform.position[1]);
                PlayerPrefs.SetInt("numTaverns", PlayerPrefs.GetInt("numTaverns") + 1);
                PlayerPrefs.SetString("buildingtype" + PlayerPrefs.GetInt("numBuildings"), "tavern");
                PlayerPrefs.SetInt("torisHere" + PlayerPrefs.GetInt("numBuildings"), 0);
                PlayerPrefs.SetInt("buildComplete" + PlayerPrefs.GetInt("numBuildings"), 0);
                working = true;
                buildingworked = PlayerPrefs.GetInt("numBuildings");
                Instantiate(inProgress, transform.position, Quaternion.identity);
                timetobuild = 0;
            }
        }









        if (athleticism >= 8 && exhaustion < 4 && timetobuild >= 2000 && PlayerPrefs.GetInt("numStadiums") <= 1 && working.Equals(false))
        {
            for (i = 0; i <= PlayerPrefs.GetInt("numBuildings"); i++)
            {
                if (Mathf.Abs(PlayerPrefs.GetInt("buildingx" + i) - (int)transform.position[0]) < 70 && Mathf.Abs(PlayerPrefs.GetInt("buildingy" + i) - (int)transform.position[1]) < 75)
                {
                    timetobuild = 0;
                }
            }
            if (timetobuild >= 2000)
            {
                PlayerPrefs.SetInt("numBuildings", PlayerPrefs.GetInt("numBuildings") + 1);
                PlayerPrefs.SetInt("buildingx" + PlayerPrefs.GetInt("numBuildings"), (int)transform.position[0]);
                PlayerPrefs.SetInt("buildingy" + PlayerPrefs.GetInt("numBuildings"), (int)transform.position[1]);
                PlayerPrefs.SetInt("numStadiums", PlayerPrefs.GetInt("numStadiums") + 1);
                PlayerPrefs.SetString("buildingtype" + PlayerPrefs.GetInt("numBuildings"), "stadium");
                PlayerPrefs.SetInt("torisHere" + PlayerPrefs.GetInt("numBuildings"), 0);
                PlayerPrefs.SetInt("buildComplete" + PlayerPrefs.GetInt("numBuildings"), 0);
                working = true;
                buildingworked = PlayerPrefs.GetInt("numBuildings");
                Instantiate(inProgress, transform.position, Quaternion.identity);
                timetobuild = 0;
            }
        }









        if (intelligence >= 8 && exhaustion < 4 && timetobuild >= 2000 && PlayerPrefs.GetInt("numLibraries") <= 1 && working.Equals(false))
        {
            for (i = 0; i <= PlayerPrefs.GetInt("numBuildings"); i++)
            {
                if (Mathf.Abs(PlayerPrefs.GetInt("buildingx" + i) - (int)transform.position[0]) < 60 && Mathf.Abs(PlayerPrefs.GetInt("buildingy" + i) - (int)transform.position[1]) < 75)
                {
                    timetobuild = 0;
                }
            }
            if (timetobuild >= 2000)
            {
                PlayerPrefs.SetInt("numBuildings", PlayerPrefs.GetInt("numBuildings") + 1);
                PlayerPrefs.SetInt("buildingx" + PlayerPrefs.GetInt("numBuildings"), (int)transform.position[0]);
                PlayerPrefs.SetInt("buildingy" + PlayerPrefs.GetInt("numBuildings"), (int)transform.position[1]);
                PlayerPrefs.SetInt("numLibraries", PlayerPrefs.GetInt("numLibraries") + 1);
                PlayerPrefs.SetString("buildingtype" + PlayerPrefs.GetInt("numBuildings"), "library");
                PlayerPrefs.SetInt("torisHere" + PlayerPrefs.GetInt("numBuildings"), 0);
                PlayerPrefs.SetInt("buildComplete" + PlayerPrefs.GetInt("numBuildings"), 0);
                working = true;
                buildingworked = PlayerPrefs.GetInt("numBuildings");
                Instantiate(inProgress, transform.position, Quaternion.identity);
                timetobuild = 0;
            }
        }







        if(agetime>4500)
        {
            age++;
            agetime = 0;
            if(age>60)
            {
                hp = hp - 1;
            }
        }




        if(hp <= 0)
        {
            PlayerPrefs.SetInt("newPeople", PlayerPrefs.GetInt("newPeople") - 1);
            Destroy(thisTori);
        }





        if(negFulfillTime >= 10000)
        {
            fulfillment--;
            negFulfillTime = 0;
        }
















        for(int i = 1; i<=PlayerPrefs.GetInt("numToris");i++)
        {
            if(PlayerPrefs.GetInt("ToriX"+i) >= (int)transform.position[0] - 12 && PlayerPrefs.GetInt("ToriX" + i) <= (int)transform.position[0] + 12) {
                if (PlayerPrefs.GetInt("ToriY" + i) >= (int)transform.position[1] - 12 && PlayerPrefs.GetInt("ToriY" + i) <= (int)transform.position[1] + 12 && interactionTimer > 500)
                {
                    relationMove = Random.Range(-2, 2);
                    for (int ii = 0; ii < relations.Count; ii++)
                    {
                        if (relations[ii][0] == i)
                        {
                            hasRelation = true;
                            relations[ii][1] += relationMove;
                        }
                    }
                    if (hasRelation == false)
                    {
                        relations.Add(new int[2]);
                        relations[relations.Count - 1][0] = i;
                        relations[relations.Count - 1][1] = relationMove;
                    }
                    hasRelation = false;
                    interactionTimer = 0;
                }
            }
        }
















        if(exhaustion > 3 && PlayerPrefs.GetInt("housesFinished") >= 1)
        {
            for(i=0;i<PlayerPrefs.GetInt("housesFinished");i++)
            {
                if((Mathf.Abs((int)transform.position[0] - PlayerPrefs.GetInt("housex" + i)) + Mathf.Abs((int)transform.position[1] - PlayerPrefs.GetInt("housey" + i))) < houseDistance)
                {
                    closestHouse = new Vector2(PlayerPrefs.GetInt("housex" + i), PlayerPrefs.GetInt("housey" + i));
                    houseDistance = (Mathf.Abs((int)transform.position[0] - PlayerPrefs.GetInt("housex" + i)) + Mathf.Abs((int)transform.position[1] - PlayerPrefs.GetInt("housey" + i)));
                }
            }
            if (working.Equals(true))
            {
                if (atWork.Equals(true))
                {
                    PlayerPrefs.SetInt("torisHere" + buildingworked, PlayerPrefs.GetInt("torisHere" + buildingworked) - 1);
                    atWork = false;
                }
            }
            if ((int)transform.position[0] > closestHouse[0] + 6)
            {
                direction = 1;
            }
            else if ((int)transform.position[0] < closestHouse[0] - 6)
            {
                direction = 2;
            }
            else if ((int)transform.position[1] < closestHouse[1] - 6)
            {
                direction = 3;
            }
            else if ((int)transform.position[1] > closestHouse[1] + 6)
            {
                direction = 4;
            }
            else
            {
                direction = 0;
                sleeptime++;
                sleeping = true;
            }
            if(sleeptime >= 353)
            {
                exhaustion = exhaustion - Random.Range(1, 4);
                sleeptime = 0;
            }
            if(exhaustion<=5)
            {
                sleeping = false;
            }
        }










        if(working.Equals(false) && timeToWork >= 2225)
        {
            if(Random.Range(1,12) > fulfillment)
            {
                for(i=1;i<=PlayerPrefs.GetInt("numBuildings");i++)
                {
                    if(PlayerPrefs.GetInt("buildComplete" + i) == 0)
                    {
                        working = true;
                        if(socNeed > mentNeed && socNeed > physNeed && PlayerPrefs.GetString("buildingtype" + i).Contains("tavern"))
                        {
                            buildingworked = i;
                        }
                        else if (physNeed > mentNeed && physNeed > socNeed && PlayerPrefs.GetString("buildingtype" + i).Contains("stadium"))
                        {
                            buildingworked = i;
                        }
                        else if (mentNeed > socNeed && mentNeed > physNeed && PlayerPrefs.GetString("buildingtype" + i).Contains("library"))
                        {
                            buildingworked = i;
                        }
                        else if (buildingworked < 0)
                        {
                            buildingworked = i;
                        }
                    }
                }
            }
            timeToWork = 0;
        } 














        if(working==false && sleeping==false && Random.Range(1, 12) > happiness && exhaustion < 4)
        {
            if(Random.Range(0, 11) < socNeed && PlayerPrefs.GetInt("tavernBuilt") == 1)
            {
                for(i=0;i<PlayerPrefs.GetInt("numBuildings");i++)
                {
                    if(PlayerPrefs.GetString("buildingtype" + i).Contains("tavern") && (Mathf.Abs((int)transform.position[0] - PlayerPrefs.GetInt("buildingx" + i)) + Mathf.Abs((int)transform.position[1] - PlayerPrefs.GetInt("buildingy" + i))) < recreationDist)
                    {
                        recreationDist = Mathf.Abs((int)transform.position[0] - PlayerPrefs.GetInt("buildingx" + i)) + Mathf.Abs((int)transform.position[1] - PlayerPrefs.GetInt("buildingy" + i));
                        recBuilding = i;
                        recBuildingType = "tavern";
                    }
                }
            }



            if (Random.Range(0, 11) < physNeed && PlayerPrefs.GetInt("stadiumBuilt") == 1)
            {
                for (i = 0; i < PlayerPrefs.GetInt("numBuildings"); i++)
                {
                    if (PlayerPrefs.GetString("buildingtype" + i).Contains("stadium") && (Mathf.Abs((int)transform.position[0] - PlayerPrefs.GetInt("buildingx" + i)) + Mathf.Abs((int)transform.position[1] - PlayerPrefs.GetInt("buildingy" + i))) < recreationDist)
                    {
                        recreationDist = Mathf.Abs((int)transform.position[0] - PlayerPrefs.GetInt("buildingx" + i)) + Mathf.Abs((int)transform.position[1] - PlayerPrefs.GetInt("buildingy" + i));
                        recBuilding = i;
                        recBuildingType = "stadium";
                    }
                }
            }




            if (Random.Range(0, 11) < mentNeed && PlayerPrefs.GetInt("libraryBuilt") == 1)
            {
                for (i = 0; i < PlayerPrefs.GetInt("numBuildings"); i++)
                {
                    if (PlayerPrefs.GetString("buildingtype" + i).Contains("library") && (Mathf.Abs((int)transform.position[0] - PlayerPrefs.GetInt("buildingx" + i)) + Mathf.Abs((int)transform.position[1] - PlayerPrefs.GetInt("buildingy" + i))) < recreationDist)
                    {
                        recreationDist = Mathf.Abs((int)transform.position[0] - PlayerPrefs.GetInt("buildingx" + i)) + Mathf.Abs((int)transform.position[1] - PlayerPrefs.GetInt("buildingy" + i));
                        recBuilding = i;
                        recBuildingType = "library";
                    }
                }
            }



            if ((int)transform.position[0] > PlayerPrefs.GetInt("buildingx" + recBuilding) + 11)
            {
                direction = 1;
            }
            else if ((int)transform.position[0] < PlayerPrefs.GetInt("buildingx" + recBuilding) - 11)
            {
                direction = 2;
            }
            else if ((int)transform.position[1] < PlayerPrefs.GetInt("buildingy" + recBuilding) - 11)
            {
                direction = 3;
            }
            else if ((int)transform.position[1] > PlayerPrefs.GetInt("buildingy" + recBuilding) + 11)
            {
                direction = 4;
            }
            else
            {
                direction = 0;
                recreation = true;
            }
        }
        if(recreation.Equals(true) && exhaustion<4)
        {
            recTimer++;
            statTimer++;
            if(statTimer >= 700)
            {
                happiness += 2;
                statTimer = 0;
                if(recBuildingType.Contains("tavern"))
                {
                    sociability++;
                    socNeed--;
                }
                if (recBuildingType.Contains("library"))
                {
                    intelligence++;
                    mentNeed--;
                }
                if (recBuildingType.Contains("stadium"))
                {
                    athleticism++;
                    physNeed--;
                }
            }
            if(recTimer >= 1400)
            {
                recTimer = 0;
                recreation = false;
                exhaustion++;
            }
        }



















        timetobuild++;
        agetime++;
        directiontime++;
        timeToWork++;
        interactionTimer++;
        negFulfillTime++;
    }
}

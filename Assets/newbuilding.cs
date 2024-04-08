using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newbuilding : MonoBehaviour
{
    public Object building1;

    public void build()
    {
        Instantiate(building1, new Vector3(400, 200, 0), Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public Transform[] waypoints;

    public int Length
    {
        get { return waypoints.Length; }
    }
}

﻿using UnityEngine;
using System.Collections;

public class PublicTextField : MonoBehaviour
{
    public string myName;

    // Use this for initialization
    void Start()
    {
        Debug.Log("I am alive and my name is " + myName);
    }
}

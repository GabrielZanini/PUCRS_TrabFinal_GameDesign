using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugController : MonoBehaviour {

    public static DebugController Instance { get; private set; }


    public int bulletsCount = 0;


    private void Start ()
    {
	    if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
	}

    private void Update()
    {
        KeyCode[] keys = (KeyCode[])Enum.GetValues(typeof(KeyCode));
        for (int i=0; i < keys.Length; i++)
        {
            if (Input.GetKey(keys[i]))
            {
                Debug.Log(keys[i].ToString());
            }
        }
    }

}

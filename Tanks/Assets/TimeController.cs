using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour {

    public bool isSlowTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isSlowTime)
            {
                Time.timeScale = 1f;
            }
            else
            {
                Time.timeScale = 0.1f;
            }

            isSlowTime = !isSlowTime;
        }
	}
}

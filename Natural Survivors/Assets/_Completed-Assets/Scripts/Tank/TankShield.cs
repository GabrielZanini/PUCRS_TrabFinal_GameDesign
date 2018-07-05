using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShield : MonoBehaviour {

    public GameObject shield;
    public float shieldDuration = 5f;
    public bool isActivated = false;

    private float _shieldCounter = 0f;

    private void Start()
    {
        shield.SetActive(false);
    }

    private void Update()
    {
        if (isActivated)
        {
            if (_shieldCounter <= 0f)
            {
                HideShield();
            }
            else
            {
                _shieldCounter -= Time.deltaTime;
            }            
        }
    }

    public void ActivateShield(float duration = 0f)
    {
        if (duration <= 0f)
        {
            _shieldCounter += shieldDuration;
        }
        else
        {
            _shieldCounter += duration;
        }

        if (!isActivated)
        {
            ShowShield();
        }
    }

    private void ShowShield()
    {
        isActivated = true;
        shield.SetActive(true);
    }

    private void HideShield()
    {
        isActivated = false;
        shield.SetActive(false);
    }
}

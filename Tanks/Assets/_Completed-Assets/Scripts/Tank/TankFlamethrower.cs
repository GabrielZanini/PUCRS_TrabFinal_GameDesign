using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankFlamethrower : MonoBehaviour
{
    public GameObject flames;
    public float duration = 5f;
    public bool isActivated = false;

    private float _counter = 0f;

    private void Start()
    {
        flames.SetActive(false);
    }

    private void Update()
    {
        if (isActivated)
        {
            if (_counter <= 0f)
            {
                Hide();
            }
            else
            {
                _counter -= Time.deltaTime;
            }
        }
    }

    public void Activate(float duration = 0f)
    {
        if (duration <= 0f)
        {
            _counter += duration;
        }
        else
        {
            _counter += duration;
        }

        if (!isActivated)
        {
            Show();
        }
    }

    private void Show()
    {
        isActivated = true;
        flames.SetActive(true);
    }

    private void Hide()
    {
        isActivated = false;
        flames.SetActive(false);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanoBehaviour : MonoBehaviour {

    public Transform SpawnPoint;
    public float ThrowRate = 10f;
    public GameObject Rock;
    private Vector3 _impulse;
    private float _timer;
	private void Start () {
		
	}
	
	private void Update () {
        _timer -= Time.deltaTime;
        if (_timer< 0)
        {
            ThrowRock();
            _timer = ThrowRate;
        }
	}

    private void GenerateImpulse()
    {
        var x = 10f;
        var y = 10f;
        var z = 10f;


    }

    private void ThrowRock()
    {
        GenerateImpulse();
        var obj = Instantiate(Rock,SpawnPoint.position,Quaternion.identity);
        obj.GetComponent<RockBehaviour>().Impulse = _impulse;
    }
}

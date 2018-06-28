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
        var x = Random.Range(-45,45);
        var y = Random.Range(15, 25);
        var z = Random.Range(-45, 45);

        _impulse = new Vector3(x, y, z);
    }

    private void ThrowRock()
    {
        GenerateImpulse();
        var obj = Instantiate(Rock,SpawnPoint.position,SpawnPoint.rotation);
        obj.GetComponent<RockBehaviour>().Impulse = _impulse;
    }
}

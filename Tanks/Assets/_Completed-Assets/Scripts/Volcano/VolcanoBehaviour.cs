using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanoBehaviour : MonoBehaviour {

    public Transform SpawnPoint;
    public float ThrowRate = 10f;
    public GameObject Rock;
    public AudioClip VulcuanoExplosion;

    private AudioSource _audioSource;
    private Vector3 _impulse;
    private float _timer;



    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
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
        // 6
        int sign;
        sign = Random.Range(-1, 1);

        var x = Random.Range(4,15);
        x = x * sign;
        x = sign == 0 ? x : x * sign;

        var z = Random.Range(4, 15);
        sign = Random.Range(-1, 1);

        z = sign == 0 ? z : z * sign;

        var y = Random.Range(20, 25);
        _impulse = new Vector3(x, y, z);
    }

    private void ThrowRock()
    {
        GenerateImpulse();
        _audioSource.PlayOneShot(VulcuanoExplosion, 1);
        var obj = Instantiate(Rock,SpawnPoint.position,SpawnPoint.rotation) as GameObject;
        obj.GetComponent<RockBehaviour>().Impulse = _impulse;
    }
}

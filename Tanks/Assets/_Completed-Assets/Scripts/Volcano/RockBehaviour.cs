using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehaviour : MonoBehaviour {

    public Vector3 Impulse { get; set; }
    public LayerMask Layer;
    public AudioClip HitExplosion;

    private AudioSource _audioSource;
    private Rigidbody _rigidbody;


    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _rigidbody.AddForce(Impulse, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _audioSource.PlayOneShot(HitExplosion, 1f);
            Destroy(gameObject, .8f);
        }
    }
}

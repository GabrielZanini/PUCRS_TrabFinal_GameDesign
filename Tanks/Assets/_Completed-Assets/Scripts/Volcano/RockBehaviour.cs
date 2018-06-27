using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehaviour : MonoBehaviour {

    public Vector3 Impulse { get; set; }

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody.GetComponent<Rigidbody>().AddForce(Impulse, ForceMode.Impulse);
    }
}

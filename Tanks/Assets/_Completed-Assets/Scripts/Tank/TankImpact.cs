using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankImpact : MonoBehaviour {

    public float impactForce = 10f;              

    private Rigidbody _rigidbody;

    private void Start ()
    {
        _rigidbody = GetComponent<Rigidbody>();
	}
	

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.layer == LayerMask.NameToLayer("Players"))
        {
            Vector3 impactDirection = transform.position - collision.transform.position;
            impactDirection.Normalize();
            
            _rigidbody.AddForce(impactDirection * impactForce, ForceMode.Impulse);
        }
    }


}

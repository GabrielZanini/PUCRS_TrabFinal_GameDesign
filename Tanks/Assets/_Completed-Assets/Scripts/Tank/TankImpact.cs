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
	

    private void OnCollisionStay(Collision collision)
    {
        //Debug.Log(collision.gameObject.name);

        int player = LayerMask.NameToLayer("Players");
        int shield = LayerMask.NameToLayer("Shield");

        if (collision.gameObject.layer == player || collision.gameObject.layer == shield)
        {
            Vector3 impactDirection = transform.position - collision.transform.position;
            impactDirection.Normalize();
            
            _rigidbody.AddForce(impactDirection * impactForce, ForceMode.Impulse);
        }
    }


}

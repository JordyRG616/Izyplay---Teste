using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : MonoBehaviour
{
    private Rigidbody body;
    [SerializeField] private float force;
    [SerializeField] private float torque;
    
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    private void Tap()
    {
        body.AddForce((2.5f * Vector3.up + Vector3.right / 2).normalized * force, ForceMode.Impulse);
        body.AddTorque(-transform.forward * torque, ForceMode.Impulse);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Tap();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Surface"))
        {
            // body.freezeRotation = true;
            body.Sleep();
        } else if(other.TryGetComponent<SliceablePiece>(out var piece))
        {
            piece.Slice();
            body.velocity /= 2;
        }
    }
}

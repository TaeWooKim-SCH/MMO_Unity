using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    // 1) ������ RigidBody �־�� �Ѵ� (IsKinematic: Off)
    // 2) ������ Collider�� �־�� �Ѵ� (IsTrigger: Off)
    // 3) ������� Collider�� �־�� �Ѵ� (IsTrigger: Off)
    private void OnCollisionEnter(Collision collision) {
        Debug.Log("Collision !");
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Trigger !");
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    // 1) 나 혹은 상대한테 RigidBody 있어야 한다 (IsKinematic: Off)
    // 2) 나한테 Collider가 있어야 한다 (IsTrigger: Off)
    // 3) 상대한테 Collider가 있어야 한다 (IsTrigger: Off)
    private void OnCollisionEnter(Collision collision) {
        Debug.Log($"Collision {collision.gameObject.name} !");
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log($"Trigger {other.gameObject.name} !");
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackBehaviour : MonoBehaviour {

    public void Set() {

    }

    void OnCollisionEnter(Collision collision) {
        switch (collision.gameObject.tag) {
            case "Paddle":
                Rigidbody rigidbody = GetComponent<Rigidbody>();
                rigidbody.velocity = rigidbody.velocity;
                break;
            case "Floor":
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                break;
            case "Goal":
                if(collision.gameObject.name == "MyGoal") {
                    LifeManager.instance.PlayerDamage();
                }else if(collision.gameObject.name == "EnemyGoal") {
                    LifeManager.instance.EnemyDamage();
                    Debug.Log("enemy goal");
                }
                break;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackBehaviour : MonoBehaviour {
    public float maxSpeed = 100f;
    public float minSpeed = 1f;

    private Rigidbody rb;
    [SerializeField] private float vel;

    public void Set() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        Vector3 velocity = rb.velocity;

        float speed = velocity.magnitude;

        if (speed > maxSpeed) {
            velocity = velocity.normalized * maxSpeed;
        }
        else if (speed < minSpeed && speed > 0) {
            velocity = velocity.normalized * minSpeed;
        }

        rb.velocity = velocity;
        vel = velocity.magnitude;
    }

    void OnCollisionEnter(Collision collision) {
        switch (collision.gameObject.tag) {
            case "Paddle":
                //Rigidbody rigidbody = GetComponent<Rigidbody>();
                //rigidbody.velocity = rigidbody.velocity * 1.2f;
                if(collision.gameObject.name == "EnemyPaddle") { Debug.Log("Enemy Paddle"); }
                break;
            case "Floor":
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                break;
            case "Goal":
                if(collision.gameObject.name == "MyGoal") {
                    LifeManager.instance.PlayerDamage();
                }else if(collision.gameObject.name == "EnemyGoal") {
                    LifeManager.instance.EnemyDamage();
                }
                break;
        }
    }
}
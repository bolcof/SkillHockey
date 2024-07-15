using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackBehaviour : MonoBehaviour {
    public float maxSpeed = 100f;
    public float minSpeed = 1f;

    private Rigidbody rb;
    [SerializeField] private float vel;

    public bool isMyPack;

    public void Set() {
        rb = GetComponent<Rigidbody>();
        isMyPack = false;
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
                Rigidbody rigidbody = GetComponent<Rigidbody>();
                if (rigidbody.velocity.magnitude != 0.0f) {
                    rigidbody.velocity = rigidbody.velocity * 1.2f;
                }
                switch (collision.gameObject.name) {
                    case "PlayerPaddle":
                        Debug.Log("Touch Paddle");
                        CommandManager.instance.TouchMyPaddle();
                        break;
                    case "EnemyPaddle":
                        CommandManager.instance.enemyTouched = true;
                        break;
                }
                break;
            case "Wall":
                switch (collision.gameObject.name) {
                    case "MyWall_Left":
                    case "MyWall_Right":
                        Debug.Log("Touch Wall");
                        CommandManager.instance.TouchMyWall();
                        break;
                    case "EnemyWall_Left":
                    case "EnemyWall_Right":
                        CommandManager.instance.enemyTouched = true;
                        break;
                    case "SideWall_Left":
                    case "SideWall_Right":
                        break;
                }
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
                CommandManager.instance.PackGoaled();
                break;
        }
    }
}
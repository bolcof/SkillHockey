using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackBehaviour : MonoBehaviour {
    public float maxSpeed;
    public float minSpeed;

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
        } else if (speed < minSpeed && speed > 0) {
            velocity = velocity.normalized * minSpeed;
        }

        rb.velocity = velocity;
        vel = velocity.magnitude;
    }

    void OnCollisionEnter(Collision collision) {
        switch (collision.gameObject.tag) {
            case "PlayerPaddle":
                if (rb.velocity.magnitude != 0.0f) {
                    rb.velocity = rb.velocity * 1.2f;
                }
                CommandManager.instance.TouchMyPaddle();
                isMyPack = true;
                break;
            case "EnemyPaddle":
                if (rb.velocity.magnitude != 0.0f) {
                    rb.velocity = rb.velocity * 1.2f;
                }
                CommandManager.instance.TouchEnemyPaddle();
                isMyPack = false;
                break;
            case "Wall":
                switch (collision.gameObject.name) {
                    case "MyWall_Left":
                    case "MyWall_Right":
                        isMyPack = true;
                        CommandManager.instance.TouchMyWall();
                        break;
                    case "EnemyWall_Left":
                    case "EnemyWall_Right":
                        isMyPack = false;
                        CommandManager.instance.TouchEnemyWall();
                        break;
                    case "SideWall_Left":
                    case "SideWall_Right":
                        CommandManager.instance.TouchSideWall();
                        break;
                }
                break;
            case "Floor":
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                break;
            case "Goal":
                if (collision.gameObject.name == "MyGoal") {
                    LifeManager.instance.PlayerDamage();
                } else if (collision.gameObject.name == "EnemyGoal") {
                    LifeManager.instance.EnemyDamage();
                }
                isMyPack = false;
                CommandManager.instance.PackGoaled();
                break;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour {

    float speed = 5;

    float speedx = 0;
    float speedy = 0;
    float speedz = 0;

    float gravity = 15;

    Vector3 velocity;

    void Start() {

        speedx = speed + Random.Range(-0.5f, 0.5f);
        speedy = speed + Random.Range(-0.5f, 0.5f);
        speedz = speed + Random.Range(-0.5f, 0.5f);

        velocity = new Vector3(transform.right.x * speedx, transform.right.y * speedy, transform.right.z * speedy);
    }

    void Update() {
        velocity += Vector3.down * gravity * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }
}

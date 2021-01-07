using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    Vector3 velocity;

    float speed   = 15f;
    float gravity = 1.5f;

    new BoxCollider collider;

    void Start() {

        collider = GetComponent<BoxCollider>();

    }

    void Update() {

        velocity += Vector3.down * gravity * Time.deltaTime;

        transform.position += velocity * Time.deltaTime;

        Collider[] collidedObj = Physics.OverlapBox(transform.position, collider.size / 2, transform.rotation, LayerMask.GetMask("hittable"));

        if(collidedObj.Length > 0) {

            IShotHit hittedObj = collidedObj[0].GetComponent<IShotHit>();

            if(hittedObj != null) {
                hittedObj.Hit(velocity.normalized);
            }

            Destroy(gameObject);

        }

    }

    public void SetDirection(Vector3 direction) {
        velocity = direction * speed;
    }



}

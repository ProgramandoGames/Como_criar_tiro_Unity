using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IShotHit {

    Animator animator;

    void Start() {
        animator = transform.parent.GetComponent<Animator>();
    }

    public void Hit(Vector3 direction) {
        animator.Play("TargetShot", -1, 0);
    }

}

/*
   public void ShootBullet() {

       Transform obj = Instantiate(bulletPrefab, shotSpawn.position, shotSpawn.rotation);
       Destroy(obj.gameObject, 10);

       RaycastHit hit;
       if (Physics.Raycast(fpsCam.transform.position, fpsCam.GetForwardDirection(), out hit, Mathf.Infinity, LayerMask.GetMask("hittable"))) {
           obj.GetComponent<Bullet>().SetDirection((hit.point - shotSpawn.position).normalized);
       } else {
           obj.GetComponent<Bullet>().SetDirection(fpsCam.GetForwardDirection());
       }

   }
*/
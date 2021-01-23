using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotEffects : MonoBehaviour {

    public Transform muzzleFlashPrefab;
    public Transform sheelPrefab;

    public void Shell(Vector3 position, Quaternion rotation) {
        Transform obj = Instantiate(sheelPrefab, position, rotation);
        Destroy(obj.gameObject, 3f);
    }

    public void MuzzleFlash(Vector3 position, Quaternion rotation) {
        Transform obj = Instantiate(muzzleFlashPrefab, position, rotation);
        obj.localEulerAngles = new Vector3(obj.localEulerAngles.x + Random.Range(-360, 360),
                                           obj.localEulerAngles.y-110,
                                           obj.localEulerAngles.z);

        //obj.localScale = Vector3.one * 1.2f;

        Destroy(obj.gameObject, 0.1f);
    }

}

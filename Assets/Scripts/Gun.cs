using UnityEngine;


public class Gun : MonoBehaviour {

    public Transform bulletPrefab;

    Animator    animator;
    AudioSource audioSource;

    FirstPersonCamera fpsCam;

    ShotEffects shootEffects;

    Transform shotSpawn;
    Transform shellSpawn;

    string gunName = "Pistol";

    private void Awake() {

        animator    = transform.Find(gunName).GetComponent<Animator>();
        audioSource = transform.GetComponent<AudioSource>();

        fpsCam     = transform.parent.GetComponent<FirstPersonCamera>();
        shotSpawn  = transform.Find("shotSpawn");
        shellSpawn = transform.Find("shellSpawn");

        shootEffects = GetComponent<ShotEffects>();

    }

    void Start() {
        
    }

    void Update() {
        

        if(Input.GetKeyDown(KeyCode.Mouse0)) {

            Debug.Break();

            animator.Play("Shoot", -1, 0);

            audioSource.Play();

            shootEffects.MuzzleFlash(shotSpawn.position, shotSpawn.rotation);
            shootEffects.Shell(shellSpawn.position, shellSpawn.rotation);

            // implementação do tiro vem aqui....
            ShootRaycast();
            //ShootBullet();

        }

    }

    void ShootRaycast() {

        RaycastHit hitInfo;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.GetForwardDirection(), out hitInfo, Mathf.Infinity, LayerMask.GetMask("hittable"))) {

            IShotHit hitted = hitInfo.transform.GetComponent<IShotHit>();
            if(hitted != null) {

                hitted.Hit(fpsCam.GetForwardDirection());

            }

        }

    }

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


}

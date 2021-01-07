using UnityEngine;

public class Player : MonoBehaviour {

    #region MOVEMENT_ATTRIBS

    CharacterController controller;

    Vector3 forward;
    Vector3 strafe;
    Vector3 verticalVelocity;

    Vector3 direction;
    Vector3 velocity;

    Vector3 currentVelocity;

    float acceleration = 50f;
    float maxSpeed = 5f;

    float gravity;
    float jumpSpeed;
    float maxJumpHeight = 2f;
    float timeToMaxHeight = 0.5f;

    #endregion

    
    void Start() {

        #region GRAVITY_CALCULTIONS

        controller = GetComponent<CharacterController>();
        gravity    = (-2 * maxJumpHeight) / (timeToMaxHeight * timeToMaxHeight);
        jumpSpeed  = (2 * maxJumpHeight) / timeToMaxHeight;

        #endregion

    }

    void Update() {

        #region MOVEMENT

        float forwardInput = Input.GetAxisRaw("Vertical");
        float strafeInput = Input.GetAxisRaw("Horizontal");
    
        forward = forwardInput * transform.forward;
        strafe  = strafeInput * transform.right;

        direction = (forward + strafe).normalized;

        verticalVelocity += gravity * Time.deltaTime * Vector3.up;

        if(controller.isGrounded) {
            verticalVelocity = Vector3.down;
        }

        if(Input.GetKeyDown(KeyCode.Space) && controller.isGrounded) {
            verticalVelocity = jumpSpeed * Vector3.up;
        }

        if (verticalVelocity.y > 0 && (controller.collisionFlags & CollisionFlags.Above) != 0) {
            verticalVelocity = Vector3.zero;
        }

        velocity = Vector3.SmoothDamp(velocity, direction * maxSpeed, ref currentVelocity, maxSpeed / acceleration);
        
        controller.Move((velocity + verticalVelocity) * Time.deltaTime);

        #endregion


    }

}

/*

// tirar na explicação
public Transform bulletPrefab;

public void ShootRaycast() {

    RaycastHit hit;
    if (Physics.Raycast(fpsCam.transform.position, fpsCam.GetForwardDirection(), out hit, Mathf.Infinity, LayerMask.GetMask("hittable"))) {

        IShotHit obj = hit.transform.GetComponent<IShotHit>();
        if (obj != null) {
            obj.Hit(fpsCam.GetForwardDirection());
        }

    }

}



    */

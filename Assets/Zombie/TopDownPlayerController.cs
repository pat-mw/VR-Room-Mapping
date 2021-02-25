
using System;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class TopDownPlayerController : MonoBehaviour
{
    private Camera cam;

    [SerializeField] private float speed;
    [SerializeField] private Transform gunAnchor;
    [SerializeField] private float cameraOffset;
    [SerializeField] private Gun gun;

    private CubeControl cubeInput;
    private Vector2 movementInput;
    private Vector3 mousePos;

    private float camera_z_offset;

    // Start is called before the first frame update
    private void Awake()
    {
        cam = Camera.main;
        camera_z_offset = cam.transform.position.z;

        // Get the constraint used to position the camera behind the player
        ParentConstraint cameraConstraint = cam.GetComponent<ParentConstraint>();

        // Add the camera target so the camera follows it
        ConstraintSource constraintSource = new ConstraintSource { sourceTransform = transform, weight = 1.0f };
        int constraintIndex = cameraConstraint.AddSource(constraintSource);

        // Set the camera offset so it acts like a third-person camera.
        cameraConstraint.SetTranslationOffset(constraintIndex, new Vector3(0.0f, cameraOffset, 0.0f));
        cameraConstraint.SetRotationOffset(constraintIndex, new Vector3(90f, 0.0f, 0.0f));

        //input set up (new input system)
        cubeInput = new CubeControl();
        cubeInput.CubeController.MoveCube.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        cubeInput.CubeController.MousePosition.performed += ctx => mousePos = ctx.ReadValue<Vector2>();
        cubeInput.CubeController.MouseClick.performed += ShootGun;
    }

    private void ShootGun(InputAction.CallbackContext obj)
    {
        gun.Shoot();
    }

    private void FixedUpdate()
    {
        if (movementInput.magnitude > 0.1f)
        {
            MovePlayer(movementInput.x, movementInput.y);
            
        }
        //Debug.Log(Input.mousePosition);
        RotatePlayer();
    }

    private void MovePlayer(float dx, float dz)
    {
        // Apply to the transform
        Vector3 localPosition = transform.localPosition;
        localPosition.x += dx * speed * Time.deltaTime;
        localPosition.z += dz * speed * Time.deltaTime;
        transform.localPosition = localPosition;
    }

    private void RotatePlayer()
    {
        //Debug.Log(mousePos);
        mousePos.z = - camera_z_offset;
        Vector3 worldSpaceMousePos = cam.ScreenToWorldPoint(mousePos);

        Vector3 offset = worldSpaceMousePos - gunAnchor.position;
        offset.y = 0;

        Quaternion lookRotation;

        if (offset.magnitude != 0)
        {
            lookRotation = Quaternion.LookRotation(offset, Vector3.up);
            gunAnchor.rotation = lookRotation;
        }
    }

    private void OnEnable()
    {
        cubeInput.Enable();
    }

    private void OnDisable()
    {
        cubeInput.Disable();
    }
}

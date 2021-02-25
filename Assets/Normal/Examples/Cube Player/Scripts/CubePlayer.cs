#if NORMCORE

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Normal.Realtime.Examples {
    public class CubePlayer : MonoBehaviour {
        public float speed = 5.0f;

        private RealtimeView      _realtimeView;
        private RealtimeTransform _realtimeTransform;

        private CubeControl cubeInput;
        Vector2 movementInput;


        private void Awake() {

            //networking set up
            _realtimeView      = GetComponent<RealtimeView>();
            _realtimeTransform = GetComponent<RealtimeTransform>();


            //input set up (new input system)
            cubeInput = new CubeControl();
            cubeInput.CubeController.MoveCube.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        }

        private void FixedUpdate() {
            // If this CubePlayer prefab is not owned by this client, bail.
            if (!_realtimeView.isOwnedLocallySelf)
                return;

            // Make sure we own the transform so that RealtimeTransform knows to use this client's transform to synchronize remote clients.
            _realtimeTransform.RequestOwnership();


            //LEGACY INPUT
            //// Grab the x/y input from WASD / a controller
            ////if (Keyboard.current.aKey.IsPressed) => fl
            //float x = Input.GetAxis("Horizontal");
            //float y = Input.GetAxis("Vertical");


            if (movementInput.magnitude > 0.1f)
            {
                MoveCube(movementInput.x, movementInput.y);
            }

            
        }

        private void MoveCube(float delta_x, float delta_y)
        {
            // Apply to the transform
            Vector3 localPosition = transform.localPosition;
            localPosition.x += delta_x * speed * Time.deltaTime;
            localPosition.y += delta_y * speed * Time.deltaTime;
            transform.localPosition = localPosition;
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
}

#endif

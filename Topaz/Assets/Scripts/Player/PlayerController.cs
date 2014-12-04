using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using UnityEngine;
using Assets.Items;

namespace Assets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        public GameObject followingCamera;
        public float translationSpeed = 10.0f;
        public float jumpSpeed = 10.0f;

        CameraController cameraController;
        Animator animator;

        bool update;

        void Start()
        {
            cameraController = followingCamera.GetComponent<CameraController>();
            animator = GetComponent<Animator>();
            update = true;
        }

        public void Disable()
        {
            update = false;
        }

        public void Enable()
        {
            update = true;
        }

        void Update()
        {
            if (update)
            {
                var forwardMovement = Input.GetAxis("Vertical");
                var sprintMovement = Input.GetAxis("Sprint");
                animator.SetFloat("walk", forwardMovement);

                var run = 0.0f;
                var moveSpeed = translationSpeed;
                if (sprintMovement > 0.0f && forwardMovement != 0.0f)
                {
                    run = 0.2f;
                    moveSpeed = (translationSpeed * 3) * sprintMovement;
                }
                animator.SetFloat("run", run);

                if (forwardMovement != 0.0f)
                {
                    transform.localEulerAngles = new Vector3(
                        transform.localEulerAngles.x,
                        cameraController.transform.localEulerAngles.y,
                        transform.localEulerAngles.z);
                }
                transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
                transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime);
            }
        }
    }
}
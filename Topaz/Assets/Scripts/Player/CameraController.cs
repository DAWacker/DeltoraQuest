using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class CameraController : MonoBehaviour
    {
        public Camera cameraToRotate;
        public GameObject objectToFollow;

        public float rotationSpeed = 50.0f;

        float minRotation = -45f;
        float maxRotation = 10f;

        float rotationY = 0f;
        float rotationX = 0f;

        bool update;

        void Start()
        {
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
                transform.position = objectToFollow.transform.position;

                rotationX += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
                rotationY += Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

                rotationY = Mathf.Clamp(rotationY, minRotation, maxRotation);

                transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
            }
        }
    }
}
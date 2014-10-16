using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using UnityEngine;

namespace Character
{
    public class CharacterController : MonoBehaviour
    {
        public float translationSpeed = 10.0f;
        public float rotationSpeed = 50.0f;

        float minRotation = -25f;
        float maxRotation = 25f;

        Camera characterCam;
        float rotationY = 0f;
        float rotationX = 0f;

        void Start()
        {
            characterCam = GetComponentInChildren<Camera>();
        }

        void Update()
        {
            transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * translationSpeed * Time.deltaTime);
            transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * translationSpeed * Time.deltaTime);

            rotationX += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            rotationY += Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

            rotationX = Mathf.Clamp(rotationX, minRotation, maxRotation);
            rotationY = Mathf.Clamp(rotationY, minRotation, maxRotation);

            characterCam.transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
    }
}
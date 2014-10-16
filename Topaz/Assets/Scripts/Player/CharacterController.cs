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

        void Start()
        {
            
        }

        void Update()
        {
            transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * translationSpeed * Time.deltaTime);
            transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);
            //transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        }
    }
}
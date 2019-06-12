using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Player : MonoBehaviour
    {
        public GameObject projectilePrefab; // Prefab to spawn when shooting

        public float movementSpeed = 10f; // Units to travel per second
        public float rotationSpeed = 360f; // Amount of rotation per second
        private Rigidbody2D rigid; // Reference to attached Rigidbody2D

        // Use this for initialization
        void Start()
        {
            //NOTE: It gets this from the GameObject this script is attached to
            rigid = GetComponent<Rigidbody2D>();
        }

        // Control is acustom made function to handle movemnt
        void Control()
        {
            // If player hits Space
            if(Input.GetKeyDown(KeyCode.Space))
            {
                // Shoot a projectile
                Shoot();
            }
            // If the W key is pressed
            if (Input.GetKey(KeyCode.W))
            {
                // Add a force up
                rigid.AddForce(transform.up * movementSpeed);
            }

            // If the S key is pressed
            if (Input.GetKey(KeyCode.S))
            {
                // Add a force up
                rigid.AddForce(-transform.up * movementSpeed);
            }

            // If the D key is pressed
            if (Input.GetKey(KeyCode.D))
            {
                // Add a force up
                rigid.rotation -= rotationSpeed * Time.deltaTime;
            }

            // If the A key is pressed
            if (Input.GetKey(KeyCode.A))
            {
                // Rotate counter-clockwise per second
                rigid.rotation += rotationSpeed * Time.deltaTime;
            }
        }

        // Update is called once per frame
        void Update()
        {
            Control();
        }

        // Shoots a projectile in a set direction
        void Shoot()
        {
            // Spawn projectile at position and rotation of Player
            GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);

            // Get Rigidbody2D from projectile
            Projectile bullet = projectile.GetComponent<Projectile>();
            bullet.Fire(transform.up);
        }
    }
}
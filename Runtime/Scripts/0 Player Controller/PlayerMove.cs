using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Finlay._3dToolsForLevelDesign.Player
{
    public class PlayerMove : MonoBehaviour
    {
        public float PlayerMoveSpeed = 20f;         //def 20
        public float JumpStrength = 1300f;          //def 1300
        private float SceneGravity;
        public float GravityMultipler = 5f;         //def 5

        //Turn this off to disable double / wall jumps
        public bool CanDoubleJump = true;
        public bool CanWallJump = true;

        public float DoubleJumpMultiplyer = 1.2f;   //def 1.2
        public float WallJumpMultiplyer = 1.2f;   //def 1.2

        //required to get the actual location of the collider relative to the GO
        private float distToGround;

        //various conditions to see which jump is possible
        private bool CanJump = false;
        private bool CanJumpAgain = false;
        private bool CanWallJumpNow = false;

        private Rigidbody rb;
        private Collider col;
        private Camera m_MainCamera;

        //The direction the left stick is being moved in
        Vector2 direction;
        //New Input System
        PlayerControls controls;


        Vector3 wallJumpDir, playerFaceVelocity;
        ContactPoint LastContactPoint;
        // Start is called before the first frame update
        void Awake()
        {
            m_MainCamera = Camera.main;
            rb = GetComponent<Rigidbody>();
            col = GetComponent<Collider>();

            SceneGravity = Physics.gravity.y;

            //gets the distance between the collider and Gameobject and adds the y size
            distToGround = gameObject.transform.position.y - col.bounds.center.y + col.bounds.extents.y;

        }


        private void Update()
        {
            //shows where the player has been
            Debug.DrawRay(transform.position, rb.velocity * 0.1f, Color.yellow, 1f);
        }

        // Update is called once per frame
        void FixedUpdate()
        { Move(); }


        public void UpdateDirection(Vector2 NewDirection)
        { direction = NewDirection; }

        void Move()
        {
            //adds force relative to the players input
            rb.AddForce((m_MainCamera.transform.forward) * PlayerMoveSpeed * direction.y);
            rb.AddForce((m_MainCamera.transform.right) * PlayerMoveSpeed * direction.x);
            //adds Gravity effect on player
            rb.AddForce(transform.up * GravityMultipler * SceneGravity);


            //turns the player to head in the direction of travel
            playerFaceVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            if (playerFaceVelocity.sqrMagnitude > 1f)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerFaceVelocity), 0.15F);
                transform.Translate(playerFaceVelocity * 1f * Time.deltaTime, Space.World);
            }
        }

        public void Jump()
        {
            //checks to see if player is on the ground
            if (CanJump == true)
            {
                //   Debug.Log("Jump");
                rb.AddForce(transform.up * JumpStrength);
                CanJump = false;
            }
            else if (CanWallJumpNow == true && CanWallJump == true)
            {
                //Debug.Log("Wall Jump");
                rb.AddForce((wallJumpDir + transform.up) * JumpStrength * WallJumpMultiplyer);
                CanWallJumpNow = false;
                //allows a double jump after wall jump
                CanJumpAgain = true;
            }

            //checks to see if havent recently double jumped and character is in air
            else if (CanDoubleJump == true && CanJumpAgain == true)
            {
                //Debug.Log("Double Jump");
                rb.AddForce(transform.up * JumpStrength * DoubleJumpMultiplyer);
                CanJumpAgain = false;
            }
        }

        //fires a raycast downwards to check if there is a collision with a collider
        bool IsGrounded()
        {
            //the 0.05f is a buffer just incase you are slightly off
            Debug.DrawRay(transform.position, -transform.up * (distToGround + 0.05f), Color.green);
            return Physics.Raycast(transform.position, -transform.up, distToGround + 0.05f);
        }

        private void OnCollisionStay(Collision collision)
        {
            LastContactPoint = collision.contacts[0];

            //if normal < 0.1f, the wall is mostly vertical
            if (LastContactPoint.normal.y > 0.9f)
            {
                Debug.DrawRay(LastContactPoint.point, LastContactPoint.normal * 1f, Color.yellow, 1f);
                CanJump = true;
                CanJumpAgain = false;
                CanWallJumpNow = false;
            }
            else if (IsGrounded() == false && LastContactPoint.normal.y < 0.1f)
            {
                Debug.DrawRay(LastContactPoint.point, LastContactPoint.normal * 1f, Color.red, 1f);
                CanWallJumpNow = true;

                wallJumpDir = LastContactPoint.normal;
            }

        }
        private void OnCollisionExit(Collision collision)
        {
            //allows double jumping after a vertical wall
            if (LastContactPoint.normal.y > 0.9f)
            {
                CanJumpAgain = true;
            }

            //must be in contact with something to jump normally or wall jump
            CanJump = false;
            CanWallJumpNow = false;
        }
    }
}
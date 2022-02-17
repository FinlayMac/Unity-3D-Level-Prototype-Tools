using UnityEngine;

namespace Finlay._3dToolsForLevelDesign.Player
{
    public class CameraController : MonoBehaviour
    {
        [Tooltip("The Target that the camera will follow. This is likely Camera Target inside the player prefab")]
        public Transform GameObjectToFollow;

        [Range(30, 70)]
        public float UpperBoundAngle = 50f;
       
        [Range(330, 360)]
        public float LowerBoundAngle = 345f;
        private float HalfWayBetweenBounds = 200f;

        //the starting distance between player and camera
        private Vector3 _offsetPosition;
        void Start()
        {
            _offsetPosition = transform.position - GameObjectToFollow.position;
            HalfWayBetweenBounds = (LowerBoundAngle + UpperBoundAngle) / 2;
        }

        //The direction from the player input the camera should  move in
        private Vector2 cameraMoveDirection;
        void OnEnable() { PlayerInputs.UpdateCameraVector2 += UpdateCameraInput; }
        void OnDisable() { PlayerInputs.UpdateCameraVector2 -= UpdateCameraInput; }

        private void UpdateCameraInput(Vector2 inputDirection) { cameraMoveDirection = inputDirection; }


        private Quaternion CamTurnAngle, CamRotateAngle;
        private Vector3 newPosition;

        void LateUpdate()
        {
            //will rotate player around the up axis dependant on input
            CamTurnAngle = Quaternion.AngleAxis(cameraMoveDirection.x, Vector3.up);
            //calculates the horizontal offset position
            _offsetPosition = CamTurnAngle * _offsetPosition;


            float eulerX = transform.rotation.eulerAngles.x;

            //TODO Not the best method, if you think of a better solution, get in touch.
            //basically ignores the input if the camera is out of bounds
            //checks if camera is out of bounds (eulers between 0 and 360. -15 = 345)
            if (eulerX > LowerBoundAngle || eulerX < UpperBoundAngle)
            { RotateVertical(cameraMoveDirection.y); }

            //if the camera is out of bounds, allow travel only in direction towards bounds
            else if (eulerX >= UpperBoundAngle && eulerX < HalfWayBetweenBounds && cameraMoveDirection.y >= 0)
            { RotateVertical(cameraMoveDirection.y); }

            else if (eulerX >= HalfWayBetweenBounds && eulerX < LowerBoundAngle && cameraMoveDirection.y <= 0)
            { RotateVertical(cameraMoveDirection.y); }

            //gets the new offset position bsaed off the turn
            newPosition = GameObjectToFollow.position + _offsetPosition;

            transform.position = Vector3.Slerp(transform.position, newPosition, 1f);

            //points the camera at the target
            transform.LookAt(GameObjectToFollow);
        }

        private void RotateVertical(float yDirection)
        {
            //will rotate player around the left axis dependant on input
            CamRotateAngle = Quaternion.AngleAxis(yDirection, -transform.right);
            //calculates the vertical offset position
            _offsetPosition = CamRotateAngle * _offsetPosition;
        }

    }
}

using UnityEngine;

namespace Finlay._3dToolsForLevelDesign.Player
{
    public class CameraController : MonoBehaviour
    {
        [Tooltip("The Target that the camera will follow. This is likely Camera Target inside the player prefab")]
        public Transform GameObjectToFollow;


        //the starting distance between player and camera
        private Vector3 _offsetPosition;
        void Start() { _offsetPosition = transform.position - GameObjectToFollow.position; }



        //The direction from the player input the camera should  move in
        private Vector2 cameraMoveDirection;
        void OnEnable() { PlayerInputs.UpdateCameraVector2 += UpdateCameraInput; }
        void OnDisable() { PlayerInputs.UpdateCameraVector2 -= UpdateCameraInput; }

        private void UpdateCameraInput(Vector2 inputDirection) { cameraMoveDirection = inputDirection; }


        private Quaternion CamTurnAngle, CamRotateAngle;
        private Vector3 newPosition;


        //TODO likely will be updated with cinemachine

        void LateUpdate()
        {
            //will rotate player around the up axis dependant on input
            CamTurnAngle = Quaternion.AngleAxis(cameraMoveDirection.x, Vector3.up);
            //calculates the horizontal offset position
            _offsetPosition = CamTurnAngle * _offsetPosition;

            //will rotate player around the left axis dependant on input
            CamRotateAngle = Quaternion.AngleAxis(cameraMoveDirection.y, -transform.right);
            //calculates the vertical offset position
            _offsetPosition = CamRotateAngle * _offsetPosition;

            //gets the new offset position bsaed off the turn
            newPosition = GameObjectToFollow.position + _offsetPosition;
            transform.position = Vector3.Slerp(transform.position, newPosition, 1f);

            //points the camera at the target
            transform.LookAt(GameObjectToFollow);

        }
    }
}
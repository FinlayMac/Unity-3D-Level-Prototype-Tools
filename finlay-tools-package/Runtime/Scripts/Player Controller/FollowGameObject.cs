using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGameObject : MonoBehaviour
{
    public Transform GameObjectToFollow;
    public bool LookAtTarget = true;
    private Vector3 _offsetPosition;

    [Range(0.01f, 1f)]
    public float SmoothFactor = 0.3f;

    public bool RotateAroundPlayer = true;
    public float RotationSpeed = 5.0f;


    //New Input System
    private PlayerControls controls;
    //The direction the left stick is being moved in
    Vector2 pointing;
    private void Awake()
    {
        //Gets the input control system
        controls = new PlayerControls();

        //When the left stick is moved, set the value to a Vector 2 called direction
        controls.MovePlayer.CameraMove.performed += ctx => pointing = ctx.ReadValue<Vector2>();
        //When the left stick is let go, set the value to a Vector 2 to 0
        controls.MovePlayer.CameraMove.canceled += ctx => pointing = Vector2.zero;
    }


    void OnEnable()
    { controls.MovePlayer.Enable(); }

    void OnDisable()
    { controls.MovePlayer.Disable(); }

    // Start is called before the first frame update
    void Start()
    {
        _offsetPosition = transform.position - GameObjectToFollow.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (RotateAroundPlayer)
        {
            Quaternion CamTurnAngle = Quaternion.AngleAxis(pointing.x * RotationSpeed, Vector3.up);
            _offsetPosition = CamTurnAngle * _offsetPosition;

        }

        Vector3 newPosition = GameObjectToFollow.position + _offsetPosition;
        transform.position = Vector3.Slerp(transform.position, newPosition, SmoothFactor);


        //   if (LookAtTarget )
        if (LookAtTarget || RotateAroundPlayer)
            transform.LookAt(GameObjectToFollow);

    }
}

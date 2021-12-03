using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//for new input system
using UnityEngine.InputSystem;

namespace Finlay._3dToolsForLevelDesign.Player
{
    public class PlayerInputs : MonoBehaviour
    {

        private PlayerMove move;
        private PlayerInteract interact;

        PlayerControls controls;

        void Awake()
        {
            move = GetComponent<PlayerMove>();
            interact = GetComponent<PlayerInteract>();

            controls = new PlayerControls();
            //When the left stick is moved, set the value to a Vector 2 called direction
            controls.MovePlayer._4DMovement.performed += ctx => move.UpdateDirection(ctx.ReadValue<Vector2>());
            //When the left stick is let go, set the value to a Vector 2 to 0
            controls.MovePlayer._4DMovement.canceled += ctx => move.UpdateDirection(Vector2.zero);

            controls.MovePlayer.Jump.performed += ctx => move.Jump();
            
            controls.MovePlayer.Interact.performed += ctx => interact.Interact(true);
            controls.MovePlayer.Interact.canceled += ctx => interact.Interact(false);
        }

        void OnEnable()
        { controls.MovePlayer.Enable(); }

        void OnDisable()
        { controls.MovePlayer.Disable(); }

    }
}
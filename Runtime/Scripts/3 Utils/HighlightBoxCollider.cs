using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Finlay._3dToolsForLevelDesign
{
    public class HighlightBoxCollider : MonoBehaviour
    {
        //for drawing the gizmo
        private BoxCollider b;
        private Vector3 point1, point2, point3, point4, point5, point6, point7, point8;
        public Color HighlightColour = new Color(0.9f, 0.8f, 0.1f, 1f);

        private void Awake()
        {
            b = GetComponent<BoxCollider>();
        }

        //to be able to see them inside the Unity editor
        //need to leave the component opened for some reason
        private void OnDrawGizmos()
        {
            if (!b)
            {
                b = GetComponent<BoxCollider>();
            }

            Gizmos.color = HighlightColour;

            //adapted from Tom163's post from here:
            //https://forum.unity.com/threads/get-vertices-of-box-collider.89301/
            point1 = transform.TransformPoint(b.center + new Vector3(b.size.x, -b.size.y, b.size.z) * 0.5f);
            point2 = transform.TransformPoint(b.center + new Vector3(-b.size.x, -b.size.y, b.size.z) * 0.5f);
            point3 = transform.TransformPoint(b.center + new Vector3(b.size.x, -b.size.y, -b.size.z) * 0.5f);
            point4 = transform.TransformPoint(b.center + new Vector3(-b.size.x, -b.size.y, -b.size.z) * 0.5f);
            point5 = transform.TransformPoint(b.center - new Vector3(-b.size.x, -b.size.y, -b.size.z) * 0.5f);
            point6 = transform.TransformPoint(b.center - new Vector3(b.size.x, -b.size.y, -b.size.z) * 0.5f);
            point7 = transform.TransformPoint(b.center - new Vector3(-b.size.x, -b.size.y, b.size.z) * 0.5f);
            point8 = transform.TransformPoint(b.center - new Vector3(b.size.x, -b.size.y, b.size.z) * 0.5f);

            //side1
            Gizmos.DrawLine(point1, point2);
            Gizmos.DrawLine(point1, point3);
            Gizmos.DrawLine(point4, point3);
            Gizmos.DrawLine(point4, point2);

            //center
            Gizmos.DrawLine(point1, point5);
            Gizmos.DrawLine(point2, point6);
            Gizmos.DrawLine(point3, point7);
            Gizmos.DrawLine(point4, point8);

            //side1
            Gizmos.DrawLine(point8, point7);
            Gizmos.DrawLine(point8, point6);
            Gizmos.DrawLine(point5, point7);
            Gizmos.DrawLine(point5, point6);

        }
    }
}
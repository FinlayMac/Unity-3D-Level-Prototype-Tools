using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Finlay._3dToolsForLevelDesign
{
    public class HighlightBoxCollider : MonoBehaviour
    {
        //for drawing the gizmo
        private BoxCollider m_Collider;
        private Vector3 point1, point2, point3, point4, point5, point6, point7, point8;
        public Color HighlightColour = new Color(0.9f, 0.8f, 0.1f, 1f);

        private void Awake()
        {
            m_Collider = GetComponent<BoxCollider>();
        }

        //to be able to see them inside the Unity editor
        //need to leave the component opened for some reason
        private void OnDrawGizmos()
        {
            if (!m_Collider)
            {
                m_Collider = GetComponent<BoxCollider>();
            }

            Gizmos.color = HighlightColour;
            // Gizmos.color = new Color(0.9f, 0.8f, 0.1f, 1f);

            point1 = m_Collider.bounds.min;
            point2 = new Vector3(m_Collider.bounds.min.x, m_Collider.bounds.min.y, m_Collider.bounds.max.z);
            point3 = new Vector3(m_Collider.bounds.min.x, m_Collider.bounds.max.y, m_Collider.bounds.min.z);
            point4 = new Vector3(m_Collider.bounds.min.x, m_Collider.bounds.max.y, m_Collider.bounds.max.z);
            point5 = new Vector3(m_Collider.bounds.max.x, m_Collider.bounds.min.y, m_Collider.bounds.min.z);
            point6 = new Vector3(m_Collider.bounds.max.x, m_Collider.bounds.min.y, m_Collider.bounds.max.z);
            point7 = new Vector3(m_Collider.bounds.max.x, m_Collider.bounds.max.y, m_Collider.bounds.min.z);
            point8 = m_Collider.bounds.max;

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
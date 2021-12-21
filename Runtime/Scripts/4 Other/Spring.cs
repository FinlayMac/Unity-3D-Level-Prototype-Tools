using UnityEngine;

namespace Finlay._3dToolsForLevelDesign
{
    public class Spring : MonoBehaviour
    {
        private Animator anim;
        public float ResetTime = 2f;
        public float SpringStrength = 100f;
        private bool HasBeenActivated = false;

        private void Awake()
        { anim = GetComponent<Animator>(); }

        private void OnCollisionEnter(Collision other)
        {
            if (HasBeenActivated == false)
            {
                HasBeenActivated = true;
                anim.SetTrigger("Activate");
                other.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * SpringStrength);
                Invoke("ResetSpring", ResetTime);
            }
        }


        private void ResetSpring()
        {
            anim.SetTrigger("Reset");
            HasBeenActivated = false;
        }


    }
}
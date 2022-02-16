using UnityEngine.Events;
using UnityEngine;

namespace Finlay._3dToolsForLevelDesign
{
    public class FunctionTester : MonoBehaviour
    {
        public UnityEvent FunctionToRun;
        public void RunFunction()
        { FunctionToRun.Invoke(); }

    }
}
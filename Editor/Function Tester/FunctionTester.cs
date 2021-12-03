using UnityEngine.Events;
using UnityEngine;

public class FunctionTester : MonoBehaviour
{
    public UnityEvent FunctionToRun;
    public void RunFunction()
    { FunctionToRun.Invoke(); }

}

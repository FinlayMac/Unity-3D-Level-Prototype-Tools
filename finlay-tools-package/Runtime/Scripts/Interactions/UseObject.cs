using UnityEngine;

public class UseObject : MonoBehaviour
{

    private Interaction interaction;

    private void Awake()
    { interaction = GetComponentInParent<Interaction>(); }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //send signal to interaction
            interaction.PlayerInUseZone();
        }
    }
}

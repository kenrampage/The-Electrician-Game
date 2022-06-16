
using UnityEngine;

public class NodePowerHandler : MonoBehaviour
{
    public Node node;
    public GameObject poweredObject;

    // Update is called once per frame
    void Update()
    {
        if (node.poweredOn)
        {
            poweredObject.SetActive(true);
        }
        else
        {
            poweredObject.SetActive(false);
        }
    }
}

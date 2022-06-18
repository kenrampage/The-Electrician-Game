using UnityEngine;

public class RotateThis : MonoBehaviour
{
    public Vector3 rotation;
    public bool rotationOn;

    private void FixedUpdate()
    {
        if (rotationOn)
        {
            transform.Rotate(rotation, Space.Self);
        }
    }

    

    public void StartRotation()
    {
        // print("Rotation Started on " + gameObject.name);
        rotationOn = true;
    }

    public void StopRotation()
    {
        // print("Rotation Stopped on " + gameObject.name);
        rotationOn = false;
    }
}

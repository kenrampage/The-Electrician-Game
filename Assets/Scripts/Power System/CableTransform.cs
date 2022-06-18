using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableTransform : MonoBehaviour, IInteractable
{
    public GameObject startObj;
    public GameObject endObj;

    // public GameObject cableObj;
    public GameObject cableObject;
    public MeshRenderer cableMesh;

    public Material defaultMaterial;
    public Material previewMaterial;
    public Material collisionMaterial;

    // public GameObject sampleCable;
    // public GameObject collidingCable;

    private Vector3 initialScale;

    private Cable cable;


    public bool editMode;
    public bool previewMode;
    public bool collisionMode;

    public bool isColliding;


    private void OnEnable()
    {
        cableMesh = cableObject.GetComponent<MeshRenderer>();
        cable = GetComponent<Cable>();
        initialScale = cableObject.transform.localScale;
        UpdateCableTransform();

        InputManager.Instance.onCancel.AddListener(HandleCancelInput);
    }

    private void OnDisable()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (isColliding)
        {
            CollisionMaterialOn();
        }
        else if (!isColliding && (previewMode || editMode))
        { 
            PreviewMaterialOn();
        }

        if (previewMode)
        {
            UpdateCableTransform();
        }
        else if (editMode)
        {
            UpdateCableTransform();
            endObj.transform.position = PlayerHoldPosition.position;
        }


    }

    private void UpdateCableTransform()
    {
        float distance = Vector3.Distance(startObj.transform.position, endObj.transform.position); //Get distance between points
        cableObject.transform.localScale = new Vector3(initialScale.x, distance / 2f, initialScale.z); //sets scale based on distance between points
        // sampleCable.transform.localScale = new Vector3(initialScale.x, distance / 2f, initialScale.z);
        // collidingCable.transform.localScale = new Vector3(initialScale.x, distance / 2f, initialScale.z);

        Vector3 middlePoint = (startObj.transform.position + endObj.transform.position) / 2f; //Gets position direction in the middle between points
        cableObject.transform.position = middlePoint; //Sets cable position to middle point
        // sampleCable.transform.position = middlePoint;
        // collidingCable.transform.position = middlePoint;

        Vector3 rotationDir = (endObj.transform.position - startObj.transform.position); //Gets rotation direction between points
        cableObject.transform.up = rotationDir;
        // sampleCable.transform.up = rotationDir;
        // collidingCable.transform.up = rotationDir;
    }

    public void SetStartPosition(Vector3 pos)
    {
        startObj.transform.position = pos;
    }

    public void SetEndPosition(Vector3 pos)
    {
        endObj.transform.position = pos;
    }

    public void EditModeOn()
    {
        NodeManager.Instance.ResetConnectedNodes();


        cable.RemoveEndNodeFromManager();
        cable.RemoveSourceNodeFromEndNode();

        // cable.ClearEndNode();

        PreviewMaterialOn();
        editMode = true;
    }

    public void EditModeOff()
    {
        editMode = false;
        UpdateCableTransform();
    }

    public void CollisionModeOn(Vector3 pos)
    {
        // NodeManager.Instance.TurnUpdatesOn();
        // cable.AddEndNodeToManager();
        // cable.AddSourceNodeToEndNode();
        CollisionMaterialOn();
        SetEndPosition(pos);
        collisionMode = true;
    }

    public void PreviewModeOn(Vector3 pos)
    {
        // NodeManager.Instance.TurnUpdatesOn();
        cable.AddEndNodeToManager();
        // cable.AddSourceNodeToEndNode();
        PreviewMaterialOn();
        // SampleObjectOn();
        SetEndPosition(pos);
        previewMode = true;
    }

    public void PreviewModeOff()
    {

        previewMode = false;

    }

    private void DestroyThis()
    {

        cable.RemoveEndNodeFromManager();
        cable.RemoveSourceNodeFromEndNode();
        cable.RemoveEndNodeFromSourceNode();

        NodeManager.Instance.ResetConnectedNodes();
        Destroy(this.gameObject);

    }

    public void HandleCancelInput()
    {
        if (previewMode || editMode)
        {

            PreviewModeOff();
            EditModeOff();


            DestroyThis();
        }

    }

    private void PreviewMaterialOn()
    {
        cableMesh.material = previewMaterial;
    }

    public void DefaultMaterialOn()
    {
        cableMesh.material = defaultMaterial;
    }

    private void CollisionMaterialOn()
    {
        cableMesh.material = collisionMaterial;
    }

    // private void SampleObjectOn()
    // {

    //     cableObject.SetActive(false);
    //     sampleCable.SetActive(true);
    //     collidingCable.SetActive(false);


    // }

    // private void SampleObjectOff()
    // {

    //     cableObject.SetActive(true);
    //     sampleCable.SetActive(false);

    // }

    // private void CollisionObjectOn()
    // {
    //     cableObject.SetActive(false);
    //     sampleCable.SetActive(false);
    //     collidingCable.SetActive(true);
    // }

    // private void CollisionObjectOff()
    // {
    //     // cableObject.SetActive(false);
    //     // sampleCable.SetActive(false);
    //     collidingCable.SetActive(false);
    // }

    public void Install()
    {
        PreviewModeOff();
        EditModeOff();
        DefaultMaterialOn();
        // SampleObjectOff();
        // CollisionObjectOff();
        cable.AddSourceNodeToEndNode();
        cable.AddEndNodeToSourceNode();
        cable.AddEndNodeToManager();
        cable.AddSourceNodeToManager();
    }

    public void Edit()
    {

        EditModeOn();
        PreviewModeOff();



        // NodeManager.Instance.OnEdit();


    }



    public void Interact()
    {
        if (!InventoryManager.Instance.editingCable)
        {
            print(this.gameObject.name + " Picked Up!");
            Edit();
            InventoryManager.Instance.PickupCable(this.gameObject);
        }

    }

    public void Cancel()
    {

    }
}

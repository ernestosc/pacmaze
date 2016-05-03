
using UnityEngine;
using System.Collections;

public class RotationHandler : MonoBehaviour
{

    public ButtonManager buttonManager;
    private Vector3 deltaPos;
    private Vector3 pos;
    public GameObject pointer;
    public GameObject clone;

    // Use this for initialization
    void Start()
    {
        pos = pointer.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        deltaPos = pointer.transform.position - pos;
        pos = pointer.transform.position;

        if (buttonManager.currentState == buttonManager.XROT_STATE)
        {
            buttonManager.thingToManipulate.transform.Rotate(deltaPos.x * Time.deltaTime, 0, 0);
            if (buttonManager.manipulateClone) clone.transform.Rotate(deltaPos.x * Time.deltaTime, 0, 0);
        }
        else if (buttonManager.currentState == buttonManager.YROT_STATE)
        {
            buttonManager.thingToManipulate.transform.Rotate(0, deltaPos.y * Time.deltaTime, 0);
            if (buttonManager.manipulateClone) clone.transform.Rotate(0, deltaPos.y * Time.deltaTime, 0);
        }
        else if (buttonManager.currentState == buttonManager.ZROT_STATE)
        {
            buttonManager.thingToManipulate.transform.Rotate(0, 0, deltaPos.z * Time.deltaTime);
            if (buttonManager.manipulateClone) clone.transform.Rotate(0, 0, deltaPos.z * Time.deltaTime);
        }

    }
}

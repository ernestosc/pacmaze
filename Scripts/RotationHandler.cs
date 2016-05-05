
using UnityEngine;
using System.Collections;

public class RotationHandler : MonoBehaviour
{

    public ButtonManager buttonManager;
    private Vector3 deltaPos;
    private Vector3 pos;
    public GameObject center;
    public GameObject pointer;
    public GameObject clone;
    Vector3 pt;

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

        if (buttonManager.currentState == buttonManager.XROT_STATE && buttonManager.thingToManipulate != null)
        {
            pt = buttonManager.manipulateClone ? buttonManager.thingToManipulate.transform.position : center.transform.position;
            if (buttonManager.manipulateClone)
            {
                if (Mathf.Abs(deltaPos.y) > 0.5) {
                    buttonManager.thingToManipulate.transform.RotateAround(pt, buttonManager.thingToManipulate.transform.right, Mathf.Sign(deltaPos.y) * 90);
                    clone.transform.RotateAround(clone.transform.position, clone.transform.right, Mathf.Sign(deltaPos.y) * 90);
                }
            }
            else
            {
                buttonManager.thingToManipulate.transform.RotateAround(pt, center.transform.right, deltaPos.y * -15);
            }
        }
        else if (buttonManager.currentState == buttonManager.YROT_STATE && buttonManager.thingToManipulate != null)
        {
            pt = buttonManager.manipulateClone ? buttonManager.thingToManipulate.transform.position : center.transform.position;
            if (buttonManager.manipulateClone)
            {
                if ( Mathf.Abs(deltaPos.x) > 0.5) {
                    buttonManager.thingToManipulate.transform.RotateAround(pt, buttonManager.thingToManipulate.transform.up, Mathf.Sign(deltaPos.y) * 90);
                    clone.transform.RotateAround(clone.transform.position, clone.transform.up, Mathf.Sign(deltaPos.y) * 90);
                }
            }
            else
            {
                buttonManager.thingToManipulate.transform.RotateAround(pt, center.transform.up, deltaPos.y * -15);
            }
        }
        else if (buttonManager.currentState == buttonManager.ZROT_STATE && buttonManager.thingToManipulate != null)
        {
            pt = buttonManager.manipulateClone ? buttonManager.thingToManipulate.transform.position : center.transform.position;
            if (buttonManager.manipulateClone)
            {
                if (Mathf.Abs(deltaPos.x) > 0.5) {
                    buttonManager.thingToManipulate.transform.RotateAround(pt, buttonManager.thingToManipulate.transform.forward,  Mathf.Sign(deltaPos.y) * 90);
                    clone.transform.RotateAround(clone.transform.position, clone.transform.forward, Mathf.Sign(deltaPos.y) * 90);
                }
            }
            else
            {
                buttonManager.thingToManipulate.transform.RotateAround(pt, center.transform.forward, deltaPos.y * -15);
            }
        }

    }
}

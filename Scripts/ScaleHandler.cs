
using UnityEngine;
using System.Collections;

public class ScaleHandler : MonoBehaviour
{

    public ButtonManager buttonManager;
    private Vector3 deltaPos;
    private Vector3 pos;
    public GameObject pointer;

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

        if (buttonManager.currentState == buttonManager.SCALE_STATE)
        {
            Vector3 localScale = buttonManager.thingToManipulate.transform.localScale;
            buttonManager.thingToManipulate.transform.localScale = 
                new Vector3(localScale.x + deltaPos.y, localScale.y + deltaPos.y, localScale.z + deltaPos.y);

        }

    }
}


using UnityEngine;
using System.Collections;

public class ScaleHandler : MonoBehaviour
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

        if (buttonManager.currentState == buttonManager.SCALE_STATE && buttonManager.thingToManipulate != null)
        {
            Vector3 localScale = buttonManager.thingToManipulate.transform.localScale;
            if (buttonManager.thingToManipulate == buttonManager.cookie)
            {
                float scale = Mathf.Min(Mathf.Max(localScale.x + (deltaPos.y * 0.1f), .1f), .3f);
                buttonManager.cookie.transform.localScale = new Vector3(scale, scale, scale);
                if (buttonManager.manipulateClone) clone.transform.localScale = new Vector3(scale, scale, scale);
            } else {
                float scale = Mathf.Min(Mathf.Max(localScale.x + (deltaPos.y * 0.1f), .025f), .12f);
                buttonManager.thingToManipulate.transform.localScale = new Vector3(scale, scale, scale);
            }

        }

    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public ButtonManager buttonManager;
    public GameObject avatar;
    public GameObject teleportDestination;
    public LineRenderer lineRenderer;

    // Use this for initialization
    void Start () {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.enabled = false;
    }

	// Update is called once per frame
	void Update () {

//        if (buttonManager.currentState == buttonManager.TELEPORT_STATE ||
//            buttonManager.currentState == buttonManager.MOVE_STATE)
//        {
//            avatar.GetComponent<CapsuleCollider>().enabled = false;
//            //avatar.GetComponent<Renderer>().material.shader = Shader.Find("Standard");
//        } else
//        {
//            avatar.GetComponent<CapsuleCollider>().enabled = true;
//        }

        if ((buttonManager.currentState == buttonManager.TELEPORT_STATE ||
            buttonManager.currentState == buttonManager.MOVE_STATE) &&
            teleportDestination != null && ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0)))
        {
            avatar.transform.position = teleportDestination.transform.position;
            if (buttonManager.currentState == buttonManager.TELEPORT_STATE) buttonManager.doneTeleporting = true;
        }
    }
}

using UnityEngine;
using System.Collections;

public class UnitScript : MonoBehaviour {
    /*
    public CameraScript cameraScript;
    public ButtonManager buttonManager;

    // Use this for initialization
    void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        /if((cameraScript.teleportDestination != null && cameraScript.teleportDestination.GetComponent<Collider>() != other))
        {
            //Debug.Log("New Unit Colliding");
            (cameraScript.teleportDestination.GetComponent("Halo") as Behaviour).enabled = false;
            cameraScript.lineRenderer.enabled = false;
        }

        if (buttonManager.currentState == buttonManager.MOVE_STATE) {

        }

        if ((buttonManager.currentState == buttonManager.TELEPORT_STATE ||
            buttonManager.currentState == buttonManager.MOVE_STATE) && other.gameObject.CompareTag("Pointer"))
        {
            //Debug.Log("Enter");
            cameraScript.teleportDestination = this.gameObject;
            (cameraScript.teleportDestination.GetComponent("Halo") as Behaviour).enabled = true;
            cameraScript.lineRenderer.SetColors(Color.yellow, Color.yellow);
            cameraScript.lineRenderer.SetWidth(.1f, .1f);
            cameraScript.lineRenderer.SetVertexCount(2);
            cameraScript.lineRenderer.SetPosition(0, cameraScript.avatar.transform.position);
            cameraScript.lineRenderer.SetPosition(1, this.gameObject.transform.position);
            cameraScript.lineRenderer.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        if ((buttonManager.currentState == buttonManager.TELEPORT_STATE ||
            buttonManager.currentState == buttonManager.MOVE_STATE) && other.gameObject.CompareTag("Pointer"))
        {
            (cameraScript.teleportDestination.GetComponent("Halo") as Behaviour).enabled = false;
            cameraScript.teleportDestination = null;
            cameraScript.lineRenderer.enabled = false;
        }

    }*/
}

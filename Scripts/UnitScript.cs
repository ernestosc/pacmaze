using UnityEngine;
using System.Collections;

public class UnitScript : MonoBehaviour {

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
        if (buttonManager.currentState == buttonManager.TELEPORT_STATE && other.gameObject.CompareTag("Pointer")
            && !this.gameObject.CompareTag("DeadEnd") && cameraScript.teleportDestination == null)
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

        // else if((cameraScript.teleportDestination != null && cameraScript.teleportDestination.GetComponent<Collider>() != other))
        // {
        //     //Debug.Log("New Unit Colliding");
        //     (cameraScript.teleportDestination.GetComponent("Halo") as Behaviour).enabled = false;
        //     cameraScript.lineRenderer.enabled = false;
        // }

        else if (buttonManager.currentState == buttonManager.MOVE_STATE && other.gameObject.CompareTag("Pointer") && cameraScript.teleportDestination == null)
        {
            Vector3 dist = cameraScript.avatar.transform.localPosition - this.transform.localPosition;
            buttonManager.state.text = "" + dist;
            if(dist.magnitude >= 0.95 && dist.magnitude <= 1.05){
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

    }

    void OnTriggerExit(Collider other)
    {
        if ((buttonManager.currentState == buttonManager.TELEPORT_STATE ||
            buttonManager.currentState == buttonManager.MOVE_STATE) && other.gameObject.CompareTag("Pointer") && cameraScript.teleportDestination == this.gameObject)
        {
            (GetComponent("Halo") as Behaviour).enabled = false;
            cameraScript.teleportDestination = null;
            cameraScript.lineRenderer.enabled = false;
        }

    }
}

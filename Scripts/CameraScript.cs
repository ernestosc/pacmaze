using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public ButtonManager buttonManager;
    public GameObject avatar;
    public GameObject teleportDestination;
    public LineRenderer lineRenderer;
    public GameObject workspace;
    public GameObject clone;

    GameObject obs;

    // Use this for initialization
    void Start () {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.enabled = false;
        obs = null;
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
			
            if (obs != null) Destroy(obs);
            avatar.transform.position = teleportDestination.transform.position;
            for(int i = 0; i < teleportDestination.transform.childCount; ++i){
                if (teleportDestination.transform.GetChild(i).CompareTag("Obstacle"))
                {
                    Vector3 obsPos = teleportDestination.transform.GetChild(i).transform.position;
                    obs = Instantiate(teleportDestination.transform.GetChild(i),
                            clone.transform.position + (obsPos - avatar.transform.position),
                            teleportDestination.transform.GetChild(i).transform.localRotation) as GameObject;
                    obs.transform.parent = workspace.transform;
                    break;
                }
            }
            (teleportDestination.GetComponent("Halo") as Behaviour).enabled = false;
            lineRenderer.enabled = false;
            teleportDestination = null;
            if (buttonManager.currentState == buttonManager.TELEPORT_STATE) buttonManager.doneTeleporting = true;
        }
    }
}

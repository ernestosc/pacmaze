using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public ButtonManager buttonManager;
    public GameObject avatar;
    public GameObject teleportDestination;
    public GameObject currentLocation;
    public LineRenderer lineRenderer;
    public GameObject workspace;
    public GameObject clone;
    public Text wrong;

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
            bool moved = false;
            bool currentLocHasObstacle = false;
            bool teleportDestHasObstacle = false;
            for (int i = 0; i < teleportDestination.transform.childCount; i++)
            {
                if (teleportDestination.transform.GetChild(i).CompareTag("Obstacle"))
                {
                    teleportDestHasObstacle = true;
                    break;
                }
            }
            for (int i = 0; i < currentLocation.transform.childCount; i++)
            {
                if (currentLocation.transform.GetChild(i).CompareTag("Obstacle"))
                {
                    currentLocHasObstacle = true;
                    break;
                }
            }

            if (teleportDestHasObstacle && currentLocHasObstacle)
            {
                if(avatar.transform.localScale.x < .25f)
                {
                    avatar.transform.position = teleportDestination.transform.position;
                    currentLocation = teleportDestination;
                    if (obs != null) Destroy(obs);
                    moved = true;
                    wrong.text = "";
                }
                else
                {
                    wrong.text = "Can't fit through the obstacle!";
                }
            } else
            {
                avatar.transform.position = teleportDestination.transform.position;
                currentLocation = teleportDestination;
                if (obs != null) Destroy(obs);
                moved = true;
                wrong.text = "";
            }

            for (int i = 0; i < teleportDestination.transform.childCount; ++i)
            {
                if (moved && teleportDestination.transform.GetChild(i).CompareTag("Obstacle"))
                {
                    Vector3 obsPos = teleportDestination.transform.GetChild(i).position;
                    obs = Instantiate(teleportDestination.transform.GetChild(i).gameObject) as GameObject;
                    obs.transform.parent = workspace.transform;
                    obs.transform.localPosition = clone.transform.localPosition + (obsPos - avatar.transform.position);
                    obs.transform.localScale = clone.transform.localScale;
                    obs.transform.localRotation = teleportDestination.transform.GetChild(i).localRotation;
                    break;
                }
            }

            if (moved)
            {
                (teleportDestination.GetComponent("Halo") as Behaviour).enabled = false;
                lineRenderer.enabled = false;
                teleportDestination = null;
                if (buttonManager.currentState == buttonManager.TELEPORT_STATE) buttonManager.doneTeleporting = true;
            }
        }
    }
}

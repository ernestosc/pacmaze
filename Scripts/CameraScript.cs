using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public bool teleport;
    public UnitScript unitScript;
    public GameObject avatar;
    public GameObject teleportDestination;
    public LineRenderer lineRenderer;

    // Use this for initialization
    void Start () {
        teleport = false;
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.enabled = false;
    }

    public void switchTeleportMode()
    {
        teleport = !teleport;
        Debug.Log(teleport);
    }

	// Update is called once per frame
	void Update () {

        if (teleport)
        {
            avatar.GetComponent<CapsuleCollider>().enabled = false;
            avatar.GetComponent<Renderer>().material.shader = Shader.Find("Standard");
        } else
        {
            avatar.GetComponent<CapsuleCollider>().enabled = true;
        }

        if (teleport && teleportDestination != null && ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0)))
        {
            avatar.transform.position = teleportDestination.transform.position;
            teleport = false;
        }


    }
}

﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Vuforia;


public class ButtonManager : MonoBehaviour, IVirtualButtonEventHandler{

	//constants for states
	public string START_STATE = "START";
    public string ZOOM_STATE = "MAZE";
    public string SELECTED_STATE = "SELECTED";
    public string MOVE_STATE = "TRANSLATE";
    public string MANIPULATE_STATE = "MANIPULATE";
    public string SCALE_STATE = "SCALE";
    public string ROTATION_STATE = "ROTATE";
    public string XROT_STATE = "X";
    public string YROT_STATE = "Y";
    public string ZROT_STATE = "Z";
    public string TELEPORT_STATE = "TELEPORT";

    const int ZOOM = 0;
	const int CANCEL = 1;
	const int TELEPORT = 2;
	const int MANIPULATOR = 3;
	const int TRANSLATE = 4;
	const int SCALE = 5;
	const int ROTATE = 6;
	const int XROT = 7;
	const int YROT = 8;
	const int ZROT = 9;

    public string currentState;

    public GameObject maze;
    public GameObject cookie;
    public GameObject clone;
    public GameObject thingToManipulate;

	VirtualButtonBehaviour[] vbs;
    public bool objSelected;
    public bool doneTeleporting;
    public bool manipulateClone;
    public Text state;
    public Texture2D deselect;
    public Texture2D done;
    public GameObject donebutton;

    public CameraScript cameraScript;
    //public GameObject[] prefabBtns;
    public VirtualButtonBehaviour[] buttons;

    // Use this for initialization
    IEnumerator Start()
    {
        START_STATE = "START";
        ZOOM_STATE = "MAZE";
        SELECTED_STATE = "SELECTED";
        MOVE_STATE = "TRANSLATE";
        MANIPULATE_STATE = "MANIPULATE";
        SCALE_STATE = "SCALE";
        ROTATION_STATE = "ROTATE";
        XROT_STATE = "X";
        YROT_STATE = "Y";
        ZROT_STATE = "Z";
        TELEPORT_STATE = "TELEPORT";

        currentState = START_STATE;

        objSelected = false;
        doneTeleporting = false;
        manipulateClone = false;
        thingToManipulate = null;

        // Search for all Children from this ImageTarget with type VirtualButtonBehaviour
        //vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < buttons.Length; ++i) {
            // Register with the virtual buttons TrackableBehaviour
            buttons[i].RegisterEventHandler(this);
        }

        yield return new WaitForSeconds(2f);

        for (int i = 0; i < buttons.Length; ++i)
        {
            if (!buttons[i].CompareTag("Zoom")) {
                buttons[i].gameObject.SetActive(false);
            }
        }

		// ZoomBtn = vbs [0].gameObject;
	}

    // Update is called once per frame
    void Update()
    {
        // vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        // for (int i = 0; i < vbs.Length; ++i) {
        // 	// Register with the virtual buttons TrackableBehaviour
        // 	vbs[i].RegisterEventHandler(this);
        // }
        Debug.Log(currentState.ToString());


		//GUI feedback messages/hints
		if (currentState == START_STATE) {
			state.text = "Touch man with wand or press 'MAZE' on remote.";
		}
		else if (currentState == ZOOM_STATE || currentState == SELECTED_STATE) {
			state.text = "Select an action ";
            if (currentState == ZOOM_STATE) state.text += "to transform maze.";
		}
		else if (currentState == ROTATION_STATE) {
			state.text = "Pick an axis to rotate.";
		}
		else if (currentState == XROT_STATE || currentState == YROT_STATE || currentState== ZROT_STATE) {
			state.text = "Move wand up and down to rotate. Tap to finish.";
		}
		else if (currentState == SCALE_STATE) {
			state.text = "Move wand in and out to scale. Tap to finish.";
		}
        else if (currentState == MANIPULATE_STATE)
        {
            state.text = "Select an action";
        }
        else if (currentState == MOVE_STATE) {
			if (cameraScript.teleportDestination != null) {
				state.text = "Tap to move.";
			} else {
				state.text = "Hover on adjacent cube to move.";
			}
		}
		else if (currentState == TELEPORT_STATE) {
			if (cameraScript.teleportDestination != null) {
				state.text = "Tap to teleport.";
			}
			else{
				state.text = "Hover on any cube.";
			}
		}

        if (objSelected && currentState == START_STATE)
        {
            buttons[ZOOM].gameObject.SetActive(false);
            buttons[TELEPORT].gameObject.SetActive(true);
            buttons[MANIPULATOR].gameObject.SetActive(true);
            buttons[TRANSLATE].gameObject.SetActive(true);
            buttons[CANCEL].gameObject.SetActive(true);
            donebutton.GetComponent<Renderer>().material.mainTexture = deselect;
            currentState = SELECTED_STATE;
            objSelected = false;
        }

        if (doneTeleporting && currentState == TELEPORT_STATE)
        {
            state.text = "LEAVING TELEPORT.";
            buttons[MANIPULATOR].gameObject.SetActive(true);
            buttons[TRANSLATE].gameObject.SetActive(true);
            buttons[TELEPORT].gameObject.SetActive(true);
            buttons[CANCEL].gameObject.SetActive(true);
            donebutton.GetComponent<Renderer>().material.mainTexture = deselect;
            currentState = SELECTED_STATE;
            doneTeleporting = false;
        }

        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0))
        {

            if (currentState == SCALE_STATE)
            {
                buttons[ROTATE].gameObject.SetActive(true);
                buttons[SCALE].gameObject.SetActive(true);
                buttons[CANCEL].gameObject.SetActive(true);
				if (thingToManipulate == cookie)
					currentState = MANIPULATE_STATE;
				else if (thingToManipulate == maze)
                    currentState = ZOOM_STATE;
            }
            else if (currentState == XROT_STATE || currentState == YROT_STATE || currentState == ZROT_STATE)
            {
                buttons[XROT].gameObject.SetActive(true);
                buttons[YROT].gameObject.SetActive(true);
                buttons[ZROT].gameObject.SetActive(true);
                buttons[CANCEL].gameObject.SetActive(true);
                currentState = ROTATION_STATE;
            }
        }

    }

	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb) {

		//big if else of each button (through the tags) if vb.compareTag....
		if (vb.CompareTag ("Zoom")) {

			if (currentState == START_STATE) {


                buttons[ZOOM].gameObject.SetActive(false);
                buttons[ROTATE].gameObject.SetActive(true);
                buttons[SCALE].gameObject.SetActive(true);
                buttons[CANCEL].gameObject.SetActive(true);

                thingToManipulate = maze;
				currentState = ZOOM_STATE;

			}

		} else if (vb.CompareTag ("Manipulator")) {

            if (currentState == SELECTED_STATE)
            {
                buttons[MANIPULATOR].gameObject.SetActive(false);
                buttons[TRANSLATE].gameObject.SetActive(false);
                buttons[TELEPORT].gameObject.SetActive(false);
                buttons[ROTATE].gameObject.SetActive(true);
                buttons[SCALE].gameObject.SetActive(true);
                donebutton.GetComponent<Renderer>().material.mainTexture = done;
                thingToManipulate = cookie;
                manipulateClone = true;
                currentState = MANIPULATE_STATE;
            }

        } else if (vb.CompareTag ("Rotator")) {

            if (currentState == ZOOM_STATE || currentState == MANIPULATE_STATE)
            {
                buttons[ROTATE].gameObject.SetActive(false);
                buttons[SCALE].gameObject.SetActive(false);

                buttons[XROT].gameObject.SetActive(true);
                buttons[YROT].gameObject.SetActive(true);
                buttons[ZROT].gameObject.SetActive(true);

                currentState = ROTATION_STATE;
            }

        } else if (vb.CompareTag ("Translator")) {

            if (currentState == SELECTED_STATE) {
                buttons[MANIPULATOR].gameObject.SetActive(false);
                buttons[TRANSLATE].gameObject.SetActive(false);
                buttons[TELEPORT].gameObject.SetActive(false);
                donebutton.GetComponent<Renderer>().material.mainTexture = done;

                currentState = MOVE_STATE;
            }

		} else if (vb.CompareTag ("XRot")) {

            if (currentState == ROTATION_STATE)
            {
                buttons[XROT].gameObject.SetActive(false);
                buttons[YROT].gameObject.SetActive(false);
                buttons[ZROT].gameObject.SetActive(false);
                buttons[CANCEL].gameObject.SetActive(false);
                currentState = XROT_STATE;
            }

        } else if (vb.CompareTag ("YRot")) {

            if (currentState == ROTATION_STATE)
            {
                buttons[XROT].gameObject.SetActive(false);
                buttons[YROT].gameObject.SetActive(false);
                buttons[ZROT].gameObject.SetActive(false);
                buttons[CANCEL].gameObject.SetActive(false);
                currentState = YROT_STATE;
            }

		} else if (vb.CompareTag ("ZRot")) {

            if (currentState == ROTATION_STATE)
            {
                buttons[XROT].gameObject.SetActive(false);
                buttons[YROT].gameObject.SetActive(false);
                buttons[ZROT].gameObject.SetActive(false);
                buttons[CANCEL].gameObject.SetActive(false);
                currentState = ZROT_STATE;
            }

		} else if (vb.CompareTag ("Scaler")) {

            if (currentState == ZOOM_STATE || currentState == MANIPULATE_STATE)
            {
                buttons[ROTATE].gameObject.SetActive(false);
                buttons[SCALE].gameObject.SetActive(false);
                buttons[CANCEL].gameObject.SetActive(false);
                currentState = SCALE_STATE;
            }

		} else if (vb.CompareTag ("Teleport")) {

            if (currentState == SELECTED_STATE)
            {
                buttons[MANIPULATOR].gameObject.SetActive(false);
                buttons[TRANSLATE].gameObject.SetActive(false);
                buttons[TELEPORT].gameObject.SetActive(false);
				buttons[CANCEL].gameObject.SetActive(false);
                currentState = TELEPORT_STATE;
            }

		} else if (vb.CompareTag ("Cancel")) {

            if (currentState == ZOOM_STATE)
            {
                buttons[ROTATE].gameObject.SetActive(false);
                buttons[SCALE].gameObject.SetActive(false);
                buttons[CANCEL].gameObject.SetActive(false);
                buttons[ZOOM].gameObject.SetActive(true);
                //thingToManipulate = null;
                currentState = START_STATE;
            }
            else if (currentState == SELECTED_STATE)
            {
                buttons[TELEPORT].gameObject.SetActive(false);
                buttons[MANIPULATOR].gameObject.SetActive(false);
                buttons[TRANSLATE].gameObject.SetActive(false);
                buttons[CANCEL].gameObject.SetActive(false);
                donebutton.GetComponent<Renderer>().material.mainTexture = done;
                buttons[ZOOM].gameObject.SetActive(true);
                objSelected = false;
                (cookie.GetComponent("Halo") as Behaviour).enabled = false;
                currentState = START_STATE;
            }
            else if (currentState == MOVE_STATE)
            {
                buttons[MANIPULATOR].gameObject.SetActive(true);
                buttons[TRANSLATE].gameObject.SetActive(true);
                buttons[TELEPORT].gameObject.SetActive(true);
                donebutton.GetComponent<Renderer>().material.mainTexture = deselect;
                currentState = SELECTED_STATE;
            }
            else if (currentState == MANIPULATE_STATE)
            {
                buttons[ROTATE].gameObject.SetActive(false);
                buttons[SCALE].gameObject.SetActive(false);
                buttons[MANIPULATOR].gameObject.SetActive(true);
                buttons[TRANSLATE].gameObject.SetActive(true);
                buttons[TELEPORT].gameObject.SetActive(true);
                donebutton.GetComponent<Renderer>().material.mainTexture = deselect;
                //thingToManipulate = null;
                manipulateClone = false;
                currentState = SELECTED_STATE;
            }
            else if (currentState == ROTATION_STATE)
            {
                buttons[XROT].gameObject.SetActive(false);
                buttons[YROT].gameObject.SetActive(false);
                buttons[ZROT].gameObject.SetActive(false);
                buttons[ROTATE].gameObject.SetActive(true);
                buttons[SCALE].gameObject.SetActive(true);
				if (thingToManipulate == cookie)
					currentState = MANIPULATE_STATE;
				else if (thingToManipulate == maze)
					currentState = ZOOM_STATE;
            }
		}
	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb) {
	}
}

using UnityEngine;
using System.Collections;
using Vuforia;

public class ButtonManager : MonoBehaviour, IVirtualButtonEventHandler{

	//constants for states
	public int START_STATE = 0;
    public int ZOOM_STATE = 1;
    public int SELECTED_STATE = 2;
    public int MOVE_STATE = 3;
    public int MANIPULATE_STATE = 4;
    public int SCALE_STATE = 5;
    public int ROTATION_STATE = 6;
    public int XROT_STATE = 7;
    public int YROT_STATE = 8;
    public int ZROT_STATE = 9;
    public int TELEPORT_STATE = 10;

    const int ZOOM = 0;
	const int UNDO = 1;
	const int DONE = 2;
	const int TELEPORT = 3;
	const int MANIPULATOR = 4;
	const int TRANSLATE = 5;
	const int SCALE = 6;
	const int ROTATE = 7;
	const int XROT = 8;
	const int YROT = 9;
	const int ZROT = 10;
	const int CANCEL = 11;

    public int currentState;

    public GameObject maze;
    public GameObject cookie;
    public GameObject thingToManipulate;

	VirtualButtonBehaviour[] vbs;
    public bool objSelected;
    public bool doneTeleporting;
    public bool manipulateClone;

    //public GameObject[] prefabBtns;
    public VirtualButtonBehaviour[] buttons;

    // Use this for initialization
    void Start () {

		currentState = START_STATE;
        objSelected = false;
        doneTeleporting = false;
        manipulateClone = false;

        // Search for all Children from this ImageTarget with type VirtualButtonBehaviour
        //vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < buttons.Length; ++i) {
            // Register with the virtual buttons TrackableBehaviour
            buttons[i].RegisterEventHandler(this);
        }

        for (int i = 0; i < buttons.Length; ++i)
        {
            if (!buttons[i].CompareTag("Zoom")) {
                buttons[i].gameObject.SetActive(false);
            }
        }

		// ZoomBtn = vbs [0].gameObject;
	}

	// Update is called once per frame
	void Update () {

		// vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
		// for (int i = 0; i < vbs.Length; ++i) {
		// 	// Register with the virtual buttons TrackableBehaviour
		// 	vbs[i].RegisterEventHandler(this);
        // }

        if (objSelected && currentState == START_STATE)
        {
            buttons[ZOOM].gameObject.SetActive(false);
            buttons[TELEPORT].gameObject.SetActive(true);
            buttons[MANIPULATOR].gameObject.SetActive(true);
            buttons[TRANSLATE].gameObject.SetActive(true);
            currentState = SELECTED_STATE;
            objSelected = false;
        }

        if (doneTeleporting && (currentState == TELEPORT_STATE || currentState == MOVE_STATE))
        {
            buttons[MANIPULATOR].gameObject.SetActive(true);
            buttons[TRANSLATE].gameObject.SetActive(true);
            buttons[TELEPORT].gameObject.SetActive(true);
            currentState = SELECTED_STATE;
            doneTeleporting = false;
        }

    }

	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb) {

		//big if else of each button (through the tags) if vb.compareTag....
		if (vb.CompareTag ("Zoom")) {

			if (currentState == START_STATE) {

                buttons[ZOOM].gameObject.SetActive(false);
                buttons[ROTATE].gameObject.SetActive(true);
                buttons[SCALE].gameObject.SetActive(true);
                buttons[DONE].gameObject.SetActive(true);
                buttons[CANCEL].gameObject.SetActive(true);

                thingToManipulate = maze;
				currentState = ZOOM_STATE;

			}


		} else if (vb.CompareTag ("Undo")) {



		} else if (vb.CompareTag ("Done")) {

            if (currentState == ZOOM_STATE)
            {
                buttons[ROTATE].gameObject.SetActive(false);
                buttons[SCALE].gameObject.SetActive(false);
                buttons[DONE].gameObject.SetActive(false);
                buttons[CANCEL].gameObject.SetActive(false);
                buttons[ZOOM].gameObject.SetActive(true);
                thingToManipulate = null;
                currentState = START_STATE;
            }
            else if (currentState == MANIPULATE_STATE)
            {
                buttons[ROTATE].gameObject.SetActive(false);
                buttons[SCALE].gameObject.SetActive(false);
                buttons[DONE].gameObject.SetActive(false);
                buttons[MANIPULATOR].gameObject.SetActive(true);
                buttons[TRANSLATE].gameObject.SetActive(true);
                buttons[TELEPORT].gameObject.SetActive(true);
                thingToManipulate = null;
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
                currentState = MANIPULATE_STATE;
            }
            else if (currentState == SCALE_STATE)
            {
                buttons[UNDO].gameObject.SetActive(false);
                buttons[ROTATE].gameObject.SetActive(true);
                buttons[SCALE].gameObject.SetActive(true);
                currentState = MANIPULATE_STATE;
            }
            else if (currentState == XROT_STATE || currentState == XROT_STATE || currentState == XROT_STATE)
            {
                buttons[UNDO].gameObject.SetActive(false);
                buttons[XROT].gameObject.SetActive(true);
                buttons[YROT].gameObject.SetActive(true);
                buttons[ZROT].gameObject.SetActive(true);
                currentState = ROTATION_STATE;
            }

		} else if (vb.CompareTag ("Manipulator")) {

            if (currentState == SELECTED_STATE)
            {
                buttons[MANIPULATOR].gameObject.SetActive(false);
                buttons[TRANSLATE].gameObject.SetActive(false);
                buttons[TELEPORT].gameObject.SetActive(false);
                buttons[ROTATE].gameObject.SetActive(true);
                buttons[SCALE].gameObject.SetActive(true);
                buttons[DONE].gameObject.SetActive(true);
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

                currentState = MOVE_STATE;
            }

		} else if (vb.CompareTag ("XRot")) {

            if (currentState == ROTATION_STATE)
            {
                buttons[XROT].gameObject.SetActive(false);
                buttons[YROT].gameObject.SetActive(false);
                buttons[ZROT].gameObject.SetActive(false);
                buttons[UNDO].gameObject.SetActive(true);

                currentState = XROT_STATE;
            }

        } else if (vb.CompareTag ("YRot")) {

            if (currentState == ROTATION_STATE)
            {
                buttons[XROT].gameObject.SetActive(false);
                buttons[YROT].gameObject.SetActive(false);
                buttons[ZROT].gameObject.SetActive(false);
                buttons[UNDO].gameObject.SetActive(true);

                currentState = YROT_STATE;
            }

		} else if (vb.CompareTag ("ZRot")) {

            if (currentState == ROTATION_STATE)
            {
                buttons[XROT].gameObject.SetActive(false);
                buttons[YROT].gameObject.SetActive(false);
                buttons[ZROT].gameObject.SetActive(false);
                buttons[UNDO].gameObject.SetActive(true);

                currentState = ZROT_STATE;
            }

		} else if (vb.CompareTag ("Scaler")) {

            if (currentState == ZOOM_STATE || currentState == MANIPULATE_STATE)
            {
                buttons[ROTATE].gameObject.SetActive(false);
                buttons[SCALE].gameObject.SetActive(false);
                buttons[UNDO].gameObject.SetActive(true);

                currentState = SCALE_STATE;
            }

		} else if (vb.CompareTag ("Teleport")) {

            if (currentState == SELECTED_STATE)
            {
                buttons[MANIPULATOR].gameObject.SetActive(false);
                buttons[TRANSLATE].gameObject.SetActive(false);
                buttons[TELEPORT].gameObject.SetActive(false);
                currentState = TELEPORT_STATE;
            }

		} else if (vb.CompareTag ("Cancel")) {

            if (currentState == ZOOM_STATE)
            {
                buttons[ROTATE].gameObject.SetActive(false);
                buttons[SCALE].gameObject.SetActive(false);
                buttons[DONE].gameObject.SetActive(false);
                buttons[CANCEL].gameObject.SetActive(false);
                buttons[ZOOM].gameObject.SetActive(true);
                thingToManipulate = null;
                currentState = START_STATE;
            }
            else if (currentState == SELECTED_STATE)
            {
                buttons[TELEPORT].gameObject.SetActive(false);
                buttons[MANIPULATOR].gameObject.SetActive(false);
                buttons[TRANSLATE].gameObject.SetActive(false);
                buttons[CANCEL].gameObject.SetActive(false);
                buttons[ZOOM].gameObject.SetActive(true);
                objSelected = false;
                currentState = START_STATE;
            }
            else if (currentState == MOVE_STATE)
            {
                buttons[MANIPULATOR].gameObject.SetActive(true);
                buttons[TRANSLATE].gameObject.SetActive(true);
                buttons[TELEPORT].gameObject.SetActive(true);
                currentState = SELECTED_STATE;
            }
            else if (currentState == MANIPULATE_STATE)
            {
                buttons[ROTATE].gameObject.SetActive(false);
                buttons[SCALE].gameObject.SetActive(false);
                buttons[DONE].gameObject.SetActive(false);
                buttons[MANIPULATOR].gameObject.SetActive(true);
                buttons[TRANSLATE].gameObject.SetActive(true);
                buttons[TELEPORT].gameObject.SetActive(true);
                thingToManipulate = null;
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
                currentState = MANIPULATE_STATE;
            }
            else if (currentState == SCALE_STATE)
            {
                buttons[UNDO].gameObject.SetActive(false);
                buttons[ROTATE].gameObject.SetActive(true);
                buttons[SCALE].gameObject.SetActive(true);
                currentState = MANIPULATE_STATE;
            }
            else if (currentState == XROT_STATE || currentState == XROT_STATE || currentState == XROT_STATE)
            {
                buttons[UNDO].gameObject.SetActive(false);
                buttons[XROT].gameObject.SetActive(true);
                buttons[YROT].gameObject.SetActive(true);
                buttons[ZROT].gameObject.SetActive(true);
                currentState = ROTATION_STATE;
            }

		}

	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb) {


	}


}

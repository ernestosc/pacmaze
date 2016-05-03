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

	public GameObject[] prefabBtns;

	GameObject ZoomBtn;
	GameObject UndoBtn;
	GameObject DoneBtn;
	GameObject TeleportBtn;
	GameObject ManipulatorBtn;
	GameObject TranslatorBtn;
	GameObject ScalerBtn;
	GameObject RotatorBtn;
	GameObject XRotBtn;
	GameObject YRotBtn;
	GameObject ZRotBtn;
	GameObject CancelBtn;






	// Use this for initialization
	void Start () {

		currentState = START_STATE;
		objSelected = false;

		// Search for all Children from this ImageTarget with type VirtualButtonBehaviour
		vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
		for (int i = 0; i < vbs.Length; ++i) {
			// Register with the virtual buttons TrackableBehaviour
			vbs[i].RegisterEventHandler(this);
		}

		ZoomBtn = vbs [0].gameObject;


	
	}
	
	// Update is called once per frame
	void Update () {

		vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
		for (int i = 0; i < vbs.Length; ++i) {
			// Register with the virtual buttons TrackableBehaviour
			vbs[i].RegisterEventHandler(this);
		}
	
	}

	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb) {
        if (currentState != START_STATE)
        {
            CancelBtn = Instantiate(prefabBtns[CANCEL]) as GameObject;
            CancelBtn.transform.SetParent(this.gameObject.transform);
        }

		//big if else of each button (through the tags) if vb.compareTag....
		if (vb.CompareTag ("Zoom")) { 

			if (!objSelected) {

				Destroy (ZoomBtn);

				RotatorBtn = Instantiate (prefabBtns [ROTATE]) as GameObject;
				RotatorBtn.transform.SetParent (this.gameObject.transform);

				ScalerBtn = Instantiate (prefabBtns [SCALE]) as GameObject;
				ScalerBtn.transform.SetParent (this.gameObject.transform);

				DoneBtn = Instantiate (prefabBtns [DONE]) as GameObject;
				DoneBtn.transform.SetParent (this.gameObject.transform);

                thingToManipulate = maze;
				currentState = ZOOM_STATE;

			}

		
		} else if (vb.CompareTag ("Undo")) {
			
			//other behav

		} else if (vb.CompareTag ("Done")) {



			//other behav

		} else if (vb.CompareTag ("Manipulator")) {

			ScalerBtn = Instantiate (prefabBtns [SCALE]) as GameObject;
			ScalerBtn.transform.SetParent (this.gameObject.transform);

			RotatorBtn = Instantiate (prefabBtns [ROTATE]) as GameObject;
			RotatorBtn.transform.SetParent (this.gameObject.transform);

			DoneBtn = Instantiate (prefabBtns [DONE]) as GameObject;
			DoneBtn.transform.SetParent (this.gameObject.transform);

            thingToManipulate = cookie;
            currentState = MANIPULATE_STATE;

			
		} else if (vb.CompareTag ("Rotator")) {

            if (currentState == ZOOM_STATE)
            {
                Destroy(RotatorBtn);
                Destroy(ScalerBtn);  

                XRotBtn = Instantiate(prefabBtns[XROT]) as GameObject;
                XRotBtn.transform.SetParent(this.gameObject.transform);

                YRotBtn = Instantiate(prefabBtns[YROT]) as GameObject;
                YRotBtn.transform.SetParent(this.gameObject.transform);

                ZRotBtn = Instantiate(prefabBtns[ZROT]) as GameObject;
                ZRotBtn.transform.SetParent(this.gameObject.transform);

                currentState = ROTATION_STATE;
            }

			
		} else if (vb.CompareTag ("Translator")) {


			//only cancel btn is needed 

			
		} else if (vb.CompareTag ("XRot")) {

			UndoBtn = Instantiate (prefabBtns [UNDO]) as GameObject;
			UndoBtn.transform.SetParent (this.gameObject.transform);

			DoneBtn = Instantiate (prefabBtns [DONE]) as GameObject;
			DoneBtn.transform.SetParent (this.gameObject.transform);

			currentState = XROT_STATE;


		} else if (vb.CompareTag ("YRot")) {

			UndoBtn = Instantiate (prefabBtns [UNDO]) as GameObject;
			UndoBtn.transform.SetParent (this.gameObject.transform);

			DoneBtn = Instantiate (prefabBtns [DONE]) as GameObject;
			DoneBtn.transform.SetParent (this.gameObject.transform);

			currentState = YROT_STATE;
			
		} else if (vb.CompareTag ("ZRot")) {

			UndoBtn = Instantiate (prefabBtns [UNDO]) as GameObject;
			UndoBtn.transform.SetParent (this.gameObject.transform);

			DoneBtn = Instantiate (prefabBtns [DONE]) as GameObject;
			DoneBtn.transform.SetParent (this.gameObject.transform);

			currentState = ZROT_STATE;
			
		} else if (vb.CompareTag ("Scaler")) {

			UndoBtn = Instantiate (prefabBtns [UNDO]) as GameObject;
			UndoBtn.transform.SetParent (this.gameObject.transform);

			DoneBtn = Instantiate (prefabBtns [DONE]) as GameObject;
			DoneBtn.transform.SetParent (this.gameObject.transform);

			currentState = SCALE_STATE;


		} else if (vb.CompareTag ("Teleport")) {

			//other behav
			
		} else if (vb.CompareTag ("Cancel")) {

			if (currentState == ZOOM_STATE) {
				
			
			}
			
		}

	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb) {


	}


}

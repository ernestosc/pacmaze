using UnityEngine;
using System.Collections;

public class RotationHandler : MonoBehaviour {


	//script will be attached to rotation Axis btns

	public GameObject player;
	public GameObject pointer;
	float rotateStep = 15;
	bool rotating;
	Vector3 initialRot; //in case of undo
	Vector3 prevRot; //for each frame update
	public static bool aroundXAxis;


	// Use this for initialization
	void Start () {
	
		rotating = false;
		initialRot = player.gameObject.transform.localEulerAngles;

	}
	
	// Update is called once per frame
	void Update () {

		if (rotating) {
		
		
		}
	
	}





}

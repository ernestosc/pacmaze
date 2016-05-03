using UnityEngine;
using System.Collections;

public class PointerHandler : MonoBehaviour {

    public ButtonManager buttonManager;

    // Use this for initialization
    void Start () {
    }

	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Pointer") && buttonManager.currentState == buttonManager.START_STATE)
        {
            (GetComponent("Halo") as Behaviour).enabled = true;
            buttonManager.objSelected = true;
        }
    }

}

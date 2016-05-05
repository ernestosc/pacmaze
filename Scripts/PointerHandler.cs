using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointerHandler : MonoBehaviour {

    public ButtonManager buttonManager;
    public Text winningText;

    // Use this for initialization
    void Start () {
    }

	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter(Collider other) {
        Debug.Log(other);
        if (other.gameObject.CompareTag("Pointer") && buttonManager.currentState == buttonManager.START_STATE)
        {
            (GetComponent("Halo") as Behaviour).enabled = true;
            buttonManager.objSelected = true;
        }

        if (other.gameObject.CompareTag("House"))
        {
            Destroy(other.gameObject);
            Debug.Log("Wrong House!");
        }
        else if (other.gameObject.CompareTag("TargetHouse"))
        {
            winningText.text = "YOU WON!";
			buttonManager.state.text = "Game over";
            Debug.Log("Winner!");
        }
    }

}

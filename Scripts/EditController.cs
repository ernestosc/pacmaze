using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EditController : MonoBehaviour {

    public GameObject avatar;
    public GameObject scalebutton;
    public GameObject rotatebutton;
    private GameObject clone;
    public static bool inMode;
    private Text status;

    // Use this for initialization
    void Start () {
        inMode = false;
        status = this.GetComponentInChildren<Text>();
    }

	// Update is called once per frame
	public void switchMode() {
        if (!inMode)
        {
            status.text = "FINISH";
            scalebutton.SetActive(true);
            //rotatebutton.SetActive(true);
            clone = Instantiate(avatar) as GameObject;
            clone.transform.parent = GameObject.Find("Editor").transform;
            // clone.transform.localPosition = avatar.transform.localPosition;
            // clone.transform.localRotation = avatar.transform.localRotation;
            // clone.transform.localScale = avatar.transform.localScale;
            inMode = true;
        }
        else
        {
            Destroy(clone);
            scalebutton.SetActive(false);
            //rotatebutton.SetActive(false);
            status.text = "TRANSFORM!";
            inMode = false;
        }
    }
}

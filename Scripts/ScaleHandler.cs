using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScaleHandler : MonoBehaviour {

    public GameObject player;
    public GameObject pointer;
    GameObject clone;
    float scale = 0.025f;
    bool scaling;
    Vector3 old;
    private Text status;

    // Use this for initialization
    void Start () {
        scaling = false;
        status = this.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scaling) {
            player.transform.localScale += (pointer.transform.position - old) * scale;
            old = pointer.transform.position;
        }
    }

    public void scaleSwitch() {
        if (EditController.inMode && !scaling)
        {
            status.text = "FINISH";
            scaling = true;
            old = pointer.transform.position;
        }
        else if (EditController.inMode && scaling)
        {
            status.text = "SCALE";
            scaling = false;
        }
    }
}

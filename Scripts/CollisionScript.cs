using UnityEngine;
using System.Collections;

public class CollisionScript : MonoBehaviour {

    int i = 0;
    private Vector3 deltaPos;
    private Vector3 pos;
    public GameObject obj;
    public GameObject pointer;
    bool selected;
    bool following;

    // Use this for initialization
    void Start () {
        selected = false;
        following = false;
        pos = pointer.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (selected)
        {
            following = !following;
            (obj.GetComponent("Halo") as Behaviour).enabled = false;
        }

        deltaPos = pointer.transform.position - pos;
        pos = pointer.transform.position;
        if (following)
        {
            obj.transform.position += deltaPos;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (!following && other.gameObject == pointer)
        {
            selected = true;
            (obj.GetComponent("Halo") as Behaviour).enabled = true;
        }
        else if (other.gameObject != pointer)
        {
            obj.transform.position -= deltaPos;
            following = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == pointer)
        {
            selected = false;
            (obj.GetComponent("Halo") as Behaviour).enabled = false;
        }
    }
}

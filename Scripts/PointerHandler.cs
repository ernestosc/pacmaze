using UnityEngine;
using System.Collections;

public class PointerHandler : MonoBehaviour {

    public Shader shiny;
    Vector3 old;
    float scale = 0.05f;
    Vector3 origin;

    // Use this for initialization
    void Start () {
        origin = transform.position;
    }

	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Pointer"))
        {
            GetComponent<Renderer>().material.shader = shiny;
            old = other.gameObject.transform.position;
        }
    }

    void OnTriggerStay(Collider other)
    {
        // if (other.gameObject.CompareTag("Pointer"))
        // {
        //     GameObject pointer = other.gameObject;
        //     //GetComponent<Rigidbody>().velocity += (pointer.transform.position - old);
        //     // transform.position += (pointer.transform.position - old);
        //     Vector3 move = pointer.transform.position - old;
        //     //GetComponent<Rigidbody>().MovePosition(transform.position + move);
        //     //GetComponent<Rigidbody>().AddForce(move*scale);
        //     GetComponent<Rigidbody>().MovePosition(transform.position + GetMaxDirection(move));
        //     old = pointer.transform.position;
        // }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Pointer")) {
            GetComponent<Renderer>().material.shader = Shader.Find("Standard");
        }

        // if (other.gameObject.CompareTag("Maze")) {
        //     transform.position += (origin - transform.position) * 0.1f;
        // }
    }

    Vector3 GetMaxDirection(Vector3 a)
    {
        float max = Mathf.Max(Mathf.Abs(a.x), Mathf.Max(Mathf.Abs(a.y), Mathf.Abs(a.z)));
        Vector3 dir = (Mathf.Abs(a.x) == max) ? Vector3.right : (Mathf.Abs(a.y) == max) ? Vector3.up : Vector3.forward;
        float val = (Mathf.Abs(a.x) == max) ? a.x : (Mathf.Abs(a.y) == max) ? a.y : a.z;
        return dir * val;
    }
}

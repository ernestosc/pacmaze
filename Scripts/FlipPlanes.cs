using UnityEngine;
using System.Collections;

public class FlipPlanes : MonoBehaviour {

    GameObject clone;
    public Material transparent;

    void Start() { }

    void Awake()
    {
        Debug.Log(transform.childCount);
        for (int i = 0; i < transform.childCount; i++) {

            Transform plane = transform.GetChild(i);
            if (!plane.gameObject.CompareTag("Player"))
            {
                Debug.Log(plane);
                /*clone = Instantiate(plane.gameObject, plane.gameObject.transform.position, plane.gameObject.transform.rotation) as GameObject;
                clone.transform.parent = this.transform;
                Vector3 size = plane.gameObject.GetComponent<BoxCollider>().bounds.size;
                if (size.y == 0f) clone.transform.Rotate(180, 0, 0);
                else clone.transform.Rotate(0, 180, 0);
                clone.GetComponent<Renderer>().material = transparent;*/
            }
        }
    }

    // Update is called once per frame
    void Update () {

	}
}

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneHandler : MonoBehaviour {

    public int nextScene;
    // Use this for initialization
    void Start () {

	}

	// Update is called once per frame
	void Update () {

    }

    public void switchScene() {
        SceneManager.LoadScene(nextScene);
    }
}

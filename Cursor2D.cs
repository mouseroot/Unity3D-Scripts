using UnityEngine;
using System.Collections;

public class Cursor2D : MonoBehaviour {

    private Ray ray;
    private Vector3 origin;
    private Vector3 currentPosition;

    public Texture2D cursorGraphic;
    public bool showMouse = true;
	// Use this for initialization
	void Start () {
        Screen.showCursor = showMouse;
        transform.gameObject.renderer.material.mainTexture = cursorGraphic;
	}
	
	// Update is called once per frame
	void Update () {
        currentPosition = transform.position;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        origin = ray.origin;
        currentPosition.x = origin.x;
        currentPosition.y = origin.y;
        transform.position = currentPosition;
	}
}

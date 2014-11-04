using UnityEngine;
using System.Collections;

public class CircleController : MonoBehaviour {

	private GameObject circle;
	private GameObject number;
	private int sizeCount = 0;
	private const float boudary_x = 8.448984f;
	private const float boudary_z = 4.50f;
	private const float scaleIncrement = 0.05f;
	private Vector3 originalSize;

	// Use this for initialization
	void Start () {
		circle = transform.Find("Circle").gameObject;
		number = transform.Find("Number").gameObject;
		originalSize = circle.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("right")) {
			transform.Translate(new Vector3(10 * Time.deltaTime, 0, 0));
		}
		if(Input.GetKey("left")) {
			transform.Translate(new Vector3(-10 * Time.deltaTime, 0, 0));
		}
		if(Input.GetKey("up")) {
			transform.Translate(new Vector3(0, 0, 10 * Time.deltaTime));
		}
		if(Input.GetKey("down")) {
			transform.Translate(new Vector3(0, 0, -10 * Time.deltaTime));
		}
		Vector3 pos = transform.position;
		pos.x = Mathf.Clamp(pos.x, -boudary_x, boudary_x);
	 	pos.z = Mathf.Clamp(pos.z, -boudary_z, boudary_z);
	 	pos.y = 0;
	 	transform.position = pos;

	 	if(Input.GetKey("space")) {
	 		Vector3 scale = circle.transform.localScale;
	 		scale.x += scaleIncrement;
	 		scale.z += scaleIncrement;
			circle.transform.localScale = scale;
			setSizeCount(++sizeCount);
		}
		if(sizeCount == 100){

		} else if(sizeCount > 100){
			setSizeCount(0);
			circle.transform.localScale = originalSize;
		}
	}

	void setSizeCount(int size){
		sizeCount = size;
		number.GetComponent<TextMesh>().text = "" + sizeCount;
	}

}

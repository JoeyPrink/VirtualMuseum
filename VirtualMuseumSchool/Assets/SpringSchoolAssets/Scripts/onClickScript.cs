using UnityEngine;
using System.Collections;

public class onClickScript : MonoBehaviour {
	
	bool isClicked = false;
	public Texture infoTexture;
	public int x_position = 0;	
	public int y_position = 0;	
	public int width = 400;	
	public int height = 600;	

	private bool GUIdrawn = false;
	private int toggle = 1;
	private bool show = false;
	private bool inArea = false;

	void Start () {
		isClicked = false;
	}

	void Update() {
		if(Input.GetMouseButtonDown(0)){
			toggle = (toggle + 1)%2;
			if(inArea){
				if(toggle == 0) {
					show = false;
				}
				else show = true;
			}
		}
	}

	void OnTriggerEnter(Collider col){
		 inArea = true;
		 toggle = (toggle + 1)%2;

		 show = true;
		playAudio ();
	}
	void OnTriggerExit(Collider col){
		inArea = false;
		toggle = 1;
		Debug.Log ("bla" + toggle);
		show = false;
	}
	
	void OnGUI() {
		if (!infoTexture) {
			Debug.LogError ("Assign a Texture in the inspector.");
			return;
		}
		if (show) {
			GUI.DrawTexture (new Rect (x_position, y_position, width, height), infoTexture, ScaleMode.ScaleToFit, true, 0);
			GUIdrawn = true;
		}
	}

	void playAudio(){

			Debug.Log ("playyy");
			audio.Play();
	}

}

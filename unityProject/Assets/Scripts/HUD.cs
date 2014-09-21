using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	public Renderer life; 
	public Renderer energy;

	public TextMesh broadcast;
	public TextMesh infoText;
	// Use this for initialization
	void Start () {
		//life1 = life.GetComponent<Renderer> ();
		//broadcast.text = "Ending\ntransmision\nclosing system...";
		infoText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		//lifeValue = GameController.Health;
		life.material.SetTextureOffset ("_MainTex", new Vector2(0f,-GameController.Health * 0.5f));
		energy.material.SetTextureOffset ("_MainTex", new Vector2(0,GameController.Energy * 0.5f));

		if (GameController.Health == 0){
			broadcast.text = "";
			infoText.text = "Ending\ntransmision\nclosing system...";
		}
		
	}
}

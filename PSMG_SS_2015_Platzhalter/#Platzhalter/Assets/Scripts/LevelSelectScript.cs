using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSelectScript : MonoBehaviour {
	private int selection;
	public Image selector;
	private bool m_isAxisInUse=false;
	// Use this for initialization
	void Start () {
		selection = 1;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void FixedUpdate(){
		if (Input.GetAxisRaw ("Horizontal") != 0) {
			if (m_isAxisInUse == false) {
				float axis = Input.GetAxis ("Horizontal");
				if (axis > 0) {
					if (selection == 1) {
						selection++;
						checkSelection ();
					}
				} else if (axis < 0) {
					if (selection == 2) {
						selection--;
						checkSelection ();
					}
				}
				m_isAxisInUse = true;
			}
		}
		if (Input.GetAxisRaw ("Horizontal") == 0) {
			m_isAxisInUse = false;
		}  
		
		
		if (Input.GetButtonDown ("Submit")) {

			if (selection == 1) {
				Application.LoadLevel ("Level 1");
			} else if (selection == 2) {
				Application.LoadLevel("Level 2");

			}
		}
	}
		private void checkSelection(){
			switch (selection) {
			case 1:
				selector.rectTransform.anchoredPosition=  new Vector2(-490,230);
				break;
			case 2:
				selector.rectTransform.anchoredPosition= new Vector2(0,170);

				break;

			}
			
		}
}

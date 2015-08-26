using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleScreenScript : MonoBehaviour {

	private int selection;
	public Image selector;
	private bool m_isAxisInUse=false;
	// Use this for initialization
	void Start () {
		selection = 1;
		checkSelection ();
	}
	
	// Update is called once per frame
	void Update () {


	}
	void FixedUpdate(){
		if( Input.GetAxisRaw("Vertical") != 0)
		{
			if(m_isAxisInUse == false)
			{
				float axis = Input.GetAxis ("Vertical");
		if (axis < 0) {
			if(selection<3){
				selection++;
				checkSelection();
				Debug.Log ("selectiondown");
				StartCoroutine (wait ());
			}
		} else if (axis > 0) {
			if(selection>1){
				selection--;
				checkSelection();
				Debug.Log ("selectionup");
				StartCoroutine (wait ());
			}
		}
				m_isAxisInUse = true;
			}
		}
		if( Input.GetAxisRaw("Vertical") == 0)
		{
			m_isAxisInUse = false;
		}  


		if (Input.GetButtonDown ("Submit")||Input.GetButtonDown("Fire1")||Input.GetButtonDown("Jump")) {

			if(selection==1){
				Application.LoadLevel ("Level 1");
			}
		}
	}
	private void checkSelection(){
		switch (selection) {
		case 1:
			selector.rectTransform.anchoredPosition=  new Vector2(-460,60);
			Debug.Log ("selection1");
			break;
		case 2:
			selector.rectTransform.anchoredPosition= new Vector2(-460,-160);
			Debug.Log ("selection2");
			break;
		case 3:
			selector.rectTransform.anchoredPosition=new Vector2 (-460,-360);
			Debug.Log ("selection3");
			break;
		}

	}
	IEnumerator wait(){
		yield return new WaitForSeconds(1);
	}
}

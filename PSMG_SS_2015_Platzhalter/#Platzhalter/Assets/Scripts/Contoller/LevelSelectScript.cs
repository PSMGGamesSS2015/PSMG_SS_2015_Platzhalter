using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSelectScript : MonoBehaviour {
	private int selection;
	public Image selector;
	private bool m_isAxisInUse=false;
	private GameObject gamemaster;
	// Use this for initialization
	void Start () {
		gamemaster = GameObject.Find ("_GM");
		selection = 1;
		checkSelection ();
		Destroy (GameObject.Find ("PlayerLifes").gameObject);
		if (gamemaster.GetComponent<LevelCheck> ().levelTwoDone == true) {
			GameObject.Find ("lockLevel3").GetComponent<Image>().enabled=false;
		}
		if (gamemaster.GetComponent<LevelCheck> ().levelThreeDone == true) {
			GameObject.Find ("lockLevel4").GetComponent<Image>().enabled=false;
		}
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
					} else if(selection ==2 && gamemaster.GetComponent<LevelCheck>().levelTwoDone==true){
						selection++;
						checkSelection ();
					}else if(selection ==3&& gamemaster.GetComponent<LevelCheck>().levelThreeDone==true){
						selection++;
						checkSelection ();
					}
				} else if (axis < 0) {
					if (selection == 2) {
						selection--;
						checkSelection ();
					}
					else if(selection==3){
						selection--;
						checkSelection ();
					}
					else if(selection==4){
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
		
		
		if (Input.GetButtonDown ("Submit")||Input.GetButtonDown("Fire1")||Input.GetButtonDown("Jump")) {

			if (selection == 1) {
				Application.LoadLevel ("Level 1");
			} else if (selection == 2) {
				Application.LoadLevel("Level 2");
			}else if (selection == 3) {
				Application.LoadLevel("Level 3");
			}else if (selection == 4) {
				Application.LoadLevel("Level 4");
			}
		}
	}
		private void checkSelection(){
			switch (selection) {
			case 1:
				selector.rectTransform.anchoredPosition=  new Vector2(-560,78);
				break;
			case 2:
				selector.rectTransform.anchoredPosition= new Vector2(-2,174);
				break;
			case 3:
				selector.rectTransform.anchoredPosition= new Vector2(579,78);
				break;
			case 4:
				selector.rectTransform.anchoredPosition = new Vector2(579,-353);
			break;
		}
			
		}
}

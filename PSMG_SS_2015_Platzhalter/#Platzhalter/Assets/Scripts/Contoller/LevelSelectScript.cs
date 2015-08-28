using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSelectScript : MonoBehaviour {

	private int selection;
	public Image cursor;
	private bool m_isAxisInUse=false;
	private GameObject gamemaster;


	void Start () {
		gamemaster = GameObject.Find ("_GM");
		selection = 1;
		checkSelection ();
		Destroy (GameObject.Find ("PlayerLifes").gameObject);
		unlockLevels ();
	}

	/*
	 * this method is for checking if the player can visit the third and fourth level, and unlocks the lock accordingly
	 */

	void unlockLevels(){
		if (gamemaster.GetComponent<LevelCheck> ().levelTwoDone == true) {
			GameObject.Find ("lockLevel3").GetComponent<Image>().enabled=false;
		}
		if (gamemaster.GetComponent<LevelCheck> ().levelThreeDone == true) {
			GameObject.Find ("lockLevel4").GetComponent<Image>().enabled=false;
		}
	}
	/*
	 * In here the Input of the player is checked, checks if the corresponding level has been unlocked yet, and changes the selection accordingly
	 */
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
		/*
	 	* method to check which level has been selected. then puts the cursor to the anchorpoint of that level.
	 	*/
		private void checkSelection(){
			switch (selection) {
			case 1:
				cursor.rectTransform.anchoredPosition=  new Vector2(-560,78);
				break;
			case 2:
				cursor.rectTransform.anchoredPosition= new Vector2(-2,174);
				break;
			case 3:
				cursor.rectTransform.anchoredPosition= new Vector2(579,78);
				break;
			case 4:
				cursor.rectTransform.anchoredPosition = new Vector2(579,-353);
			break;
		}
			
		}
}

﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

	public Image W1_A,W1_IA,W2_A,W2_IA,W2_L,W3_A,W3_IA,W3_L,W4_A,W4_IA,W4_L;
	public Image L_3,L_2,L_1;
	public Image LB_1,LB_2,LB_3,LB_4,LB_5;
	public Image P_BG,P_T;

	void Start () {
		setupWeapons ();
		setupLife ();
		setupLifebar ();
		setupPause ();
	}
	
	void Update () {
	
	}
	private void setupPause(){
		P_BG = GameObject.Find ("PauseBG").GetComponent<Image>();
		P_T = GameObject.Find ("PauseText").GetComponent<Image>();
		P_T.enabled = false;
		P_BG.enabled = false;
	}
	private void setupWeapons(){
		W1_A.enabled = true;
		W1_IA.enabled = false;
		W2_A.enabled = false;
		W2_IA.enabled = true;
		W2_L.enabled = false;
		W3_A.enabled = false;
		W3_IA.enabled = false;
		W3_L.enabled = true;
		W4_A.enabled = false;
		W4_IA.enabled = false;
		W4_L.enabled = true;
	}

	private void setupLife(){
		L_3.enabled = true;
		L_2.enabled = false;
		L_1.enabled = false;
	}

	private void setupLifebar(){
		LB_1.enabled = true;
		LB_2.enabled = true;
		LB_3.enabled = true;
		LB_4.enabled = true;
		LB_5.enabled = true;


	}
	public void switch_w1_w2(){
		W1_A.enabled = false;
		W1_IA.enabled = true;
		W2_A.enabled = true;
		W2_IA.enabled = false;
	}

	public void switch_w2_w3(){
		W2_A.enabled = false;
		W2_IA.enabled = true;
		W3_A.enabled = true;
		W3_IA.enabled = false;
	}
	public void switch_w3_w4(){
		W3_A.enabled = false;
		W3_IA.enabled = true;
		W4_A.enabled = true;
		W4_IA.enabled = false;
	}
	public void switch_w4_w1(){
		W4_A.enabled = false;
		W4_IA.enabled = true;
		W1_A.enabled = true;
		W1_IA.enabled = false;
	}
	public void switch_w1_w4(){
		W1_A.enabled = false;
		W1_IA.enabled = true;
		W4_A.enabled = true;
		W4_IA.enabled = false;
	}
	public void switch_w4_w3(){
		W4_A.enabled = false;
		W4_IA.enabled = true;
		W3_A.enabled = true;
		W4_IA.enabled = false;
	}
	public void switch_w3_w2(){
		W3_A.enabled = false;
		W3_IA.enabled = true;
		W2_A.enabled = true;
		W2_IA.enabled = false;
	}
	public void switch_w3_w1(){
		W3_A.enabled = false;
		W3_IA.enabled = true;
		W1_A.enabled = true;
		W1_IA.enabled = false;
	}
	public void switch_w2_w1(){
		W2_A.enabled = false;
		W2_IA.enabled = true;
		W1_A.enabled = true;
		W1_IA.enabled = false;
	}
	public void unlock_w2(){
		W2_L.enabled = false;
		W2_IA.enabled = true;
	}
	public void unlock_w3(){
		W3_L.enabled = false;
		W3_IA.enabled = true;
	}
	public void unlock_w4(){
		W4_L.enabled = false;
		W4_IA.enabled = true;
	}
	public void update_life(int health){
		if (health == 100) {
			LB_1.enabled = true;
			LB_2.enabled = true;
			LB_3.enabled = true;
			LB_4.enabled = true;
			LB_5.enabled = true;
		}
		else if (health == 80) {
			LB_1.enabled = true;
			LB_2.enabled = true;
			LB_3.enabled = true;
			LB_4.enabled = true;
			LB_5.enabled = false;
		}
		else if (health == 60) {
			LB_1.enabled = true;
			LB_2.enabled = true;
			LB_3.enabled = true;
			LB_4.enabled = false;
			LB_5.enabled = false;
		}
		else if (health == 40) {
			LB_1.enabled = true;
			LB_2.enabled = true;
			LB_3.enabled = false;
			LB_4.enabled = false;
			LB_5.enabled = false;
		}
		else if (health == 20) {
			LB_1.enabled = true;
			LB_2.enabled = false;
			LB_3.enabled = false;
			LB_4.enabled = false;
			LB_5.enabled = false;
		}
		else if (health == 0) {
			LB_1.enabled = false;
			LB_2.enabled = false;
			LB_3.enabled = false;
			LB_4.enabled = false;
			LB_5.enabled = false;
		}
	}

		public void update_lifes(int lifes){
			if(lifes==3){
				L_3.enabled = true;
				L_2.enabled = false;
				L_1.enabled = false;
			}
			else if(lifes==2){
				L_3.enabled = false;
				L_2.enabled = true;
				L_1.enabled = false;
			}
			else if(lifes==1){
				L_3.enabled = false;
				L_2.enabled = false;
				L_1.enabled = true;
			}
		}
	public void togglePause(){
		P_BG.enabled = !P_BG.enabled;
		P_T.enabled = !P_T.enabled;
	}

		
	}

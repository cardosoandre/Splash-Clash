﻿#pragma strict

using UnityEngine;
using System.Collections;

public class startScreenControl : MonoBehaviour {

	
	// Array of menu item control names.
	var menuOptions = new String[4];
	menuOptions[0] = "4start";
	menuOptions[1] = "Instructions";
	menuOptions[2] = "Options";
	menuOptions[3] = "Credits";
	
	// Default selected menu item (in this case, Tutorial).
	var selectedIndex = 0;
	
	
	// Function to scroll through possible menu items array, looping back to start/end depending on direction of movement.
	void menuSelection (menuItems, selectedItem, direction) {
		if (direction == "up") {
			if (selectedItem == 0) {
				selectedItem = menuItems.length - 1;
			} else {
				selectedItem -= 1;
			}
		}
		
		if (direction == "down") {
			if (selectedItem == menuItems.length - 1) {
				selectedItem = 0;
			} else {
				selectedItem += 1;
			}
		}
		
		return selectedItem;
	}
	
	void Update ()
	{
		if ([key press down arrow]) {
			selectedIndex = menuSelection(menuOptions, selectedIndex, "down");
		}
		
		if ([key press up arrow]) {
			selectedIndex = menuSelection(menuOptions, selectedIndex, "up");
		}
	}
	
	function OnGUI ()
	{
		GUI.SetNextControlName ("Tutorial");
		if (GUI.Button(Rect(10,70,50,30), "View Tutorial")) {
			//Do tutorial stuff.
		}
		
		GUI.SetNextControlName ("Play");
		if (GUI.Button(Rect(10,100,50,30), "Play Game")) {
			//Do game stuff.
		}
		
		GUI.SetNextControlName ("High Scores");
		if (GUI.Button(Rect(10,130,50,30), "High Scores")) {
			//Do high score stuff.
		}
		
		GUI.SetNextControlName ("Exit");
		if (GUI.Button(Rect(10,160,50,30), "Exit")) {
			//Do quit stuff.
		}
		
		GUI.FocusControl (menuOptions[selectedIndex]);
	}
}

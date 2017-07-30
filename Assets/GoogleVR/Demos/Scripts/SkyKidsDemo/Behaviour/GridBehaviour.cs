using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridBehaviour : MonoBehaviour {

	GameObject[] gridButtons;
	public GameObject selectedProductPanel;

	// Use this for initialization
	void Start () {
	}

	void OnEnable()
	{
		Debug.Log ("GRID BEHAVIOUR ENABLED WAS CALLED");
		gridButtons = GameObject.FindGameObjectsWithTag ("productButton");
		Debug.Log ("length from enable: " +gridButtons.Length);
		foreach(GameObject gridButtonObject in gridButtons){

			string parentName = gridButtonObject.transform.parent.name;
			Debug.Log ("ParentName:  " + parentName);
			Button gridButton = gridButtonObject.GetComponent<UnityEngine.UI.Button>();

			gridButton.onClick.AddListener(delegate { setSelectedItem(parentName); });

		}
	}


	public void setSelectedItem(string parentName){
		Debug.Log ("Set selected item called!!!!!");
		selectedProductPanel.SetActive (true);
		GameObject selectedName = GameObject.Find ("selectedProductText");
		Text selectedNameText = selectedName.GetComponent<UnityEngine.UI.Text> ();
		selectedNameText.text = parentName;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

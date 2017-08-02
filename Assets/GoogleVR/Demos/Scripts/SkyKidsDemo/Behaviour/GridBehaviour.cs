﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AssemblyCSharp;

public class GridBehaviour : MonoBehaviour {

	GameObject[] gridButtons;
	public GameObject selectedProductPanel;
	public static Dictionary<string, Product> productData = new Dictionary<string, Product>()
	{
		{ "Blossom", new Product(1,3.00, "Blossom")},
		{ "Bubbles", new Product(2,2.99, "Bubbles")},
		{ "Buttercup", new Product(3,5.99, "Buttercup")},
		{ "Buzz", new Product(4,4.99, "Buzz")},
		{ "Dora", new Product(5,7.99, "Dora")},
		{ "Kion", new Product(6,2.99, "Kion")},
		{ "Olaf", new Product(7,4.99, "Olaf")},
		{ "Pawpatrol", new Product(8,1.99, "Pawpatrol")},
		{ "Peppa", new Product(9,4.99, "Peppa")},
		{ "Po", new Product(10,5.99, "Po")},
		{ "Sofia", new Product(11,2.99, "Sofia")},
		{ "Walle", new Product(12,5.99, "Walle")}
	};

	public static Product currentSelectedProduct;
	public GameObject debugger; 
	public GameObject walle;
	public GameObject defaultModel;

	// Use this for initialization
	void Start () {
	}

	void OnEnable()
	{
		//Debug.Log ("GRID BEHAVIOUR ENABLED WAS CALLED");
		gridButtons = GameObject.FindGameObjectsWithTag ("productButton");

		//Debug.Log ("length from enable: " +gridButtons.Length);
		foreach(GameObject gridButtonObject in gridButtons){

			string parentName = gridButtonObject.transform.parent.name;
			//Debug.Log ("ParentName:  " + parentName);
			Button gridButton = gridButtonObject.GetComponent<UnityEngine.UI.Button>();

			gridButton.onClick.AddListener(delegate { setSelectedItem(parentName); });
		}
		Button btn = GameObject.Find("AddButton").GetComponent<Button>();
		btn.onClick.AddListener(delegate { Debug.Log("ACTION LISTENER ADDED : ID " + currentSelectedProduct.id);Basket.addToBasket(currentSelectedProduct.id);});
	}


	public void setSelectedItem(string parentName){
		Debug.Log ("Set selected item called!!!!!");
		selectedProductPanel.SetActive (true);

		GameObject selectedName = GameObject.Find ("selectedProductText");
		Text selectedNameText = selectedName.GetComponent<UnityEngine.UI.Text> ();
		productData.TryGetValue (parentName, out currentSelectedProduct);
		selectedNameText.text = parentName + " : Price : £" + currentSelectedProduct.price;

		if (parentName == "Walle") {
			walle.SetActive (true);
			defaultModel.SetActive (false);
		} else {
			walle.SetActive (false);
			defaultModel.SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AssemblyCSharp;

public class GridBehaviour : MonoBehaviour {

	GameObject[] gridButtons;
	public GameObject selectedProductPanel;
	public static Dictionary<string, Product> productData = new Dictionary<string, Product>()
	{
		{ "Blossom", new Product(1,3.00)},
		{ "Bubbles", new Product(2,2.99)},
		{ "Buttercup", new Product(3,5.99)},
		{ "Buzz", new Product(4,4.99)},
		{ "Dora", new Product(5,7.99)},
		{ "Kion", new Product(6,2.99)},
		{ "Olaf", new Product(7,4.99)},
		{ "Pawpatrol", new Product(8,1.99)},
		{ "Peppa", new Product(9,4.99)},
		{ "Po", new Product(10,5.99)},
		{ "Sofia", new Product(11,2.99)},
		{ "Walle", new Product(12,5.99)}
	};

	public static Product currentSelectedProduct;

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
	}


	public void setSelectedItem(string parentName){
		Debug.Log ("Set selected item called!!!!!");
		selectedProductPanel.SetActive (true);

		Button btn = GameObject.Find("AddButton").GetComponent<Button>();
		btn.onClick.AddListener(delegate { Basket.addToBasket(currentSelectedProduct.id);});

		GameObject selectedName = GameObject.Find ("selectedProductText");
		Text selectedNameText = selectedName.GetComponent<UnityEngine.UI.Text> ();
		productData.TryGetValue (parentName, out currentSelectedProduct);
		selectedNameText.text = parentName + " : Price : £" + currentSelectedProduct.price;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

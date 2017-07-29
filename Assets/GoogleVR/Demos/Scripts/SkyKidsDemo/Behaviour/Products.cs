using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AssemblyCSharp;

public class Products : MonoBehaviour {

	Button productsButton;
	IProductsWebAPI productsAPi;
	List<Product> products;

	public GameObject selectedProductPanel;
	public GameObject mainPanel;
	public GameObject productsGrid; 

	// Use this for initialization
	void Start () {
		productsAPi = new ProductsWebAPI ();
		selectedProductPanel.SetActive (false);
		productsGrid.SetActive (false);

		productsButton = GameObject.Find("ViewProductsButton").GetComponent<UnityEngine.UI.Button>();
		productsButton.onClick.AddListener(generateProductsList);
	}

	private void generateProductsList(){
		productsGrid.SetActive (true);
		mainPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

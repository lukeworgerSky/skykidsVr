using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AssemblyCSharp;

public class Products : MonoBehaviour {

	Button productsButton;
	IProductsWebAPI productsAPi;
	List<Product> products;

	public GameObject productPanelTemplate;
	public GameObject productPanelShowing;
	public GameObject productsMainPanel; 

	// Use this for initialization
	void Start () {
		productsAPi = new ProductsWebAPI ();
		productPanelShowing.SetActive (false);
		productsButton = GameObject.Find("ViewProductsButton").GetComponent<UnityEngine.UI.Button>();
		productsButton.onClick.AddListener(generateProductsList);
	}
		
	public void showProducts(){
		//getProducts ();
		generateProductsList ();
	}

	private void getProducts(){
		//products = productsAPi.getProducts (); 
	}

	private void generateProductsList(){
		productsMainPanel = GameObject.Find ("ProductsMainPanel");
		productPanelShowing.SetActive (true);
		productsMainPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

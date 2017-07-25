using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AssemblyCSharp;

public class Products : MonoBehaviour {

	Button productsButton;
	IProductsWebAPI productsAPi;
	List<Product> products;
	GameObject productsPanelShowing;

	public int columnNumber = 10; // number of columns for the grid
	public int rowNumber = 10; // number of rows for the grid
	public float gapXValue = 0.0f; // Distance between each column
	public float gapZValue = 0.0f; // Distance between each Row


	private float tempSeperationX = 0; // used to calculate the separation between each column
	private float tempSeperationZ = 0;// used to calculate the separation between each row

	// Use this for initialization
	void Start () {
		productsPanelShowing = GameObject.Find ("ProductsPanelShowing");
		productsPanelShowing.SetActive (false);
		productsAPi = new ProductsWebAPI ();

		productsButton = GameObject.Find("ViewProductsButton").GetComponent<UnityEngine.UI.Button>();
		productsButton.onClick.AddListener(showProducts);
	}
		
	public void showProducts(){
		hideMainMenu ();
		getProducts ();
		generateProductsList ();
	}

	private void hideMainMenu(){
		GameObject productsMainPanel = GameObject.Find ("ProductsMainPanel");
		productsMainPanel.SetActive (false);

		productsPanelShowing.SetActive (true);
	}

	private void getProducts(){
		//products = productsAPi.getProducts ();
	}

	private void generateProductsList(){
		//Image i = panel.AddComponent<Image>();
		//i.color = Color.red;
		//panel.transform.SetParent(newCanvas.transform, false);
		/*for (int i = 0; i < columnNumber; i++) {//loop 1 to loop through columns
			for (int j = 0; j < rowNumber; j++) {//loop 2 to loop through rows
				GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Quad); //create a quad primitive as provided by unity
				plane.transform.position = new Vector3(i+tempSeperationX, 0,j+tempSeperationZ); //position the newly created quad accordingly
				plane.transform.eulerAngles = new Vector3 (90f,0,0); //rotate the quads 90 degrees in X to face up
				tempSeperationZ += gapXValue;//change the value of seperation between rows
			}
			tempSeperationX += gapXValue;//change the value of seperation between columns
			tempSeperationZ = 0;//Reset the value of the seperation between the rows so it won‘t cumulate
		}*/
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

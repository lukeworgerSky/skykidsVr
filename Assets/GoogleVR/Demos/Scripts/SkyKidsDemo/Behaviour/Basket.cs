using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;
using System.Linq;
using UnityEngine.UI;

public class Basket : MonoBehaviour {

	private static Dictionary<int,int> basketValues = new Dictionary<int, int>();
	private static double total;
	public static GameObject totalTextObject;

	public static GameObject selectedBasketItem;
	private static List<GameObject> basketItemsObjects = new List<GameObject>();
	public static GameObject basketGrid;
	public static GameObject itemPrefab;

	// Use this for initialization
	void Start () {
		basketGrid = GameObject.Find ("BasketGrid");
		itemPrefab = GameObject.Find ("selectedProductText");
		itemPrefab = (GameObject)Resources.Load("prefabs/basketItem", typeof(GameObject));
		totalTextObject = GameObject.Find ("TotalValue");
	}

	public static void addToBasket(int id){
		int basketValue;

		basketValues.TryGetValue(id, out basketValue); 
		basketValues[id] = basketValue + 1;
		addItemToGrid (id, basketValues[id]);
		updateView ();
	}

	private static void calculateTotal(){
		total = 0.0;
		foreach(KeyValuePair<int, int> basketValue in basketValues)
		{
			Product price = GridBehaviour.productData.Values.FirstOrDefault(prod => prod.id == basketValue.Key);
			if (price != null) {
				total += (basketValue.Value * price.price);
			}
		}
	}

	private static void updateView(){
		calculateTotal ();
		Text totalText = totalTextObject.GetComponent<Text>();
		totalText.text = "" + total;
		Debug.Log ("TOTAL RIGHT NOW: " + total);
	}

	private static void addItemToGrid(int id, int basketValue){
		Debug.Log ("GOT TO ADDING ITEM TO GRID:   BASKETVALUE : " + basketValue);
		Product productToAdd = GridBehaviour.productData.Values.FirstOrDefault(prod => prod.id == id);
		GameObject newItem = Instantiate(itemPrefab) as GameObject;
		Text[] newTextItems = newItem.GetComponents<Text> ();
		if (newTextItems.Length > 0) {
			newTextItems [0].text = productToAdd.name;
			newTextItems [1].text = "" + basketValue;
		}

		newItem.transform.SetParent(basketGrid.transform, false);
		Debug.Log ("ITEM HOPEFULLY ADDED WITH NEW BASKET VALUE");
	}

	// Update is called once per frame
	void Update () {
		
	}
}

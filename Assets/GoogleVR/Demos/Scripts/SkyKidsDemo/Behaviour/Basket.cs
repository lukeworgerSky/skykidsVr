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
	private static IBasketWebAPI basketApi;

	public static GameObject selectedBasketItem;
	public static GameObject basketGrid;
	public static GameObject itemPrefab;

	// Use this for initialization
	void Start () {
		basketGrid = GameObject.Find ("BasketGrid");
		itemPrefab = GameObject.Find ("selectedProductText");
		itemPrefab = (GameObject)Resources.Load("prefabs/basketItem", typeof(GameObject));
		basketApi = (new GameObject("SomeObjName")).AddComponent<BasketWebAPI>();
		totalTextObject = GameObject.Find ("TotalValue");
		Button clearBtn = GameObject.Find("ClearButton").GetComponent<Button>();
		clearBtn.onClick.AddListener(resetBasket);

		Button purchaseBtn = GameObject.Find("PurchaseButton").GetComponent<Button>();
		purchaseBtn.onClick.AddListener(delegate{basketApi.sendOrder(basketValues);});
	}

	public static void addToBasket(int id){
		Debug.Log ("Called addtobasket with : " + id);
		if (basketGrid.transform.childCount < 8) {
			int basketValue;

			basketValues.TryGetValue (id, out basketValue); 
			basketValues [id] = basketValue + 1;
			addItemToGrid (id, basketValues [id]);
			updateView ();
		}
	}

	private static void resetBasket(){
		basketValues.Clear ();
		updateView ();
		foreach (Transform child in basketGrid.transform) {
			GameObject.Destroy (child.gameObject);
		}
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
		foreach (Transform child in basketGrid.transform) {
			if (child.name == id + "item") {
				Transform quantity = child.transform.Find ("Quantity");
				Text quantityText = quantity.GetComponent<Text> ();
				quantityText.text = basketValue.ToString();

				//If found to update then return out.
				return;
			}
		}
			GameObject newItem = Instantiate (itemPrefab) as GameObject;
			newItem.name = id + "item";

			Transform itemName = newItem.transform.Find ("ItemName");
			Text itemNameText = itemName.GetComponent<Text> ();
			itemNameText.text = productToAdd.name;

			Transform quantityName = newItem.transform.Find ("Quantity");
			Text quantityNameText = quantityName.GetComponent<Text> ();
			quantityNameText.text = basketValue.ToString();


			newItem.transform.SetParent (basketGrid.transform, false);
			Debug.Log ("ITEM HOPEFULLY ADDED WITH NEW BASKET VALUE");
	}

	// Update is called once per frame
	void Update () {
		
	}
}

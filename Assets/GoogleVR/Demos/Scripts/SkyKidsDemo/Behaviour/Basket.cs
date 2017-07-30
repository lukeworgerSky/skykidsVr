using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;
using System.Linq;
using UnityEngine.UI;

public class Basket : MonoBehaviour {

	private static Dictionary<int,int> basketValues = new Dictionary<int, int>();
	private static double total;

	// Use this for initialization
	void Start () {
	}

	public static void addToBasket(int id){
		Debug.Log ("ADDED ITEM TO BASKET");
		int basketValue;

		basketValues.TryGetValue(id, out basketValue); 
		basketValues[id] = basketValue + 1;
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
		Debug.Log ("TOTAL RIGHT NOW: " + total);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

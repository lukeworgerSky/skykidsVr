﻿using System;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using System.Collections;

namespace AssemblyCSharp
{
	public class BasketWebAPI: MonoBehaviour, IBasketWebAPI
	{
		void Start(){
		}

		public void sendOrder(Dictionary<int,int> productsToBuy){
			string formDataString = "";
			foreach(KeyValuePair<int, int> basketValue in productsToBuy)
			{
				formDataString += basketValue.Key + "=" + basketValue.Value + "&";

			}
			formDataString = formDataString.Substring (0, formDataString.Length - 1);
			StartCoroutine(Upload (formDataString));
		}

		IEnumerator Upload(string formDataString){
			WWWForm formData = new WWWForm ();
			formData.AddField("data",formDataString);
			UnityWebRequest www = UnityWebRequest.Post ("http://192.168.43.43:3000/vr", formData);
			yield return www.Send ();

			if (www.isNetworkError) {
				Debug.Log (www.error);
			}
			else {
				Debug.Log ("OK");
			}
		}
	}
}


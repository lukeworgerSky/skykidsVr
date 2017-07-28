using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicallyAddPanel : MonoBehaviour {

	public GameObject panelToSpawn;

	float width, height, leftLimit, rightLimit, upperLimit, totalHeight;
	float gridSize;
	float pixelPadding_side;
	float pixelPadding_top;
	Vector2 size, canvasPos, panelPos;

	public List<Data> dataList = new List<Data>();

	public List<string> titleList = new List<string>();
	public List<Sprite> imgList = new List<Sprite>();
	public List<GameObject> objList = new List<GameObject>();

	// Use this for initialization
	void Start () {

		//Init data list from public vars for now - read data from file and store in data list here
		for (int i = 0; i < titleList.Count; i++) {
			
			Data d = new Data (imgList[i], titleList[i], objList[i]);
			dataList.Add (d);
		}

		//Init variable values at run time
		size = this.GetComponent<RectTransform> ().sizeDelta;
		canvasPos = this.GetComponent<RectTransform> ().anchoredPosition;
		width = size.x;
		height = size.y;

		gridSize = panelToSpawn.GetComponent<RectTransform> ().sizeDelta.x + 25;

		Debug.Log ("Grid Size: " + gridSize);

		pixelPadding_side = gridSize / 2;
		pixelPadding_top = gridSize / 2;

		//Debug.Log ((width /2) - pi xelPadding_side);

		leftLimit = -1 * ((width / 2) - pixelPadding_side);
		rightLimit = ((width / 2) - pixelPadding_side);
		upperLimit = ((height / 2));

		//Debug.Log ("Upper Limit: " + upperLimit);

		//Define baseline position values used for adding items in a grid layout
		Vector2 currPos = new Vector2(leftLimit, upperLimit);
		Vector2 prevPos = Vector2.zero;

		//Total height of grid items is used to size UI panel for scrolling
		totalHeight = gridSize;

		//loop through data list
		for (int i = 0; i < dataList.Count; i++) {

			//if the last UI item added was in the right most allowed grid space, reset to the line below (at the left hand size)
			if (prevPos.x == rightLimit) {
				currPos = new Vector2 (leftLimit, currPos.y - gridSize);
				totalHeight += gridSize;
			}

			//Instantiate gameobject at passed position. Also set this.transform (the gameobject to which this script is attached) as parent
			GameObject g = GameObject.Instantiate (panelToSpawn, this.transform, false);

			//Set position on the panel
			g.GetComponent<RectTransform> ().anchoredPosition = currPos;

			//SET UI ELEMENT VALUES FOR THE SPAWNED GAMEOBJECT
			Button spwnBtn = g.GetComponentInChildren<Button>();
			Text title = spwnBtn.GetComponentInChildren<Text>();

			Image image = g.GetComponentInChildren<Image>();

			title.text = dataList[i].Title;
			image.sprite = dataList[i].Img;

			//Debug.Log (dataList [i].Img);

			//SET OBJ TO SPAWN IN RELEVANT SCRIPT
			//SpawnObj spawnScript = g.GetComponentInChildren<SpawnObj>();
			//spawnScript.Obj = dataList [i].ObjToSpawn;

			//Increment currPos and set prevPos to the last pos used
			prevPos = currPos;
			currPos = new Vector2(currPos.x + gridSize, currPos.y);
		}

		//Debug.Log (totalHeight);

		//Dynamically set panel height to allow for differing amounts of items added to panel
		this.GetComponent<RectTransform> ().sizeDelta = new Vector2 (width, totalHeight);


		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	//Nested class used for storing passed data
	public class Data{
		private Sprite img;

		public Sprite Img {
			get{ return img; }
			set{ img = value; }
		}

		private string title;

		public string Title {
			get{ return title; }
			set{ title = value; }
		}

		private GameObject objToSpawn;

		public GameObject ObjToSpawn {
			get{ return objToSpawn; }
			set{ objToSpawn = value; }
		}

		public Data(Sprite m_img, string m_title, GameObject m_objToSpawn)
		{
			img = m_img;
			title = m_title;
			objToSpawn = m_objToSpawn;
		}
	}
}

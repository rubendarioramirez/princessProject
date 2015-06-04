using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;

public class xmlTest : MonoBehaviour {


	public XmlDocument root;

	// Use this for initialization
	void Start () {
	
		root = new XmlDocument ();
		root.Load ("note.xml");
		Debug.Log(root.GetElementsByTagName("to")[0].InnerText);
		

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

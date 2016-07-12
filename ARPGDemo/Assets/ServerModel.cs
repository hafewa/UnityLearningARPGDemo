using UnityEngine;
using System.Collections;

public class ServerModel : MonoBehaviour {

	public string IP;
	private string _Name;
	public string Name{
		set{
			transform.Find ("Label").GetComponent<UILabel> ().text = value;
			_Name = value;
		}
		get{
			return _Name;
		}
	}
	public int Count;
	void OnPress(bool isPress){
		if(isPress){
			transform.root.SendMessage("SelectServer", gameObject);
		}
	}
}

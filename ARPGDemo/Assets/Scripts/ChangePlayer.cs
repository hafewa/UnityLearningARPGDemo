using UnityEngine;
using System.Collections;

public class ChangePlayer : MonoBehaviour {

	void OnPress(bool isPress){
		if (!isPress) {
			StartMenuController.Instance.ChangePlayer (gameObject);
		}
	}
}

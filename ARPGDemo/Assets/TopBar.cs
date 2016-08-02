using UnityEngine;
using System.Collections;

public class TopBar : MonoBehaviour {

	#region components
	UILabel lb_diamond;
	UILabel lb_coin;
	UIButton btn_diamond_add;
	UIButton btn_coin_add;
	#endregion

	#region Unity Event
	void Awake(){
		lb_diamond = transform.Find ("diamond_bar/lab_diamond").GetComponent<UILabel> ();
		lb_coin = transform.Find ("coin_bar/lab_coin").GetComponent<UILabel> ();
		btn_diamond_add = transform.Find ("diamond_bar/btn_diamond_add").GetComponent<UIButton> ();
		btn_coin_add = transform.Find ("coin_bar/btn_coin_add").GetComponent<UIButton> ();
		PlayerInfo.Instance.OnPlayerInfoChanged += this.OnPlayerInfoChanged;
	}

	void OnDestroy(){
		PlayerInfo.Instance.OnPlayerInfoChanged -= this.OnPlayerInfoChanged;
	}
	#endregion

	#region custom methods
	void OnPlayerInfoChanged(InfoType type){
		PlayerInfo info = PlayerInfo.Instance;
		if (type == InfoType.All || type == InfoType.Diamond || type == InfoType.Coin) {
			lb_diamond.text = info.Diamond.ToString();
			lb_coin.text = info.Coin.ToString ();
		}
	}
	#endregion
}

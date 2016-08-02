using UnityEngine;
using System.Collections;

public class PlayerBar : MonoBehaviour {

	#region Component
	UISprite sp_avatar;
	UILabel lb_level;
	UILabel lb_name;
	UISlider sl_power;
	UISlider sl_lilian;
	UILabel lb_power;
	UILabel lb_lilian;
	UIButton btn_power_add;
	UIButton btn_lilian_add;
	UIButton btn_open_status;
	#endregion

	#region Unity Event
	void Awake(){
		sp_avatar = transform.Find ("avatar").GetComponent<UISprite> ();
		lb_level = transform.Find ("lab_level").GetComponent<UILabel> ();
		lb_name = transform.Find ("lab_name").GetComponent<UILabel> ();
		sl_power = transform.Find ("power_bar").GetComponent<UISlider> ();
		sl_lilian = transform.Find ("lilian_bar").GetComponent<UISlider> ();
		lb_power = transform.Find ("power_bar/lab_power").GetComponent<UILabel> ();
		lb_lilian = transform.Find ("lilian_bar/lab_lilian").GetComponent<UILabel> ();
		btn_power_add = transform.Find ("btn_power_add").GetComponent<UIButton> ();
		btn_lilian_add = transform.Find ("btn_lilian_add").GetComponent<UIButton> ();
		btn_open_status = transform.Find ("btn_open_status").GetComponent<UIButton> ();
		EventDelegate ed_open_status = new EventDelegate (this, "OnOpenStatusBtnClicked");
		btn_open_status.onClick.Add (ed_open_status);
		PlayerInfo.Instance.OnPlayerInfoChanged += this.OnPlayerInfoChanged;
	}

	void OnDestroy(){
		PlayerInfo.Instance.OnPlayerInfoChanged -= this.OnPlayerInfoChanged;
	}

	#endregion

	#region custom methods
	void OnPlayerInfoChanged(InfoType infoType){
		PlayerInfo info = PlayerInfo.Instance;
		if (infoType == InfoType.All || infoType == InfoType.Avatar || infoType == InfoType.Name || infoType == InfoType.Level || infoType == InfoType.Power || infoType == InfoType.Lilian) {
			sp_avatar.spriteName = info.Avatar;
			lb_level.text = info.Level.ToString ();
			lb_name.text = info.Name;
			sl_power.value = (float)info.Power / 100f;
			sl_lilian.value = (float)info.Lilian / 50f;
			lb_power.text = string.Format ("{0}/100", info.Power);
			lb_lilian.text = string.Format ("{0}/50", info.Lilian);
		}
	}

	void OnOpenStatusBtnClicked(){
		PlayerStatus.Instance.Show ();
	}
	#endregion
}

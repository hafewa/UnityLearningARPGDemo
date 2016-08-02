using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {
	public static PlayerStatus Instance;

	#region components
	UISprite sp_avatar;
	UILabel lb_level;
	UILabel lb_name;
	UILabel lb_ce;
	UISlider sl_exp;
	UILabel lb_exp;
	UIButton btn_change_name;
	UIButton btn_close;
	UILabel lb_diamond;
	UILabel lb_coin;
	UILabel lb_power;
	UILabel lb_lilian;
	UILabel lb_power_rev_part;
	UILabel lb_power_rev_all;
	UILabel lb_lilian_rev_part;
	UILabel lb_lilian_rev_all;
	TweenPosition tw_pos;
	#endregion

	#region unity events
	void Awake(){
		Instance = this;
		sp_avatar = transform.Find ("status_avatar").GetComponent<UISprite> ();
		lb_level = transform.Find ("lab_status_level").GetComponent<UILabel> ();
		lb_name = transform.Find ("lab_status_name").GetComponent<UILabel> ();
		lb_ce = transform.Find ("lab_zhandouli").GetComponent<UILabel> ();
		sl_exp = transform.Find ("exp_bar").GetComponent<UISlider> ();
		lb_exp = transform.Find ("exp_bar/lab_exp").GetComponent<UILabel> ();
		btn_change_name = transform.Find ("btn_change_name").GetComponent<UIButton> ();
		EventDelegate ed_change_name = new EventDelegate (this, "OnChangeNameBtnClicked");
		btn_change_name.onClick.Add (ed_change_name);
		btn_close = transform.Find ("btn_close").GetComponent<UIButton> ();
		EventDelegate ed_close = new EventDelegate (this, "OnCloseBtnClicked");
		btn_close.onClick.Add (ed_close);
		lb_diamond = transform.Find ("lab_status_diamond").GetComponent<UILabel> ();
		lb_coin = transform.Find ("lab_status_coin").GetComponent<UILabel> ();
		lb_power = transform.Find ("lab_status_power").GetComponent<UILabel> ();
		lb_lilian = transform.Find ("lab_status_lilian").GetComponent<UILabel> ();
		lb_power_rev_part = transform.Find ("lab_power_rev_time").GetComponent<UILabel> ();
		lb_power_rev_all = transform.Find ("lab_power_allrev_time").GetComponent<UILabel> ();
		lb_lilian_rev_part = transform.Find ("lab_lilian_rev_time").GetComponent<UILabel> ();
		lb_lilian_rev_all = transform.Find ("lab_lilian_allrev_time").GetComponent<UILabel> ();
		tw_pos = transform.GetComponent<TweenPosition> (); 
		PlayerInfo.Instance.OnPlayerInfoChanged += this.OnPlayerInfoChanged;
	}

	void OnDestroy(){
		PlayerInfo.Instance.OnPlayerInfoChanged -= this.OnPlayerInfoChanged;
	}
	#endregion

	#region custom methods
	void OnPlayerInfoChanged(InfoType type){
		PlayerInfo info = PlayerInfo.Instance;
		sp_avatar.spriteName = info.Avatar;
		lb_level.text = info.Level.ToString();
		lb_name.text = info.Name;
		lb_ce.text = info.CE.ToString();
//		sl_exp.value = (float)
		lb_diamond.text = info.Diamond.ToString();
		lb_coin.text = info.Coin.ToString();
		lb_power.text = string.Format ("{0}/100", info.Power);
		lb_lilian.text = string.Format ("{0}/50", info.Lilian);
		lb_power_rev_part.text = DateUtil.GetTimeStrFromSecs (info.PowerRecoverSecs - info.PowerTimer);
		lb_power_rev_all.text = DateUtil.GetTimeStrFromSecs ((100 - info.Power) * info.PowerRecoverSecs - info.PowerTimer);
		lb_lilian_rev_part.text = DateUtil.GetTimeStrFromSecs (info.LilianRecoverSecs - info.LilianTimer);
		lb_lilian_rev_all.text = DateUtil.GetTimeStrFromSecs ((50 - info.Lilian) * info.LilianRecoverSecs - info.LilianTimer);
	}

	public void Show(){
		tw_pos.PlayForward ();
	}

	public void hide(){
		tw_pos.PlayReverse ();
	}

	void OnCloseBtnClicked(){
		hide ();
	}

	void OnChangeNameBtnClicked(){
		
	}
	#endregion
}

using UnityEngine;
using System.Collections;

public class StartMenuController : MonoBehaviour {
	
	#region attr&var
	public TweenScale StartPanelTween;
	public UILabel StartPanelUsernameLabel;

	public TweenScale LoginPanelTween;
	public UIInput UsernameInputLogin;
	public UIInput PwdInputLogin;

	public TweenScale RegPanelTween;
	public UIInput UsernameInputReg;
	public UIInput PwdInputReg;
	public UIInput ConfirmPwdInputReg;

	public static string Username;
	public static string Pwd;

	#endregion

	#region start panel
	/// <summary>
	/// startpanel  btn_user
	/// </summary>
	public void OnUsernameClick(){
		StartPanelTween.PlayForward ();
		StartCoroutine (HidePanel (StartPanelTween.gameObject));
		LoginPanelTween.gameObject.SetActive (true);
		LoginPanelTween.PlayForward ();
	}

	/// <summary>
	/// startpanel btn_server
	/// </summary>
	public void OnServerClick(){
	}

	/// <summary>
	/// startpanel btn_enter
	/// </summary>
	public void OnEnterGameClick(){
	}

	#endregion


	#region login panel
	/// <summary>
	/// login panel btn_login
	/// </summary>
	public void OnLoginClick(){
		Username = UsernameInputLogin.value;
		Pwd = PwdInputLogin.value;
		StartPanelUsernameLabel.text = Username;
		LoginPanelTween.PlayReverse ();
		StartCoroutine (HidePanel (LoginPanelTween.gameObject));
		StartPanelTween.gameObject.SetActive (true);
		StartPanelTween.PlayReverse ();
	}

	/// <summary>
	/// login panel btn reg
	/// </summary>
	public void OnGotoRegClick(){
		LoginPanelTween.PlayReverse ();
		StartCoroutine (HidePanel (LoginPanelTween.gameObject));
		RegPanelTween.gameObject.SetActive (true);
		RegPanelTween.PlayForward ();
	}

	/// <summary>
	/// login panel btn close
	/// </summary>
	public void OnLoginCloseClick(){
		LoginPanelTween.PlayReverse ();
		StartCoroutine (HidePanel (LoginPanelTween.gameObject));
		StartPanelTween.gameObject.SetActive (true);
		StartPanelTween.PlayReverse ();
	}
	#endregion


	#region reg panel
	/// <summary>
	/// reg panel btn reg
	/// </summary>
	public void OnRegClick(){
		Username = UsernameInputReg.value;
		Pwd = PwdInputReg.value;
		RegPanelTween.PlayReverse ();
		StartCoroutine (HidePanel (RegPanelTween.gameObject));
		StartPanelUsernameLabel.text = Username;
		StartPanelTween.gameObject.SetActive (true);
		StartPanelTween.PlayReverse ();
	}

	/// <summary>
	/// reg panel btn cancel
	/// </summary>
	public void OnCancelClick(){
		RegPanelTween.PlayReverse ();
		StartCoroutine (HidePanel (RegPanelTween.gameObject));
		LoginPanelTween.gameObject.SetActive (true);
		LoginPanelTween.PlayForward ();
	}

	/// <summary>
	/// reg panel btn close
	/// </summary>
	public void OnRegCloseClick(){
		RegPanelTween.PlayReverse ();
		StartCoroutine (HidePanel (RegPanelTween.gameObject));
		StartPanelTween.gameObject.SetActive (true);
		StartPanelTween.PlayReverse ();
	}
	#endregion

	/// <summary>
	/// Hides the panel.
	/// </summary>
	/// <returns>The panel.</returns>
	/// <param name="go">Go.</param>
	IEnumerator HidePanel(GameObject go){
		yield return new WaitForSeconds (0.4f);
		go.SetActive (false);
	}

}

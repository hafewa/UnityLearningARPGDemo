﻿using UnityEngine;
using System.Collections;

public class StartMenuController : MonoBehaviour {
	
	#region attr&var
	public static StartMenuController Instance;

	public TweenScale StartPanelTween;
	public TweenPosition StartPanelTweenPos;
	public UILabel StartPanelUsernameLabel;
	public UILabel StartPanelServerLabel;

	public TweenScale LoginPanelTween;
	public UIInput UsernameInputLogin;
	public UIInput PwdInputLogin;

	public TweenScale RegPanelTween;
	public UIInput UsernameInputReg;
	public UIInput PwdInputReg;
	public UIInput ConfirmPwdInputReg;

	public TweenScale ServerPanelTween;
	public GameObject RedServerCellPrefab;
	public GameObject GreenServerCellPrefab;
	public UIGrid ServerGrid;

	public GameObject SelectedServerItem;

	public GameObject[] SelectedCharacterPrefabArray;
	public TweenPosition SelectPlayerTweenPos;
	public UILabel SelectedPlayerNickName;
	public UILabel SelectedPlayerLevel;
	public GameObject PlayerContainer;
	public static ServerModel Sm;
	public static string Username;
	public static string Pwd;

	private GameObject SelectedCharacter;

	public TweenPosition ChangePlayerTweenPos;
	public UIInput ChangePlayerNicknameInput;
	public GameObject[] ChangeCharactersWithShelf;
	private int selectedPlayerIndex = -1;

	#endregion

	#region engine func
	void Awake(){
		Instance = this;
	}
	void Start(){
		InitServerList ();
	}
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
		StartPanelTween.PlayForward ();
		StartCoroutine (HidePanel (StartPanelTween.gameObject));
		ServerPanelTween.gameObject.SetActive (true);
		ServerPanelTween.PlayForward ();
	}

	/// <summary>
	/// startpanel btn_enter
	/// </summary>
	public void OnEnterGameClick(){
		StartPanelTweenPos.PlayForward ();
		StartCoroutine (HidePanel (StartPanelTweenPos.gameObject));
		SelectPlayerTweenPos.gameObject.SetActive (true);
		SelectPlayerTweenPos.PlayForward ();
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

	#region server panel
	/// <summary>
	/// server panel btn close
	/// </summary>
	public void OnServerCloseClick(){
		ServerPanelTween.PlayReverse ();
		StartCoroutine (HidePanel (ServerPanelTween.gameObject));
		StartPanelTween.gameObject.SetActive (true);
		StartPanelTween.PlayReverse ();
	}

	private void InitServerList(){
		for (int i = 0; i < 30; i++) {
			string ip = "127.0.0.1";
			string name = string.Format ("{0}区 马达加斯加", i + 1);
			int count = Random.Range (0, 100);
			GameObject serverItem = null;
			if (count > 50) {
				//red
				serverItem = NGUITools.AddChild(ServerGrid.gameObject, RedServerCellPrefab);
			} else {
				//green
				serverItem = NGUITools.AddChild(ServerGrid.gameObject, GreenServerCellPrefab);
			}

			ServerModel model = serverItem.GetComponent<ServerModel> ();
			model.Name = name;
			model.IP = ip;
			model.Count = count;
			ServerGrid.AddChild (serverItem.transform);
		}
	}

	public void SelectServer(GameObject go){
		Sm = go.GetComponent<ServerModel> ();
		SelectedServerItem.GetComponent<UIButton> ().normalSprite = go.GetComponent<UIButton> ().normalSprite;
		SelectedServerItem.GetComponent<UIButton> ().hoverSprite = go.GetComponent<UIButton> ().hoverSprite;
		SelectedServerItem.GetComponent<UIButton> ().pressedSprite = go.GetComponent<UIButton> ().pressedSprite;
		SelectedServerItem.GetComponent<UIButton> ().disabledSprite = go.GetComponent<UIButton> ().disabledSprite;
		SelectedServerItem.transform.Find ("Label").GetComponent<UILabel> ().text = Sm.Name;
		SelectedServerItem.transform.Find ("Label").GetComponent<UILabel> ().color = go.transform.Find ("Label").GetComponent<UILabel> ().color;
		StartPanelServerLabel.text = Sm.Name;
		OnServerCloseClick ();
	}
	#endregion

	#region select player panel
	/// <summary>
	/// select player panel btn select player
	/// </summary>
	public void OnSelectPlayerClick(){
		SelectPlayerTweenPos.PlayReverse ();
		StartCoroutine (HidePanel (SelectPlayerTweenPos.gameObject));
		ChangePlayerTweenPos.gameObject.SetActive (true);
		ChangePlayerTweenPos.PlayForward ();
	}
	#endregion

	#region change player panel
	public void ChangePlayer(GameObject go){
		if (SelectedCharacter != go) {
			if (SelectedCharacter) {
				iTween.ScaleTo (SelectedCharacter.transform.parent.gameObject, new Vector3 (1.0f, 1.0f, 1.0f), 0.5f);
			}
			iTween.ScaleTo (go.transform.parent.gameObject, new Vector3 (1.5f, 1.5f, 1.5f), 0.5f);
			SelectedCharacter = go;
			for (int i = 0; i < ChangeCharactersWithShelf.Length; i++) {
				if (ChangeCharactersWithShelf [i] == go) {
					selectedPlayerIndex = i;
				}
			}
		}

	}

	public void OnChangePlayerConfirmClick(){
		if (selectedPlayerIndex >= 0) {
			SelectedPlayerNickName.text = ChangePlayerNicknameInput.value;
			SelectedPlayerLevel.text = "Lv. 1";
			//删除旧模型
			GameObject.Destroy (PlayerContainer.GetComponentInChildren<Animation> ().gameObject);
			//创建新模型
			GameObject newObj = GameObject.Instantiate(SelectedCharacterPrefabArray[selectedPlayerIndex], Vector3.zero, Quaternion.identity) as GameObject;
			newObj.transform.parent = PlayerContainer.transform;
			newObj.transform.localPosition = Vector3.zero;
			newObj.transform.localRotation = Quaternion.identity;
			newObj.transform.localScale = new Vector3 (1, 1, 1);
		}
		OnChangePlayerCloseClick ();
	}

	/// <summary>
	/// change player panel btn close
	/// </summary>
	public void OnChangePlayerCloseClick(){
		ChangePlayerTweenPos.PlayReverse ();
		StartCoroutine (HidePanel (ChangePlayerTweenPos.gameObject));
		SelectPlayerTweenPos.gameObject.SetActive (true);
		SelectPlayerTweenPos.PlayForward ();
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

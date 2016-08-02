using UnityEngine;
using System.Collections;

#region enum
public enum InfoType{
	All,
	Name,
	Avatar,
	Level,
	CE,
	EXP,
	Diamond,
	Coin,
	Power,
	Lilian,
	HP,
	Damage
}
#endregion

public class PlayerInfo : MonoBehaviour {
	/// <summary>
	/// Player Instance
	/// </summary>
	public static PlayerInfo Instance;

	#region property
	/// <summary>
	/// 姓名
	/// </summary>
	private string _name;
	/// <summary>
	/// 头像
	/// </summary>
	private string _avatar;
	/// <summary>
	/// 等级
	/// </summary>
	private int _level = 0;
	/// <summary>
	/// 战斗力
	/// </summary>
	private int _ce = 0;
	/// <summary>
	/// 经验数
	/// </summary>
	private int _exp = 0;
	/// <summary>
	/// 钻石数
	/// </summary>
	private int _diamond = 0;
	/// <summary>
	/// 金币数
	/// </summary>
	private int _coin = 0;
	/// <summary>
	/// 体力数
	/// </summary>
	private int _power = 0;
	/// <summary>
	/// 历练数
	/// </summary>
	private int _lilian = 0;
	/// <summary>
	/// 生命值
	/// </summary>
	private int _hp = 0;
	/// <summary>
	/// 伤害值
	/// </summary>
	private int _damage = 0;

	public float PowerTimer = 0f;

	public float LilianTimer = 0f;

	public float PowerRecoverSecs = 60f;
	public float LilianRecoverSecs = 60f;
	#endregion

	#region get set method
	/// <summary>
	/// Gets or sets the 姓名.
	/// </summary>
	/// <value>姓名</value>
	public string Name{
		get{
			return _name;
		}
		set{ 
			_name = value;
		}
	}
	/// <summary>
	/// Gets or sets the 头像.
	/// </summary>
	/// <value>头像.</value>
	public string Avatar{
		get{
			return _avatar;
		}
		set{ 
			_avatar = value;
		}
	}
	/// <summary>
	/// Gets or sets the 等级.
	/// </summary>
	/// <value>等级.</value>
	public int Level{
		get{
			return _level;
		}
		set{ 
			_level = value;
		}
	}
	/// <summary>
	/// Gets or sets the 战斗力.
	/// </summary>
	/// <value>战斗力.</value>
	public int CE{
		get{
			return _ce;
		}
		set{ 
			_ce = value;
		}
	}
	/// <summary>
	/// Gets or sets the 经验数.
	/// </summary>
	/// <value>经验数.</value>
	public int EXP{
		get{
			return _exp;
		}
		set{ 
			_exp = value;
		}
	}
	/// <summary>
	/// Gets or sets the 钻石数.
	/// </summary>
	/// <value>钻石数.</value>
	public int Diamond{
		get{
			return _diamond;
		}
		set{ 
			_diamond = value;
		}
	}
	/// <summary>
	/// Gets or sets the 金币数.
	/// </summary>
	/// <value>金币数.</value>
	public int Coin{
		get{
			return _coin;
		}
		set{ 
			_coin = value;
		}
	}
	/// <summary>
	/// Gets or sets the 体力数.
	/// </summary>
	/// <value>体力数.</value>
	public int Power{
		get{
			return _power;
		}
		set{ 
			_power = value;
		}
	}
	/// <summary>
	/// Gets or sets the 历练数.
	/// </summary>
	/// <value>历练数.</value>
	public int Lilian{
		get{
			return _lilian;
		}
		set{ 
			_lilian = value;
		}
	}
	/// <summary>
	/// Gets or sets the 生命值.
	/// </summary>
	/// <value>生命值.</value>
	public int HP{
		get{
			return _hp;
		}
		set{ 
			_hp = value;
		}
	}
	/// <summary>
	/// Gets or sets the 伤害值.
	/// </summary>
	/// <value>伤害值.</value>
	public int Damage{
		get{
			return _damage;
		}
		set{ 
			_damage = value;
		}
	}
	#endregion

	#region Delegate & Event
	public delegate void OnPlayerInfoChangedEvent (InfoType infoType);
	public event OnPlayerInfoChangedEvent OnPlayerInfoChanged; 
	#endregion

	#region Unity Event
	void Awake(){
		Instance = this;
	}

	void Start(){
		InitPlayer ();
		OnPlayerInfoChanged (InfoType.All);
	}

	void Update(){
		if (this.Power >= 100f) {
			PowerTimer = 0f;
		} else {
			PowerTimer += Time.deltaTime;
			if (PowerTimer >= PowerRecoverSecs) {
				this.Power += 1;
				PowerTimer = PowerTimer - PowerRecoverSecs;
			}
			OnPlayerInfoChanged (InfoType.Power);
		}

		if (this.Lilian >= 50f) {
			LilianTimer = 0f;
		} else {
			LilianTimer += Time.deltaTime;
			if (LilianTimer >= LilianRecoverSecs) {
				this.Lilian += 1;
				LilianTimer = LilianTimer - PowerRecoverSecs;
			}
			OnPlayerInfoChanged (InfoType.Lilian);
		}
	}
	#endregion

	#region custom method
	/// <summary>
	/// init current player info
	/// </summary>
	void InitPlayer(){
		this.Name = "Moixxs";
		this.Avatar = "头像底板男性";
		this.Level = 1;
		this.CE = 111;
		this.EXP = 1234;
		this.Diamond = 222;
		this.Coin = 333;
		this.Power = 78;
		this.Lilian = 24;
		this.HP = 666;
		this.Damage = 90;

		OnPlayerInfoChanged (InfoType.All);
	}

	public int GetMaxExp(){
		
	}
	#endregion
}

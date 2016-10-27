using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// しゃべＲＵＮナイト　マイク音声取得
/// </summary>
public class GetMicroPhoneVolume : MonoBehaviour {

	//そのうち使うことになるからグローバルに置いておく
	public float volume;

    public float 最大速度;

	readonly int __lensec = 100;
	readonly int __freq = 44100;

	/// <summary>
	/// オブジェクトに自分で<AudioSource>をアタッチしてください！
	/// </summary>
	private new AudioSource audio;

	//===================================
	// Start メソッド
	//===================================
	void Start () 
	{
		GetDevice ();
		AudioInit ();
	}

	//===================================
	// Update メソッド
	//===================================
	void Update () 
	{
		volume = GetAvarageVolume ();
		Debug.Log (volume);
	}

	/// <summary>
	/// 自身のサウンドマイクの名前を英語にしてください！
	/// 使えるマイクの名前を取得できます
	/// </summary>
	void GetDevice()
	{
		foreach (string device in Microphone.devices) {
			Debug.Log ("Name : " + device);
		}
	}

	/// <summary>
	/// Audioをつかえるようにしてyasu！
	/// </summary>
	void AudioInit()
	{
		audio = GetComponent<AudioSource>();
		audio.clip = Microphone.Start (null, true, __lensec, __freq);
		//loop しとかないと止まりヤス
		audio.loop = true;
		//trueにするとミュートがかかるので自分で音声聞けなくなりヤス
		audio.mute = false;
		//デバイスが使用可能になっとる？の貝
		while (!(Microphone.GetPosition ("") > 0)) {}
		//そのまんまplayしてるだけ
		audio.Play ();
	}

	/// <summary>
	/// そんな関数名関係なかったｗｗｗ
	/// 音声データをfloat にして返しやす
	/// </summary>
	float GetAvarageVolume()
	{
		//AudioClipデータ格納用
		float[] acData = new float[256];
		//the absolute value（絶対値）格納用
		float tav = 0;
		//オーディオデータ抽出
		audio.GetOutputData(acData,0);
		//オーディオデータを絶対値で格納
		foreach(float sec in acData){
			tav += Mathf.Abs (sec);
		}
		//いろいろしてかえしてやすｗ制限とか小数削除とか
		return Mathf.Clamp(Mathf.Ceil(tav),0, 最大速度);
	}

}//Code End

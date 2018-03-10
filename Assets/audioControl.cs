using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioControl : MonoBehaviour {

	[SerializeField] private Text leftText;
	[SerializeField] private Text rightText;

	[SerializeField] private AudioSource audioSource;
	[SerializeField] private Slider slider;

	// Use this for initialization
	void Start () {
		slider.maxValue = (int)audioSource.clip.length;
		rightText.text = CalculateTime((int)audioSource.clip.length);
	}
	
	// Update is called once per frame
	void Update () {
		leftText.text = CalculateTime((int)slider.value);

		if (audioSource.isPlaying)
		{
			slider.value = (int)audioSource.time;
		}
	}

	public void OnPointerUp()
	{
		audioSource.UnPause();
		audioSource.time = slider.value;
	}

	public void OnPointerDown()
	{
		audioSource.Pause();
	}

	private string CalculateTime(int totalSeconds)
	{
		string result = "";

		int minutes = Mathf.FloorToInt(totalSeconds / 60);
		int tmp = Mathf.FloorToInt(totalSeconds % 60);

		string seconds = "";

		if(tmp < 10)
		{
			seconds += "0";
		}
		seconds += tmp;

		result = minutes + ":" + seconds;

		return result;
	}
}

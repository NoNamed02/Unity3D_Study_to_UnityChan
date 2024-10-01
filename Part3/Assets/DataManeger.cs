using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DataManeger : MonoBehaviour
{
    public AudioClip[] voice_data;
    private AudioSource _univoice;

    private System.DateTime _now;
    private int _nowMonth;
    private int _oldMonth;
    void Start()
    {
        _now = System.DateTime.Now;
        _nowMonth = _now.Month;
        _univoice = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) PlayVoice();
        else if(Input.GetMouseButtonDown(1))
        {
            _oldMonth = PlayerPrefs.GetInt("Month");
            Debug.Log($"이전 확인 월: {_oldMonth}월");
        }
    }
    private void PlayVoice()
    {
        if (_nowMonth >= 1 && _nowMonth < 4) _univoice.PlayOneShot(voice_data[0]);
        else if (_nowMonth >= 4 && _nowMonth < 6) _univoice.PlayOneShot(voice_data[1]);
        else if (_nowMonth >= 7 && _nowMonth < 10) _univoice.PlayOneShot(voice_data[2]);
        else if (_nowMonth >= 10 && _nowMonth < 13) _univoice.PlayOneShot(voice_data[3]);
        _oldMonth = _nowMonth;
        PlayerPrefs.SetInt("Month", _nowMonth);
        Debug.Log("현재 월 저장됨");
    }
}

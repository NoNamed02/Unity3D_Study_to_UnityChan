using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Janken : MonoBehaviour
{
    public enum voice{
        start,
        pon,
        goo,
        choki,
        par,
        win,
        loose,
        draw
    }
    public AudioClip [] voice_janken = new AudioClip[8];

    const int JANKEN = 0;
    const int GOO = 1;
    const int CHOKI = 2;
    const int PAR = 3;
    const int DRAW = 4;
    const int WIN = 5;
    const int LOOSE = 6;

    private bool _flgJanken;
    private int _modeJanken;


    private Animator _animator;
    private AudioSource _audioSource;

    private int _myHand;
    private int _unityHand;
    private int _flagResult;

    private float _waitTime;

    public GUIStyle [] btu = new GUIStyle[4]; // 1 바위 2 찌 3 빠

    void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        _animator.SetBool("Win", false);
        _animator.SetBool("Loose", false);
        if (_flgJanken == true)
        {
            switch (_modeJanken)
            {
                case 0: // 시작
                    UnityChanAction(JANKEN);
                    _modeJanken++;
                    break;
                case 1: // 플레이어 입력 대기
                    break;
                case 2: // 판정
                    _flagResult = -1;
                    _unityHand = Random.Range(GOO, PAR+1);
                    UnityChanAction(_unityHand);

                    if (_myHand == _unityHand)
                    {
                        _flagResult = DRAW;
                    }
                    else
                    {
                        switch (_unityHand)
                        {
                            case GOO:
                                if (_myHand == PAR) _flagResult = LOOSE;
                                break;
                            case CHOKI:
                                if (_myHand == GOO) _flagResult = LOOSE;
                                break;
                            case PAR:
                                if (_myHand == CHOKI) _flagResult = LOOSE;
                                break;
                        }
                        if (_flagResult != LOOSE) _flagResult = WIN;
                    }
                    _modeJanken++;
                    break;
                case 3: // 결과
                    _waitTime += Time.deltaTime;

                    if (_waitTime > 1.5)
                    {
                        UnityChanAction(_flagResult);
                        _waitTime = 0;
                        _modeJanken++;
                    }
                    break;
                case 4:
                    _flgJanken = false;
                    _modeJanken = 0;
                    break;
            }
        }
    }
    void OnGUI()
    {
        if (_flgJanken == false)
        {
            if (GUI.Button(new Rect(10, Screen.height - 110, 100, 100), "가위바위보", btu[3]))
            {
                _flgJanken = true;
            }
        }
        if (_modeJanken == 1)
        {
            if(GUI.Button (new Rect(Screen.width / 2 - 120, 400, 100, 100), "바위", btu[0]))
            {
                _myHand = GOO;
                _modeJanken++;
            }
            if(GUI.Button (new Rect(Screen.width / 2, 400, 100, 100), "가위", btu[1]))
            {
                _myHand = CHOKI;
                _modeJanken++;
            }
            if(GUI.Button (new Rect(Screen.width / 2 + 120, 400, 100, 100), "보", btu[2]))
            {
                _myHand = PAR;
                _modeJanken++;
            }
        }
    }
    void UnityChanAction(int action)
    {
        switch (action)
        {
            case JANKEN:
                //animator.SetBool("Janken", true);
                _audioSource.clip = voice_janken[(int)voice.start];
                break;
            case GOO:
                //_animator.SetBool("Goo", true);
                _audioSource.clip = voice_janken[(int)voice.goo];
                break;
            case CHOKI:
                //_animator.SetBool("CHOKI", true);
                _audioSource.clip = voice_janken[(int)voice.choki];
                break;
            case PAR:
                //_animator.SetBool("Par", true);
                _audioSource.clip = voice_janken[(int)voice.par];
                break;
            case DRAW:
                //_animator.SetBool("Aiko", true);
                _audioSource.clip = voice_janken[(int)voice.draw];
                break;
            case WIN:
                _animator.SetBool("Win", true);
                _audioSource.clip = voice_janken[(int)voice.win];
                break;
            case LOOSE:
                _animator.SetBool("Loose", true);
                _audioSource.clip = voice_janken[(int)voice.loose];
                break;
        }
        _audioSource.Play();
    }
}

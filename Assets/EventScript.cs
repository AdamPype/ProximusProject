using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventScript : MonoBehaviour {

    [SerializeField] private float[] _timings;
    [SerializeField] private float _moveSpeed;

    [SerializeField] private GameObject _endScreens;
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private float _endYTarget;
    [SerializeField] private float _startYTarget;

    [SerializeField] private AudioClip _introNarration;
    [SerializeField] private AudioClip _startNarration;
    [SerializeField] private AudioClip _endNarration;

    private AudioSource _sound;
    private int index = 0;
    private float _timer;



    // Use this for initialization
    void Start () {
        _timer = _timings[index];
	}
	
	// Update is called once per frame
	void Update () {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
            {
            index++;
            _timer = _timings[index];
            }

        switch (index)
            {
            case 0:
                if (_sound.isPlaying == false)
                    {
                    _sound.Play();
                    }
                _sound.clip = _introNarration;
                break;
            case 1:
                _startScreen.transform.position = Vector3.MoveTowards(_startScreen.transform.position, new Vector3(0, _startYTarget, 0), _moveSpeed);
                _sound.clip = _startNarration;
                break;
            case 2:
                _endScreens.transform.position = Vector3.MoveTowards(_endScreens.transform.position, new Vector3(0, _endYTarget, 0), _moveSpeed);
                _sound.clip = _endNarration;
                break;
            default:
                break;
            }
        }
}

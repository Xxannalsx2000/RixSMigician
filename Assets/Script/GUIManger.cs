using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System;

public class GUIManger : MonoBehaviour
{
    [SerializeField]
    Button playButton;
    [SerializeField]
    Button volumeButton;
    [SerializeField]
    Button effectButton;
    [SerializeField]
    VideoPlayer video;
    [SerializeField]
    Sprite stopImage;
    [SerializeField]
    Sprite playImage;
    [SerializeField]
    Sprite soundOn;
    [SerializeField]
    Sprite mute;
    [SerializeField]
    Sprite effectOn;
    [SerializeField]
    Sprite effectOff;
    [SerializeField]
    GameObject effect;

    bool isStop   = false;
    bool isMute   = false;
    bool isEffect = false;

    // Start is called before the first frame update
    void Start()
    {

        playButton.onClick.AddListener(PlayButtonManager);
        volumeButton.onClick.AddListener(VolumeButtonManager);
        effectButton.onClick.AddListener(EffectButtonManager);


    }

    void PlayButtonManager()
    {

        if (!isStop) 
        {
            var changeToStopImage = playButton.image.sprite;
            //�s�W�ܼƫ��w��playButton���Ϥ��a�}
            changeToStopImage = playImage;
            //����(�ܦ�play)
            playButton.image.sprite = changeToStopImage;
            //�Nplay���Ϥ��������Ӧa�}
            isStop = true;
            //�����s�W�����L
            video.Pause();
            //�����
        }

        else
        {
            var changeToPlayImage = playButton.image.sprite;
            changeToPlayImage = stopImage;
            playButton.image.sprite = changeToPlayImage;
            isStop = false;
            video.Play();

        }
        

    }

    void VolumeButtonManager()
    {

        if (!isMute)
        {

            
            var changeToMute = volumeButton.image.sprite;
            changeToMute = mute;
            volumeButton.image.sprite = changeToMute;
            isMute = true;


            //turn off the sound
            ushort index = 0;
            float mutecontrol = 0.0f;
            video.SetDirectAudioVolume(index, mutecontrol);


        }

        else
        {
            var changeToSoundON = volumeButton.image.sprite;
            changeToSoundON = soundOn;
            volumeButton.image.sprite = changeToSoundON;
            isMute = false;


            //turn on the sound
            ushort index = 0;
            float mutecontrol = 1.0f;
            video.SetDirectAudioVolume(index, mutecontrol);
        }

    }

    void EffectButtonManager()
    {
        if (!isEffect)
        {
            var turnOnEffect = effectButton.image.sprite;
            turnOnEffect = effectOn;
            effectButton.image.sprite = turnOnEffect;
            isEffect = true;


        }

        else
        {
            var turnOffEffect = effectButton.image.sprite;
            turnOffEffect = effectOff;
            effectButton.image.sprite = turnOffEffect;
            isEffect = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

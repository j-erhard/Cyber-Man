using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class OptionMenuH : MonoBehaviour
{

    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioMixer audioMixer;
    private Resolution[] resolutions;
    private int currentResolution;

    private void Awake()
    {

        audioMixer.GetFloat("Master", out float _volume);
        volumeSlider.value = Mathf.InverseLerp(-80f, 5f, _volume);

        volumeSlider.onValueChanged.AddListener(UpdateVolume);
    }

    private void UpdateVolume(float _value)
    {
        audioMixer.SetFloat("Master", Mathf.Lerp(-80, 5, _value));
    }

    private void UpdateResolution(int _value)
    {

    }



}

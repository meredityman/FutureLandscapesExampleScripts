using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class MicrophoneListener : MonoBehaviour {
    public float threshold;


    AudioSource microphoneAudio;
    string deviceName;

    float volume;

    public UnityEvent loudThresholdReached;


    // Use this for initialization
    void Start () {
        microphoneAudio = GetComponent<AudioSource>();

        if (Microphone.devices.Length > 0)
        {
            deviceName = Microphone.devices[0];

            if (!Microphone.IsRecording(deviceName))
            {
                microphoneAudio.clip = Microphone.Start(deviceName, true, 1, AudioSettings.outputSampleRate);
            }
            while (!(Microphone.GetPosition(deviceName) > 0)) { }
            microphoneAudio.loop = true;
            microphoneAudio.Play();
            Debug.Log("Listening to " + deviceName);

        }
        else
        {
            Debug.LogWarning("No microphone found");
        }

        loudThresholdReached.AddListener(OnLoudThresholdReached);
    }

    private void OnDestroy()
    {
        loudThresholdReached.RemoveListener(OnLoudThresholdReached);
    }

    private void OnLoudThresholdReached()
    {
        Debug.Log("Threshold Reached at Volume: " + volume);
    }

    private void Update()
    {
        if( volume > threshold)
        {
            loudThresholdReached.Invoke();
        }
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        int dataLen = data.Length / channels;
        volume = 0;
        for (int n = 0; n < dataLen; n += channels)
        {
            for (int i = 0; i < channels; i++)
            {
                volume += Mathf.Pow(data[n * channels + i], 2);
            }
        }

        volume /= data.Length;
    }
}

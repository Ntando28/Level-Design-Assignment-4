using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[RequireComponent(typeof(PostProcessVolume))]
public class NVcontroller : MonoBehaviour
{
    [SerializeField] private Color defaultLight;
    [SerializeField] private Color boostedLight;
    [SerializeField] private AudioSource NVsound;

    private bool NVOn;
    private PostProcessVolume volume;
    
    void Start()
    {
        RenderSettings.ambientLight = defaultLight;

        volume = gameObject.GetComponent<PostProcessVolume>();
        volume.weight = 0;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            ToggleNV();
        }
    }

    private void ToggleNV()
    {
        NVOn = !NVOn;

        if (NVOn)
        {
            RenderSettings.ambientLight = boostedLight;
            volume.weight = 1;
            NVsound.Play();
        }
        else
        {
            RenderSettings.ambientLight = defaultLight;
            volume.weight = 0;
        }
    }
}

// Reference - https://pixabay.com/sound-effects/night-vision-100467/

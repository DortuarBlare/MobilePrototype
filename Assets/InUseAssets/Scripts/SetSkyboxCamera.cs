using System.Collections;
using System.Collections.Generic;
using Gamekit3D.SkyboxVolume;
using UnityEngine;

public class SetSkyboxCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject SkyboxCamera = GameObject.FindGameObjectWithTag("SkyboxCamera");

        if (SkyboxCamera == null)
        {
            Debug.Log("No SkyboxCamera");
            return;
        }

        Camera cinemachineCamera = GetComponent<Camera>();

        if (cinemachineCamera == null)
        {
            Debug.Log("No cinemachine camera component");
            return;
        }
        
        SkyboxCamera.GetComponent<Skybox3D>().SetCamera(cinemachineCamera);
    }
}

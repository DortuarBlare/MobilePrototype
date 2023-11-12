using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Script_CameraController : MonoBehaviour
{
    private PhotonView photonView;
    public GameObject playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        
        if (playerCamera == null || photonView == null)
            return;
        
        if (photonView.IsMine) 
            playerCamera.SetActive(true);
        else 
            playerCamera.SetActive(false);
    }
}

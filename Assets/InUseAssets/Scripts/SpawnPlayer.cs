using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject playerShadowPrefab;
    public GameObject playerLightPrefab;
    
    public GameObject playerShadowSpawnPoint;
    public GameObject playerLightSpawnPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            PhotonNetwork.Instantiate(playerShadowPrefab.name, playerShadowSpawnPoint.transform.position, Quaternion.identity);
        }
        else if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            PhotonNetwork.Instantiate(playerLightPrefab.name, playerLightSpawnPoint.transform.position, Quaternion.identity);
        }
    }
}

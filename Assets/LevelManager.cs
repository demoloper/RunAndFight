using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Demoloper;

public class LevelManager : MonoBehaviour
{
    BellekYonetim _BellekYonetim = new BellekYonetim();


    
    void Start()
    {
        int mevcutLevel = _BellekYonetim.VeriOku_i("SonLevel");


    }

    
    void Update()
    {
        
    }
}

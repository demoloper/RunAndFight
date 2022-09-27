using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Demoloper;

public class AnaMenuManeger : MonoBehaviour
{

    BellekYonetim _BellekYonetim = new BellekYonetim();
    void Start()
    {
        _BellekYonetim.KontrolEtveTanimla();
    }

    public void SahneYukle(int Index)
    {
        SceneManager.LoadScene(Index);

    }
    public void Oyna()
    {
        SceneManager.LoadScene(_BellekYonetim.VeriOku_i("SonLevel"));
    }
    public void Cýkýs()
    {
        Application.Quit();
    }
}

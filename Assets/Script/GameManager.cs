using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Demoloper;
public class GameManager : MonoBehaviour
{

    
    public static int AnlikKarakterSayisi = 1;

    public List<GameObject> Karakterler;
    public List<GameObject> OlusmaEfektleri;
    public List<GameObject> YokOlmaEfektleri;
    public List<GameObject> AdamLekesiEfektleri;
    [Header("LEVEL VERÝLERÝ")]
    public List<GameObject> Dusmanlar;
    public int KacDusmanOlsun;
    public GameObject _AnaKarakter;
    public bool OyunBittimi;
    bool SonTetikleyici;
    [SerializeField] private GameObject[] Paneller;
    Matematiksel_islemler _Matematiksel_islemler = new Matematiksel_islemler();
    BellekYonetim _BellekYonetim = new BellekYonetim();



    void Start()
    {

        DusmanlarýOlustur();
    }

    void Update()
    {
       

    }
    void SavasDurumu()
    {
        if (SonTetikleyici)
       {        
        if (AnlikKarakterSayisi == 1 || KacDusmanOlsun == 0)
        {
            OyunBittimi = true;
            foreach (var item in Dusmanlar)
            {
                if (item.activeInHierarchy)
                {
                    item.GetComponent<Animator>().SetBool("Saldir", false);
                }

            }
            foreach (var item in Karakterler)
            {
                if (item.activeInHierarchy)
                {
                    item.GetComponent<Animator>().SetBool("Saldir", false);
                }

            }
                _AnaKarakter.GetComponent<Animator>().SetBool("Saldir", false);
            if (AnlikKarakterSayisi < KacDusmanOlsun || AnlikKarakterSayisi == KacDusmanOlsun)
            {
                Debug.Log("Lose");
                    Kaybettin();


            }
            else
            {
                    //_BellekYonetim.VeriKaydet_int("SonLevel", _BellekYonetim.VeriOku_i("SonLevel") + 1);
                Debug.Log("Win");
                    Kazandin();
                }
         }
       }
       
        
        
        
        
    }
    public void Kazandin()
    {
        
        
        Paneller[0].SetActive(true);
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        Time.timeScale = 0;

    }
    public void Kaybettin()
    {

        Paneller[1].SetActive(true);
        Time.timeScale = 0;

    }
    void DusmanlarýOlustur()
    {
        for (int i = 0; i < KacDusmanOlsun; i++)
        {
            Dusmanlar[i].SetActive(true);
        }
    }
    public void DusmanlariTetikle()
    {
        foreach (var item in Dusmanlar)
        {
            if (item.activeInHierarchy)
            {
                item.GetComponent<Dusman>().AnimasyonTetikle();
            }
        }
         SonTetikleyici=true;
        SavasDurumu();

}
    public void AjanYonetim(string islemturu,int GelenSayi, Transform Pozisyon)
    {
        switch (islemturu)
        {
            case "Carpma":
                _Matematiksel_islemler.Carpma(GelenSayi,Karakterler, Pozisyon, OlusmaEfektleri);
                break;
            case "Toplama":
                _Matematiksel_islemler.Toplama(GelenSayi, Karakterler, Pozisyon, OlusmaEfektleri);
                break;
            case "Cikartma":
                _Matematiksel_islemler.Cikartma(GelenSayi, Karakterler,YokOlmaEfektleri);
                break;
            case "Bolme":
                _Matematiksel_islemler.Bolme(GelenSayi, Karakterler, YokOlmaEfektleri);
                break;
        }





    }
    public void YokOlmaEfektiOlustur(Vector3 Pozisyon,bool Balyoz=false,bool Durum=false)
    {
        foreach (var item in YokOlmaEfektleri)
        {
            if (!item.activeInHierarchy)
            {
                item.SetActive(true);
                item.transform.position = Pozisyon;
                item.GetComponent<ParticleSystem>().Play();
                item.GetComponent<AudioSource>().Play();
                if (!Durum)
                {
                    AnlikKarakterSayisi--;
                }
                else
                {
                    KacDusmanOlsun--;
                }
                
                break;
            }
        }
       
        if (Balyoz)
        {
            Vector3 yeniPoz = new Vector3(Pozisyon.x, 0.1591f, Pozisyon.z);
            foreach (var item in AdamLekesiEfektleri)
            {
                if (!item.activeInHierarchy)
                {
                    item.SetActive(true);
                    item.transform.position = yeniPoz;
                    break;
                }
             
            }
        }
        if (!OyunBittimi)
        {
            SavasDurumu();
        }
    }

    public void Butonlarinislemleri(string Deger)
    {
        switch (Deger)
        {
            case "Durdur":
                Time.timeScale = 0;
                Paneller[0].SetActive(true);
                break;
            case "DevamEt":
                Time.timeScale = 1;
                Paneller[0].SetActive(false);
                break;
            case "Tekrar":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
                break;
            case "SonrakiLevel":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Time.timeScale = 1;
                break;
            case "Ayarlar":
            //isteðe baðlý 
            case "Cikis":
                Application.Quit();
                break;
        }

    }





}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class karakter : MonoBehaviour
{
    public GameManager _GameManager;
    public kamera _Kamera;
    public bool SonTetikleyici;
    public GameObject SonKonum;
    public Slider _Slider;
    public GameObject GecisNoktasi;

    private void Start()
    {
        float Fark = Vector3.Distance(transform.position, GecisNoktasi.transform.position);
        _Slider.maxValue = Fark;
    }

    private void FixedUpdate()
    {
        if(!SonTetikleyici)
        transform.Translate(Vector3.forward * .1f * Time.deltaTime);
    }
     


    void Update() 
    {
       
        
        if (SonTetikleyici)
        {
            transform.position = Vector3.Lerp(transform.position, SonKonum.transform.position, .015f);
            if(_Slider.value!=0)
            _Slider.value -= .01f;
        }
        else
        {
            float Fark = Vector3.Distance(transform.position, GecisNoktasi.transform.position);
            _Slider.value = Fark; 


            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (Input.GetAxis("Mouse X") < 0)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - .1f, transform.position.y, transform.position.z), .1f);
                }
                if (Input.GetAxis("Mouse X") > 0)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + .1f, transform.position.y, transform.position.z), .1f);
                }
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Toplama")|| other.CompareTag("Cikartma") || other.CompareTag("Carpma") || other.CompareTag("Bolme"))
        {
            int sayi = int.Parse(other.name);
            _GameManager.AjanYonetim(other.tag, sayi, other.transform);
            Debug.Log("carptý");
        }
        else if (other.CompareTag("SonTetikleyici"))
        {
            _Kamera.SonTetikleyici = true;
            _GameManager.DusmanlariTetikle();
            SonTetikleyici = true;
        }
        else if (other.CompareTag("BosKarakter"))
        {
            _GameManager.Karakterler.Add(other.gameObject);
            
            other.gameObject.tag = "AltKarakterler";
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Direk") || (collision.gameObject.CompareTag("ignelikutu"))|| (collision.gameObject.CompareTag("Pervane_igne")))
        {
            if (transform.position.x>0)
            {
                transform.position = new Vector3(transform.position.x - .2f, transform.position.y, transform.position.z);
            }
            else 
            {
                transform.position = new Vector3(transform.position.x + .2f, transform.position.y, transform.position.z);
            }
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PanoController : MonoBehaviour
{
    public GameObject sifrePaneli;
    public Button[] sifreButonlari;
    public Image sifreDurumGorseli;

    [Header("Şifre Ayarları")]
    public List<int> dogruSira = new List<int>(); 

    private List<int> girilenSira = new List<int>();
    private bool panoAktif = false;
    private bool oyuncuYakinda = false;
    private bool panoAcilabilir = true; 

    private Health playerHealth; 
    public KapiKontrol kapiKontrol; 
    public int panoIndex; 

    void Start()
    {
        foreach (Button button in sifreButonlari)
        {
            button.interactable = false;
        }

        sifrePaneli.SetActive(false);
        sifreDurumGorseli.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && oyuncuYakinda && panoAcilabilir)
        {
            panoAktif = !panoAktif;
            sifrePaneli.SetActive(panoAktif);

            foreach (Button button in sifreButonlari)
            {
                button.interactable = panoAktif;
            }

            girilenSira.Clear();
            sifreDurumGorseli.gameObject.SetActive(false);
        }
    }

    public void Buton1Basildi() { ButonaBasildi(1); }
    public void Buton2Basildi() { ButonaBasildi(2); }
    public void Buton3Basildi() { ButonaBasildi(3); }
    public void Buton4Basildi() { ButonaBasildi(4); }
    public void Buton5Basildi() { ButonaBasildi(5); }
    public void Buton6Basildi() { ButonaBasildi(6); }
    public void Buton7Basildi() { ButonaBasildi(7); }
    public void Buton8Basildi() { ButonaBasildi(8); }
    public void Buton9Basildi() { ButonaBasildi(9); }

    void ButonaBasildi(int butonNumarasi)
    {
        if (!panoAktif) return;

        girilenSira.Add(butonNumarasi);

        if (girilenSira.Count == dogruSira.Count)
        {
            if (girilenSira.SequenceEqual(dogruSira))
            {
                Debug.Log("Doğru");
                StartCoroutine(SifreDogru());
            }
            else
            {
                Debug.Log("Yanlış");
                StartCoroutine(SifreYanlis());
            }
        }
    }

    IEnumerator SifreDogru()
    {
        sifreDurumGorseli.gameObject.SetActive(true);
        sifreDurumGorseli.color = Color.green;

        if (kapiKontrol != null)
        {
            kapiKontrol.SetPasswordCorrect(panoIndex); 
        }

        yield return new WaitForSeconds(1.5f);

        sifrePaneli.SetActive(false);
        sifreDurumGorseli.gameObject.SetActive(false); 
        panoAktif = false;
        panoAcilabilir = false;

        foreach (Button button in sifreButonlari)
        {
            button.interactable = false;
        }
    }

    IEnumerator SifreYanlis()
    {
        sifreDurumGorseli.gameObject.SetActive(true);
        sifreDurumGorseli.color = Color.red;

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(5);
        }

        yield return new WaitForSeconds(1.5f);

        sifreDurumGorseli.gameObject.SetActive(false);
        girilenSira.Clear(); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            oyuncuYakinda = true;

            playerHealth = other.GetComponent<Health>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            oyuncuYakinda = false;
            sifrePaneli.SetActive(false);
            panoAktif = false;
            girilenSira.Clear();
            sifreDurumGorseli.gameObject.SetActive(false);

            foreach (Button button in sifreButonlari)
            {
                button.interactable = false;
            }

            playerHealth = null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScButtonInput : MonoBehaviour {

    //Game objects
    //Image imSoal;
    Text kodeSoal;
    Text txSkor;
    Button btnA, btnB, btnC, btnD;
    Text txBtnA, txBtnB, txBtnC, txBtnD; 
    [SerializeField] GameObject panel;

    //Attributes
    int soalKe = 0;
    int skor = 0;
    [SerializeField] int skorPerSoal = 20;

    //Kelas soal
    [System.Serializable] class soal {
        //[SerializeField] public Sprite gambarSoal;
        [SerializeField] public string teksSoal;
        [SerializeField] public string teksA;
        [SerializeField] public string teksB;
        [SerializeField] public string teksC;
        [SerializeField] public string teksD;
        [SerializeField] public string jawaban;
    }

    //Array kelas soal
    [SerializeField] soal[] paketSoal = new soal[1];

    //Fungsi menampilkan soal & jawaban
    void TampilSoal() {
        //imSoal.sprite = paketSoal[soalKe].gambarSoal;
        kodeSoal.text = paketSoal[soalKe].teksSoal;
        txBtnA.text = paketSoal[soalKe].teksA;
        txBtnB.text = paketSoal[soalKe].teksB;
        txBtnC.text = paketSoal[soalKe].teksC;
        txBtnD.text = paketSoal[soalKe].teksD;
        txSkor.text = skor.ToString();
    }

    // Inisialisasi (Intansiasi game object hanya dapat dilakukan di fungsi Start)
    void Start() {
        txSkor = GameObject.Find("Skor").GetComponent<Text>();    //Alternatif cara instansiasi komponen Text tanpa melalui Panel Inspector
        //imSoal = GameObject.Find("ImSoal").GetComponent<Image>();
        kodeSoal = GameObject.Find("Soal").GetComponent<Text>();
        btnA = GameObject.Find("BtnA").GetComponent<Button>();
        btnB = GameObject.Find("BtnB").GetComponent<Button>();
        btnC = GameObject.Find("BtnC").GetComponent<Button>();
        btnD = GameObject.Find("BtnD").GetComponent<Button>();
        txBtnA = btnA.GetComponentInChildren<Text>();               //Alternatif cara instansiasi anak komponen Button (Text) tanpa melalui Panel Inspector
        txBtnB = btnB.GetComponentInChildren<Text>();
        txBtnC = btnC.GetComponentInChildren<Text>();
        txBtnD = btnD.GetComponentInChildren<Text>();

        btnA.onClick.AddListener(delegate () { FunTombol('A'); });  //Alternatif memberikan fungsi tombol melalui script
        btnB.onClick.AddListener(delegate () { FunTombol('B'); });
        btnC.onClick.AddListener(delegate () { FunTombol('C'); });
        btnD.onClick.AddListener(delegate () { FunTombol('D'); });

        TampilSoal();
    }

    //Fungsi Tombol
    public void FunTombol(char pilihan) {
        if (pilihan == 'A') {
            if (paketSoal[soalKe].teksA == paketSoal[soalKe].jawaban) {     //Sesuai dengan jawaban
                skor += skorPerSoal;
            }
        }
        else if (pilihan == 'B') {
            if (paketSoal[soalKe].teksB == paketSoal[soalKe].jawaban) {     //Sesuai dengan jawaban
                skor += skorPerSoal;
            }
        }
        else if (pilihan == 'C') {
            if (paketSoal[soalKe].teksC == paketSoal[soalKe].jawaban) {     //Sesuai dengan jawaban
                skor += skorPerSoal;
            }
        }
        else if (pilihan == 'D') {
            if (paketSoal[soalKe].teksD == paketSoal[soalKe].jawaban) {     //Sesuai dengan jawaban
                skor += skorPerSoal;
            }
        }

        if (soalKe < paketSoal.Length - 1) {    //Masih ada soal
            soalKe += 1;
        }
        else {                                      //Soal sudah habis (disable komponen)
            //imSoal.gameObject.SetActive(false);     //Menyembunyikan (hide) game object
            kodeSoal.gameObject.SetActive(false);
            btnA.gameObject.SetActive(false);
            btnB.gameObject.SetActive(false);
            btnC.gameObject.SetActive(false);
            btnD.gameObject.SetActive(false);
            panel.SetActive(!panel.activeInHierarchy);


        }

        EventSystem.current.SetSelectedGameObject(null);    //Menghilangkan "selected" pada suatu game object
        TampilSoal();
    }
    public void goToScene(string destination)
    {
        SceneManager.LoadScene(destination);
    }
}

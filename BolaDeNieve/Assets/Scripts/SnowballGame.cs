using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SnowballGame : MonoBehaviour {

    private SnowballSize snowballSize;

    public int totalFlakes = 5;
    private int flakes = 0;

    public float timeLeft = 120;

    public Text sizeText;
    public Text flakesText;
    public Text timeText;

    public AudioSource effectsAudio = null;
    public AudioClip flakeClip = null;

    void Start () {
        snowballSize = GetComponent<SnowballSize>();
        updateFlakes();
    }

    void Update () {
        // cuenta atras
        timeLeft -= Time.deltaTime;

        // derrota: se acaba el tiempo o la bola se derrite del todo
        if (timeLeft <= 0 || snowballSize.size <= snowballSize.minSize)
        {
            SceneManager.LoadScene("GameOver");
            return;
        }

        updateTime();
        updateSize();
    }

    private void OnTriggerEnter (Collider other)
    {
        // recogemos un copo
        if (other.gameObject.CompareTag("FlakeTag"))
        {
            other.gameObject.SetActive(false);
            effectsAudio.PlayOneShot(flakeClip);
            flakes++;
            updateFlakes();

            // victoria: tenemos todos los copos
            if (flakes == totalFlakes)
            {
                SceneManager.LoadScene("Victory");
            }
        }
    }

    private void updateFlakes()
    {
        flakesText.text = "Copos: " + flakes + "/" + totalFlakes;
    }

    private void updateTime()
    {
        int minutes = (int)(timeLeft / 60);
        int seconds = (int)(timeLeft % 60);
        timeText.text = "Tiempo: " + minutes + ":" + seconds.ToString("00");

        // en los ultimos 10 segundos el tiempo se pone en rojo
        if (timeLeft < 10)
            timeText.color = Color.red;
    }

        private void updateSize()
    {
        // 0% = tamaño minimo (derretida), 100% = tamaño inicial
        float percent = (snowballSize.size - snowballSize.minSize) / (1 - snowballSize.minSize) * 100;
        sizeText.text = "Tamaño: " + Mathf.RoundToInt(percent) + "%";

        // por debajo del 30% el texto se pone en rojo como aviso
        if (percent < 30)
            sizeText.color = Color.red;
        else
            sizeText.color = Color.white;
    }
}
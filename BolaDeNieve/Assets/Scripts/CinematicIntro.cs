using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicIntro : MonoBehaviour {

    public GameObject cinematicCamera;
    public GameObject mainCamera;
    public GameObject hud;

    public MoveSnowball moveSnowball;
    public SnowballGame snowballGame;

    public float duration = 6;
    private bool isPlaying = true;

        public static bool skipIntro = false;

    void Start () {
        // si venimos de caernos al lago, nos saltamos la cinematica
        if (skipIntro)
        {
            skipIntro = false;
            EndCinematic();
            return;
        }

        // al empezar se ve la cinematica y el jugador no puede moverse
        cinematicCamera.SetActive(true);
        mainCamera.SetActive(false);
        hud.SetActive(false);
        moveSnowball.enabled = false;
        snowballGame.enabled = false;
    }

    void Update () {
        if (!isPlaying)
            return;

        duration -= Time.deltaTime;

        // la cinematica acaba sola o se salta con Enter
        if (duration <= 0 || Input.GetKeyDown(KeyCode.Return))
        {
            EndCinematic();
        }
    }

    private void EndCinematic()
    {
        isPlaying = false;
        cinematicCamera.SetActive(false);
        mainCamera.SetActive(true);
        hud.SetActive(true);
        moveSnowball.enabled = true;
        snowballGame.enabled = true;
    }
}
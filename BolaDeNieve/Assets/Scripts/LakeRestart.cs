using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LakeRestart : MonoBehaviour {

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CinematicIntro.skipIntro = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endrun : MonoBehaviour
{
    public GameObject liveCoin;
    public GameObject endscreendisplay;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(endgame());
    }


    IEnumerator endgame()
    {
        yield return new WaitForSeconds(2f);
        liveCoin.SetActive(false);
        endscreendisplay.SetActive(true);
        yield return new WaitForSeconds(10f);
        int randomscene = Random.Range(0, 2);
        SceneManager.LoadScene(randomscene);
    }
}

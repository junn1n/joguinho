using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 



public class botaoiniciar : MonoBehaviour
{

    public void botaoIniciar()
    {
        SceneManager.LoadScene("Game");
    }
}
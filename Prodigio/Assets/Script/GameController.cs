using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController Instance; // Singleton

    public GameObject gameOver;
    public GameObject vitoria;

    public GameObject menu;

    public GameObject barraVida;
    public GameObject score;
    public GameObject pause;

    private void Awake()
    {
        // --- SISTEMA DE SINGLETON ---
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Mantém o GameController entre cenas
        }
        else
        {
            Destroy(gameObject); // Evita duplicata
            return;
        }
    }

    void Start()
    {
        // Não precisa mais do instance = this aqui
    }

    public void ShowGameOver()
    {
        if (gameOver != null) gameOver.SetActive(true);

        if (barraVida != null) barraVida.SetActive(false);
        if (pause != null) pause.SetActive(false);
    }

    public void ShowVitoria()
    {
        if (vitoria != null) vitoria.SetActive(true);

        if (barraVida != null) barraVida.SetActive(false);
        if (pause != null) pause.SetActive(false);
    }

    public void RestartGame(string lvlName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(lvlName);
    }

    public void PassarGame(string lvlName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(lvlName);
    }

    public void MenuPrincipal(string menuP)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuP);
    }

    public void Config()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resetar(string resetar)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Lvl.Lua");
    }

    public void Play()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Voltar()
    {
        menu.SetActive(false);
    }
}

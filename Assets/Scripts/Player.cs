using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Text uiLives;
    [SerializeField] private TMP_Text uiScore;

    [SerializeField] private GameObject gameOverScreen;
    
    [Header("PROPERTIES")]
    [SerializeField] private int lives = 3;
    
    private int _score;

    public bool GameOverStatus { get; private set; }

    private void Start()
    {
        uiLives.text = lives.ToString();
        uiScore.text = _score.ToString();
    }

    public void TakeDamage()
    {
        if (lives <= 0 && GameOverStatus) return;
        TakeLive();
        if (lives <= 0) GameOver();

    }
    
    public void IncreaseScore()
    {
        if (lives <= 0) return;
        _score += 1;
        uiScore.text = _score.ToString();
    }

    private void TakeLive()
    {
        lives--;
        uiLives.text = lives.ToString();
    }

    private void GameOver()
    {
        GameOverStatus = true;
        gameOverScreen.SetActive(true);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        TakeDamage();
    }

    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameOverScreen gameOverScreen;

    int score = 0;
    bool gameHasEnded = false;

    public void EndGame()
    {   
        if(gameHasEnded == false)
        {
            Debug.Log("Active Scene: " + SceneManager.GetActiveScene().name);
            gameOverScreen.Setup(score);
            Debug.Log("Game Over");
            gameHasEnded = true;
            //Restart game
        }
        
        
    }

    public void Restart()
    {
        SceneManager.LoadScene("Demo");
    }

    public void IncreaseScore()
    {
        score += 1;
    }
}

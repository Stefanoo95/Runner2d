using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Player player;
    public ScoreManager scoreManager;
    public ScrollingBackground scrollingBackground;
    
    public AudioSource backgroundSound;
    public AudioSource deathSound;

    private Vector3 playerStartingPoint;
    private Vector3 groundGeneratorStartPoint;

    public GroundGenerator groundGenerator;

    
    public GameObject gameStartMenu;
    public GameObject gameOverScreen;
    public GameObject startingBlock;
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerStartingPoint = player.transform.position;
        groundGeneratorStartPoint = groundGenerator.transform.position;
        gameOverScreen.SetActive(false);
        
        
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        scoreManager.isScoreIncreasing = false;
        backgroundSound.Stop();
        deathSound.Play();
        player.gameObject.SetActive(false);
        //scrollingBackground.gameObject.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        DestructionPoint[] destroyer = FindObjectsOfType<DestructionPoint>();
        for(int i = 0;i<destroyer.Length;i++)
        {
            destroyer[i].gameObject.SetActive(false);
        }
        
        startingBlock.SetActive(true);
        player.gameObject.SetActive(true);
        player.transform.position = playerStartingPoint;
        groundGenerator.transform.position = groundGeneratorStartPoint;
        gameOverScreen.SetActive(false);
        backgroundSound.Play();
        scoreManager.score = 0;
        scoreManager.isScoreIncreasing = true;
    }

  
}

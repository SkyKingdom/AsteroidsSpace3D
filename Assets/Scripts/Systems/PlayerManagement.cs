using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManagement : MonoBehaviour
{
    private GameObject player; //This works but you could als do it how we did it with the asteroids

    //To keep the score we need to add score int to translate that into text.
    //And we need to create a tmpUGUI variable to get the reference of the text.
    public int score;
    public TextMeshProUGUI scoreText;

    // In the start function we can add that the score starts at 0 and than call in a function of points added.
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        score = 0;
        PointsAdded();
    }

    //Lets move our player detection into a separate function and call that function in update.
    private void Update()
    {
        PlayerAliveStatus();
    }

    private void PlayerAliveStatus()
    {
        if (!player)
        {
            SceneManager.LoadSceneAsync(1);
        }
    }

    // PointsAdded function only refers to updating the text when needed. With scoreText = Points: + score;
    public void PointsAdded()
    {
        scoreText.text = "Points: " + score;
    }
}

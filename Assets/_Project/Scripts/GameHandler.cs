using UnityEngine;
using TMPro;

public class GameHandler : MonoBehaviour
{
    int score;
    [SerializeField]
    private Dice dice;
    [SerializeField]
    private TextMeshProUGUI ScoreText;
    [SerializeField]
    private float SpawnHight = 16f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(dice, new Vector3(0, SpawnHight, 0), Quaternion.identity);
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResetScore();
            GameObject[] diceObjects = GameObject.FindGameObjectsWithTag("Dice");
            for (int i = 0; i < diceObjects.Length; i++)
            {
                Destroy(diceObjects[i].gameObject);
            }
        }
    }

    public void Addscore(int point)
    {
        score += point;
        ScoreText.text = score.ToString();
    }

    public void ResetScore()
    {
        score = 0;
        ScoreText.text = score.ToString();
    }
}

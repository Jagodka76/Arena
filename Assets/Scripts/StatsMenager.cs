using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;

public class StatsMenager : MonoBehaviour
{
    public static StatsMenager Instance;

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HPText;
    public GameObject Dead;

    private float scoreTime;
    public int scoreScore;
    public int HPHP;
    private void Awake()
    {
        Instance = this;
        HPHP = 100;
    }

    private void Start()
    {
        UpdateHP();
    }

    void Update()
    {
        if (ScoreText != null)
        {
            if (scoreTime < Time.time && HPHP > 0)
            {
                scoreScore += 1;
                scoreTime = Time.time + 1;
                UpdateTxt();
            }
        }

    }

    public void UpdateTxt()
    {
        if (ScoreText != null)
        {
            ScoreText.text = scoreScore.ToString();
        }
    }

    public void UpdateHP()
    {
        if (HPText != null)
        {
            HPText.text = "HP: " + HPHP.ToString() + "/100";
        }

        if(HPHP <= 0)
        {
            Dead.SetActive(true);
        }
    }
}

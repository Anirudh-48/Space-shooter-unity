using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Text score_txt;
   [SerializeField]
    private Image _livesimg;
    [SerializeField]
    private Text Gameover;
    [SerializeField]
    private Sprite[] _livesprite;
    [SerializeField]
    private Text _restarttext;
    
    void Start()
    {
        score_txt.text = "Score: " + 0;
        Gameover.gameObject.SetActive(false);
    }


    // Update is called once per frame
    public void UpdateScore(int score)
    {
        score_txt.text = "Score: " + score.ToString();
        
    }
    public void UpdateLives(int currentlives)
    {
        _livesimg.sprite = _livesprite[currentlives];
        if (currentlives==0)
        {
            Gameover.gameObject.SetActive(true);
            StartCoroutine(Game_over_text());
        }

    }
    IEnumerator Game_over_text()
    {
        while(true)
        {
            Gameover.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            Gameover.text = "";
            yield return new WaitForSeconds(0.5f);

        }
    }
    void game_ovr()
    {
        Gameover.gameObject.SetActive(true);
        _restarttext.gameObject.SetActive(true);
        StartCoroutine(Game_over_text());
    }
}

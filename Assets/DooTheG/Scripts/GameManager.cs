using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    HoleSet[] holeSets;
    
    private bool isStart;
    
    [SerializeField] 
    private float playTime = 60f;
    private float currTime;

    private int score;

    [SerializeField] private TMP_Text timeText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Button startButton;

    public bool IsStart
    {
        get { return isStart; }
        set
        {
            isStart = value;
            if (isStart)
                StartGame();
            else
                EndGame();
        }
    }

    void Start()
    {
        holeSets = FindObjectsOfType<HoleSet>();

        Init();
    }

    void Init()
    {
        SetTime(playTime);
        GetScore(-score);
    }

    void StartGame()
    {
        // Time, Score 초기화
        Init();
        
        // 시작 버튼 비활성화
        startButton.gameObject.SetActive(false);
        
        // 타이머 시작
        StartCoroutine(Timer());
        
        // 랜덤한 몬스터 점프
        if (isStart)
            StartCoroutine(SelectHoleRoutine());
    }

    void EndGame()
    {
        // 몬스터 위치 초기화
        foreach (HoleSet hs in holeSets)
            hs.Monster.Reset();
        
        // 시작 버튼 활성화
        startButton.gameObject.SetActive(true);
    }

    IEnumerator Timer()
    {
        while (IsStart)
        {
            yield return new WaitForSeconds(1f);
            SetTime(-1);
    
            // 시간 초과 시 게임 종료
            if (currTime <= 0)
                IsStart = false;
        }
    }

    void SetTime(float time)
    {
        currTime += time;
        timeText.text = $"Time : {currTime}";
    }

    IEnumerator SelectHoleRoutine()
    {
        while (IsStart)
        {
            RandomJumpHole();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void RandomJumpHole()
    {
        int ranNum = Random.Range(0, holeSets.Length);
        Monster selectedMonster = holeSets[ranNum].Monster;
        if (selectedMonster != null)
            selectedMonster.Jump();
    }

    public void GetScore(int score)
    {
        if (isStart)
        {
            this.score += score;
            scoreText.text = $"Score : {this.score}";
        }
    }
}

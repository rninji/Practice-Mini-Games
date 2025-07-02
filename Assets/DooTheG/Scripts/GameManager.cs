using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    HoleSet[] holeSets;
    
    private bool isStart;
    
    [SerializeField] 
    private float playTime = 60f;
    private float currTime;

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
        currTime = playTime;
    }

    void StartGame()
    {
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
        
        Init();
        Debug.Log("게임 종료");
    }

    IEnumerator Timer()
    {
        while (IsStart)
        {
            Debug.Log(currTime);
            yield return new WaitForSeconds(1f);
            currTime -= 1;
    
            // 시간 초과 시 게임 종료
            if (currTime <= 0)
                IsStart = false;
        }
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
}

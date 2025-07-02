using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    HoleSet[] holeSets;

    [SerializeField]
    private bool isStart;

    public bool IsStart
    {
        get { return isStart; }
        set
        {
            isStart = value;
            if (isStart)
                StartCoroutine(SelectHoleRoutine());
        }
    }

    void Start()
    {
        holeSets = FindObjectsOfType<HoleSet>();
    }

    IEnumerator SelectHoleRoutine()
    {
        while (isStart)
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

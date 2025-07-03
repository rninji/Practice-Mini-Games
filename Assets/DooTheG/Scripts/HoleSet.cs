using UnityEngine;
using UnityEngine.Serialization;

public class HoleSet : MonoBehaviour
{
    public enum PosType { TOP, MIDDLE, BOTTOM}

    private int layerTerm = 5;
    [SerializeField] private PosType posType;

    private GameObject holeObj;
    private GameObject monsterObj;
    private GameObject blockObj;

    private Monster monster;

    public Monster Monster { get { return monster;} private set { monster = value; } }
    
    void Awake()
    {
        holeObj = Util.FindGameObjectInChildWithTag(gameObject, "Hole");
        monsterObj = Util.FindGameObjectInChildWithTag(gameObject, "Monster");
        blockObj = Util.FindGameObjectInChildWithTag(gameObject, "Block");

        Monster = monsterObj.GetComponent<Monster>();

        // 레이어 순서 지정
        SetOrderLayer();
    }

    void SetOrderLayer()
    {
        holeObj.GetComponent<SpriteRenderer>().sortingOrder = (int)posType * layerTerm;
        monsterObj.GetComponent<SpriteRenderer>().sortingOrder = (int)posType * layerTerm + 1;
        blockObj.GetComponent<SpriteRenderer>().sortingOrder = (int)posType * layerTerm + 2;
    }
}

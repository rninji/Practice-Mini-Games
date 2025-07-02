using UnityEngine;

public class HoleSet : MonoBehaviour
{
    public enum PosType { TOP = 0, MIDDLE = 5, BOTTOM = 10}

    [SerializeField] private PosType posType;

    private GameObject Hole;
    private GameObject Monster;
    private GameObject Block;

    void Start()
    {
        Hole = Util.FindGameObjectInChildWithTag(gameObject, "Hole");
        Monster = Util.FindGameObjectInChildWithTag(gameObject, "Monster");
        Block = Util.FindGameObjectInChildWithTag(gameObject, "Block");

        // 레이어 순서 지정
        SetOrderLayer();
    }

    void SetOrderLayer()
    {
        Hole.GetComponent<SpriteRenderer>().sortingOrder = (int)posType;
        Monster.GetComponent<SpriteRenderer>().sortingOrder = (int)posType + 1;
        Block.GetComponent<SpriteRenderer>().sortingOrder = (int)posType + 2;
    }
}

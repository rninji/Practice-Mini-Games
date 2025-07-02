using UnityEngine;

public class Monster : MonoBehaviour
{
    private Vector3 startPos;
    
    void Start()
    {
        startPos = gameObject.transform.position;
    }

    public void Reset()
    {
        gameObject.transform.position = startPos;
    }
    
    public void Jump()
    {
        this.gameObject.transform.position += new Vector3(0, 1, 0);
    }
}

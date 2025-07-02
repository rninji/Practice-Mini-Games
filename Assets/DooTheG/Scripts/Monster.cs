using UnityEngine;

public class Monster : MonoBehaviour
{
    public void Jump()
    {
        this.gameObject.transform.position += new Vector3(0, 1, 0);
    }
}

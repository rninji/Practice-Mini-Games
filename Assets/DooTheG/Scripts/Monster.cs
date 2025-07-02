using System.Collections;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private Vector3 startPos;
    private Animator anim;
    private bool isJump;
    
    void Start()
    {
        startPos = gameObject.transform.position;
        anim = gameObject.GetComponent<Animator>();
    }

    public void Reset()
    {
        gameObject.transform.position = startPos;
    }
    
    public void Jump()
    {
        if (isJump == false)
            StartCoroutine(JumpRoutine());
    }

    IEnumerator JumpRoutine()
    {
        isJump = true;
        anim.SetTrigger("Jump");
        
        float jumpLength = anim.GetCurrentAnimatorStateInfo(0).length; // 애니메이션 길이
        yield return new WaitForSeconds(jumpLength);
        
        isJump = false;
    }
}

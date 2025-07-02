using System.Collections;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private GameManager gameManager;
    
    private Vector3 startPos;
    private Animator anim;
    private bool isJump;
    private bool isClicked;
    [SerializeField] 
    private int score = 1;
    
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // TODO : 싱글톤 변경
        startPos = gameObject.transform.position;
        anim = gameObject.GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        Clicked();
    }

    public void Reset()
    {
        gameObject.transform.position = startPos;
        isJump = false;
        isClicked = false;
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
        isClicked = false;
    }

    private void Clicked()
    {
        if (isJump && isClicked == false)
        {
            isClicked = true;
            gameManager.GetScore(score);
        }
    }
}

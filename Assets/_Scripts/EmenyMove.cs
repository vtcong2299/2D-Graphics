using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmenyMove : MonoBehaviour
{
    public Vector3[] transformTagget;
    public int index = 0;
    public int enemySpeed = 1;
    private bool enemyFacingRight;
    public Animator animator;
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    public void EnemyWalk()
    {
        Vector3 taggetPos = transformTagget[index];
        transform.position = Vector3.MoveTowards(transform.position, taggetPos,enemySpeed*Time.deltaTime);
        animator.SetBool("isMove", true);
        if (transform.position == taggetPos)
        {
            index++;
            EnemyFlip();
            if (index == transformTagget.Length)
            {
                index = 0;
            }
        }
    }
    public void EnemyFlip()
    {
        Vector3 curScale = transform.localScale;
        curScale.x = -1 * curScale.x;
        transform.localScale = curScale;
        enemyFacingRight = !enemyFacingRight;
    }
    private void Update()
    {
        EnemyWalk();
    }
}

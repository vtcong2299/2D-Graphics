using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDameReceiver : DameReceiver
{
    //public PlayerMove playerMove;
    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        //playerMove = new PlayerMove();
    }
    public override void Receiver(float damage)
    {
        base.Receiver(damage);
        if (IsDead())
        {
            PlayerAnimatorManager.instance.SetDead();
            Debug.Log("Dead");
        }
    }
}


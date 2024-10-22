using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDameSender : DameSender
{
    public PlayerDameReceiver playerDameReceiver;
    private void Start()
    {
        damage = 100;
        playerDameReceiver = GetComponent<PlayerDameReceiver>();
    }
    public override void ColliderSendDame(Collision2D collision)
    {
        if (collision.gameObject.tag == "Dead" || collision.gameObject.tag == "Lava" || collision.gameObject.tag == "Spike")
        {
            base.ColliderSendDame(collision);
            playerDameReceiver.Receiver(damage);
            Debug.Log("Tru Mau");
        }
    }
}

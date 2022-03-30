using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController
{
    private readonly KnifeSpawner knifeSpawner;
    private readonly ControllSystem controll;

    public PlayerController(KnifeSpawner spawner)
    {
        knifeSpawner = spawner; 
        controll = new ControllSystem();
    }

    public void Activate()
    {
        controll.Enable();
        controll.Player.MouseClick.started += ctx => Click(ctx);
        controll.Player.TouchClick.started += ctx => Click(ctx);
    }

    public void Disable()
    {
        controll.Disable();
        controll.Player.MouseClick.started -= ctx => Click(ctx);
        controll.Player.TouchClick.started -= ctx => Click(ctx);
    }

    private float time = 0;
    private void Click(InputAction.CallbackContext context)
    {
        if (GameManager.IsGame && (Time.time - time) > KnifeConfig.DELAY_THROW)
        {
            Knife knife = knifeSpawner.Process();
            knife.Activate();
            time = Time.time;
        }
    }
}

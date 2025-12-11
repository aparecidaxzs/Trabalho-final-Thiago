using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveAmount = 1f;
    private CommandInvoker invoker;

    void Start()
    {
        invoker = new CommandInvoker();
    }

    void Update()
    {
        // Mover para a direita
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            var cmd = new MovePlatformCommand(transform, moveAmount);
            invoker.Execute(cmd);
        }

        // Mover para a esquerda
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            var cmd = new MovePlatformCommand(transform, -moveAmount);
            invoker.Execute(cmd);
        }
    }
}

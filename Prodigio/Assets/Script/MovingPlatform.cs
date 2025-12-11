using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 5f;

    private Vector3 startPosition;
    private CommandInvoker invoker;

    void Start()
    {
        startPosition = transform.position;
        invoker = new CommandInvoker();
    }

    void Update()
    {
        // Calcula movimento usando PingPong
        float movement = Mathf.PingPong(Time.time * speed, distance);

        // Posição desejada
        Vector3 targetPos = startPosition + new Vector3(movement, 0f, 0f);

        // Movimento frame a frame
        Vector3 step = targetPos - transform.position;

        // Cria comando
        ICommand moveCmd = new MovePlatformCommand(transform, step);

        // Executa comando
        invoker.Execute(moveCmd);
    }
}

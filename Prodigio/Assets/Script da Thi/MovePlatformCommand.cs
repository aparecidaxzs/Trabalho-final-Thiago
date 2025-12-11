using UnityEngine;

public class MovePlatformCommand : ICommand
{
    private Transform platform;
    private Vector3 movement;

    public MovePlatformCommand(Transform platform, Vector3 movement)
    {
        this.platform = platform;
        this.movement = movement;
    }

    public void Execute()
    {
        platform.position += movement;
    }

    public void Undo() { }
}

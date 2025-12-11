using UnityEngine;

public class MovePlatformCommand : ICommand
{
    private Transform platform;
    private float distance;

    public MovePlatformCommand(Transform platform, float distance)
    {
        this.platform = platform;
        this.distance = distance;
    }

    public void Execute()
    {
        platform.position += new Vector3(distance, 0f, 0f);
    }

    public void Undo()
    {
        platform.position -= new Vector3(distance, 0f, 0f);
    }
}

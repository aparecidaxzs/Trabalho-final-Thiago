using System.Collections.Generic;

public class CommandInvoker
{
    private Stack<ICommand> history = new Stack<ICommand>();

    public void Execute(ICommand command)
    {
        command.Execute();
        history.Push(command);
    }

    public void Undo()
    {
        if (history.Count > 0)
        {
            ICommand last = history.Pop();
            last.Undo();
        }
    }
}

using System;

public class Chair
{
    public int[] Dimension { get; }
    public bool IsTaken { get; private set; }
    public bool HasAnimal { get; private set; }

    public Chair(int[] dimension)
    {
        Dimension = dimension;
        IsTaken = false;
        HasAnimal = false;
    }

    public void AssignAnimal()
    {
        HasAnimal = true;
    }

    public void ReleaseAnimal()
    {
        HasAnimal = false;
    }

    public void TakeChair()
    {
        IsTaken = true;
    }

    public void ReleaseChair()
    {
        IsTaken = false;
    }
}

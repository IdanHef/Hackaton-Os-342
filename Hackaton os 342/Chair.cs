using System;

public class Chair
{
    public int[] Dimension { get; }
    public bool IsTaken { get; private set; }
    public bool HasAnimal { get; private set; }
    public int Id { get; set; }
    public string Item { get; set; }

    public PictureBox pictureBox;

    public Chair(int[] dimension)
    {   
        Dimension = dimension;
        IsTaken = false;
        HasAnimal = false;
        Id = -1; // Initialize the ChairId to -1 (or any default value)
        Item = null;
        pictureBox = null;
    }
    public Chair(int x, int y)
    {
        Dimension = new int[2];
        Dimension[0] = x;
        Dimension[1] = y;
        IsTaken = false;
        HasAnimal = false;
        Id = -1; // Initialize the ChairId to -1 (or any default value)
        Item = null;
        pictureBox = null;
    }
    public PictureBox getPic()
    {
        return pictureBox;
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

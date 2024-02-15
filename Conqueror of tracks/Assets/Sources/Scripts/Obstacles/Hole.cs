using Game;
using Levels;

public class Hole : LoseCondition
{
    protected override void Start()
    {
        way = transform.parent.parent.GetComponent<Way>();
    }
}

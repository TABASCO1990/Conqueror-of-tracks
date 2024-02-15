using Game;
using Levels;

public class Barrier : LoseCondition
{
    protected override void Start()
    {
        way = transform.parent.parent.parent.GetComponent<Way>();
    }
}

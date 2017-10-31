public class AIRotation : AIPlayer 
{
    public Action rotatingAction;

    public override Action GetAction()
    {
        rotatingAction += 1;
        if (rotatingAction == (Action)3) rotatingAction = (Action)1;
        return rotatingAction;
    }
}

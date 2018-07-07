namespace AI
{
    public enum AIType
    {
        Melee,
        Ranged,
        MeleeAndRanged
    }

    public interface AIAniamtor
    {
        void SetAnimatror(bool walk, bool attack, bool death, bool hit);
        void ResetAnimator();
    }
}
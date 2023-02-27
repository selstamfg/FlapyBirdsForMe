[System.Serializable]

public class Reward 
{
    public enum RewardType
    {
        COINS,
        ANIMAL
    }
    public RewardType Type;
    public int Value;
    public string Name;
}

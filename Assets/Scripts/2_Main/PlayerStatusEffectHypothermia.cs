public class PlayerStatusEffectHypothermia : IPlayerStatusEffect {
    public int Duration { get; set; }
    public string StatusEffectName { get; }
    public statusEffectType StatusEffectType { get; }
    
    public void Event() {
    }
}
using System;

class Enemy {
  public int Id;
  public string Name;
  public double Health;
  private List<Attack> AttacksList;
  public int Score;

  public Enemy(int id, string name, double health, int score) {
    Id = id;
    Name = name;
    Health = health;
    AttacksList = new List<Attack>();
    Score = score;
  }

  public void NewAttack(Attack attack) {
    AttacksList.Add(attack);
  }

  public List<Attack> GetAttacksList() {
    return AttacksList;
  }
}
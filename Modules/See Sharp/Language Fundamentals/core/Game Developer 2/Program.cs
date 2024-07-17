class Program {

  static List<Enemy> Attackers = new List<Enemy>();
  static List<Enemy> Players = new List<Enemy>();
  static int AttackersScore = 0;
  static int PlayersScore = 0;
  static string Record = "";

  static void Main() {
    Attackers.Add(new Melee(0, "Melee Fighter"));
    Attackers.Add(new Ranged(1, "Ranged Fighter"));
    Attackers.Add(new Magic(2, "Magic Caster"));

    // Assaingment's tests
    Assaingment();

    // You should definitly try this one ITS FUN
    // Just comment the ASSAIGNMET call from above and Uncomment the Tournament Call From below and Ejoy
    
    /* Tournament(); */
    
    
  }

static void Assaingment() {
    Console.Write("\n");
    Attackers[0].PerformAttack(Attackers[1], Attackers[0].GetAttacksList()[1]);
    Console.Write("\n");
    Attackers[0].Ultimate(Attackers[2]);
    Console.Write("\n");
    Attackers[1].PerformAttack(Attackers[0], Attackers[1].GetAttacksList()[0]);
    Console.Write("\n");
    Attackers[1].Ultimate(Attackers[0]);
    Console.Write("\n");
    Attackers[2].PerformAttack(Attackers[0], Attackers[2].GetAttacksList()[0]);
    Console.Write("\n");
    Attackers[2].Ultimate(Attackers[1]);
    Console.Write("\n");
    Attackers[2].Ultimate(Attackers[2]);
    Console.Write("\n");
  }

  static Attack RandomAttack(Enemy Attacker, Enemy Target, int Round) {
    Random random = new Random();
    int luck = random.Next(1, 10);
    if(luck == 5)
    {
      if(Attacker is Magic)
      {
        int id = -1;
        string name;
        if (Round % 2 == 1)
        {
          id = random.Next(0, Players.Count);
          Attacker.Ultimate(Players[id]);
          name = Players[id].Name;
        }
        else
        {
          id = random.Next(0, Attackers.Count);
          Attacker.Ultimate(Attackers[id]);
          name = Attackers[id].Name;
        }
        Record += $"(Round {Round}) (HEAL)      {Attacker.Name} Healed His Ally {name} Using His Healing Ability\n";
      }
      else
      {
        Attack ability = Attacker.Ultimate(Target);
        Record += $"(Round {Round}) (ULTIMATE)  {Attacker.Name} Used His Ultimate {ability.Name} on {Target.Name}\n";
      }
      return new Attack("ULTIMATE", 0);
    }
    else
    {
      List<Attack> Attacks = Attacker.GetAttacksList();
      Attack attack = Attacks[random.Next(0, Attacks.Count)];
      Attacker.PerformAttack(Target, attack);
      return attack;
    }
  }

  static void Tournament() {
      Players.Add(new Melee(0, "Chawki The Fighter"));
      Players.Add(new Ranged(1, "Ahmed The TA77AN"));
      Players.Add(new Magic(2, "Mohsen The Magician"));
      Random rand = new Random();
      int Round = 1;
      while (Attackers.Count >= 1 && Players.Count >= 1)
      {
        Console.WriteLine("\n============================================================================================================");
        if(Round % 2 == 1)
        {
          Console.WriteLine($"Round {Round}: Players Turn  (Players' Score: {PlayersScore} | Attackers' Score: {AttackersScore})");
          Console.WriteLine("-----------------------------------------------\n");
          int AttackerId = rand.Next(0, Players.Count);
          int TargetId = rand.Next(0, Attackers.Count);
          Attack Ability = RandomAttack(Players[AttackerId], Attackers[TargetId], Round);
          if (Attackers[TargetId].Health <= 0)
          {
            Record += $"(Round {Round}) (KILL)      {Players[AttackerId].Name} Killed {Attackers[TargetId].Name} Using His {Ability.Name} Attack\n";
            Attackers.RemoveAt(TargetId);
            PlayersScore += 1;
          }
        }
        else
        {
          Console.WriteLine($"Round {Round}: Attackers Turn  (Players' Score: {PlayersScore} | Attackers' Score: {AttackersScore})");
          Console.WriteLine("-----------------------------------------------\n");
          int AttackerId = rand.Next(0, Attackers.Count);
          int TargetId = rand.Next(0, Players.Count);
          Attack Ability = RandomAttack(Attackers[AttackerId], Players[TargetId], Round);
          if (Players[TargetId].Health <= 0)
          {
            Record += $"(Round {Round}) (KILL)      {Attackers[AttackerId].Name} Killed {Players[TargetId].Name} Using His {Ability.Name} Attack\n";
            Players.RemoveAt(TargetId);
            AttackersScore += 1;
          }
        } Round += 1;
      }
      Console.WriteLine("\n============================================================================================================\n");
      if (Attackers.Count() > 0)
      {
        Console.WriteLine($"§§§§§§§§§ !!! ATTACKERS WON THE TOURNAMENT !!! §§§§§§§§");
      }
      else
      {
        Console.WriteLine($"§§§§§§§§§ !!! PLAYERS WON THE TOURNAMENT !!! §§§§§§§§");
      }
      Console.WriteLine($"Scores:    (Players : {PlayersScore} | Attackers' Score: {AttackersScore})\n");
      Console.WriteLine(Record);
      Console.WriteLine("\n============================================================================================================\n");
  }

}
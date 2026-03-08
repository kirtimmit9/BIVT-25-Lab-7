namespace Lab7.Blue
{
    public class Task4
    {
        public struct Team
        {
            private string _name;
            private int[] _scores;
            private int _matchCount;

            public string Name
            {
                get { return _name; }
            }

            public int[] Scores
            {
                get
                {
                    if (_scores == null) return new int[0];

                    int[] copy = new int[_matchCount];
                    for (int i = 0; i < _matchCount; i++)
                    {
                        copy[i] = _scores[i];
                    }
                    return copy;
                }
            }

            public int TotalScore
            {
                get
                {
                    if (_scores == null || _matchCount == 0) return 0;

                    int sum = 0;
                    for (int i = 0; i < _matchCount; i++)
                    {
                        sum += _scores[i];
                    }
                    return sum;
                }
            }

            public Team(string name)
            {
                _name = name;
                _scores = new int[100];
                _matchCount = 0;
            }

            public void PlayMatch(int result)
            {
                if (_matchCount < _scores.Length) // проверка что матчуй меньше
                {
                    _scores[_matchCount] = result;
                    _matchCount++; 
                }
            }

            public void Print()
            {
                Console.Write($"{_name}: ");
                for (int i = 0; i < _matchCount; i++)
                {
                    Console.Write($"{_scores[i]} ");
                }
                Console.WriteLine($"(сумма: {TotalScore})");
            }
        }

        public struct Group
        {
            private string _name;
            private Team[] _teams;
            private int _teamCount;

            public string Name
            {
                get { return _name; }
            }

            public Team[] Teams
            {
                get
                {
                    if (_teams == null) return new Team[0];

                    Team[] result = new Team[_teamCount];
                    for (int i = 0; i < _teamCount; i++)
                    {
                        result[i] = _teams[i];
                    }
                    return result;
                }
            }

            public Group(string name)
            {
                _name = name;
                _teams = new Team[12];
                _teamCount = 0;
            }

            public void Add(Team team)
            {
                if (_teamCount < 12)
                {
                    _teams[_teamCount] = team;
                    _teamCount++;
                }
            }

            public void Add(Team[] teams)
            {
                if (teams == null) return;

                for (int i = 0; i < teams.Length && _teamCount < 12; i++)
                {
                    _teams[_teamCount] = teams[i];
                    _teamCount++;
                }
            }

            public void Sort()
            {
                if (_teams == null || _teamCount <= 1) return;

                for (int i = 0; i < _teamCount - 1; i++)
                {
                    for (int j = 0; j < _teamCount - 1 - i; j++)  // с каждым проходом проверяем на один элемент меньше потому что самый "легкий" элемент уже "всплыл" в конец
                    {
                        if (_teams[j].TotalScore < _teams[j + 1].TotalScore)
                        {
                            Team temp = _teams[j];
                            _teams[j] = _teams[j + 1];
                            _teams[j + 1] = temp;
                        }
                    }
                }
            }

            public static Group Merge(Group group1, Group group2, int size)
            {
                Group result = new Group("Финалисты");

                if (group1._teams == null || group2._teams == null) return result;

                Team[] all = new Team[group1._teamCount + group2._teamCount];
                int count = 0;

                for (int i = 0; i < group1._teamCount; i++)
                {
                    all[count] = group1._teams[i];
                    count++;
                }

                for (int i = 0; i < group2._teamCount; i++)
                {
                    all[count] = group2._teams[i];
                    count++;
                }

                for (int i = 0; i < count - 1; i++)
                {
                    for (int j = 0; j < count - 1 - i; j++)
                    {
                        if (all[j].TotalScore < all[j + 1].TotalScore)
                        {
                            Team temp = all[j];
                            all[j] = all[j + 1];
                            all[j + 1] = temp;
                        }
                    }
                }

                int take = size;
                if (take > count) take = count;

                for (int i = 0; i < take; i++)
                {
                    result.Add(all[i]);
                }

                return result;
            }

            public void Print()
            {
                Console.WriteLine($"{_name}:");
                for (int i = 0; i < _teamCount; i++)
                {
                    Console.Write($"  {i + 1}. ");
                    _teams[i].Print();
                }
            }
        }
    }
}

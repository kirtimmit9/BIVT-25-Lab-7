namespace Lab7.Blue
{
    public class Task5
    {
        public struct Sportsman
        {
            private string _name;
            private string _surname;
            private int _place;
            private bool _isPlaceSet;

            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }
            public int Place { get { return _place; } }

            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _place = 0;
                _isPlaceSet = false;
            }

            public void SetPlace(int place) //место спортсмена
            {
                if (!_isPlaceSet)
                {
                    _place = place;
                    _isPlaceSet = true;
                }
            }

            public void Print()
            {
                Console.WriteLine($"{_name} {_surname}: {_place}");
            }
        }

        public struct Team
        {
            private string _name;
            private Sportsman[] _sportsmen;
            private int _sportsmanCount;

            public string Name { get { return _name; } }
            public Sportsman[] Sportsmen
            {
                get
                {
                    Sportsman[] result = new Sportsman[_sportsmanCount];
                    Array.Copy(_sportsmen, result, _sportsmanCount);
                    return result;
                }
            }

            public int TotalScore
            {
                get
                {
                    int score = 0;
                    for (int i = 0; i < _sportsmanCount; i++)
                    {
                        int place = _sportsmen[i].Place;
                        if (place == 1) score += 5;
                        else if (place == 2) score += 4;
                        else if (place == 3) score += 3;
                        else if (place == 4) score += 2;
                        else if (place == 5) score += 1;
                    }
                    return score;
                }
            }

            public int TopPlace
            {
                get
                {
                    int bestPlace = 18; // худшее место
                    for (int i = 0; i < _sportsmanCount; i++)
                    {
                        int place = _sportsmen[i].Place;
                        if (place > 0 && place < bestPlace)
                        {
                            bestPlace = place;
                        }
                    }
                    return bestPlace;
                }
            }

            public Team(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[6];
                _sportsmanCount = 0;
            }

            public void Add(Sportsman sportsman)
            {
                if (_sportsmanCount < 6)
                {
                    _sportsmen[_sportsmanCount] = sportsman;
                    _sportsmanCount++;
                }
            }

            public void Add(Sportsman[] sportsmen)
            {
                if (sportsmen == null) return;

                for (int i = 0; i < sportsmen.Length && _sportsmanCount < 6; i++)
                {
                    _sportsmen[_sportsmanCount] = sportsmen[i];
                    _sportsmanCount++;
                }
            }

            public static void Sort(Team[] teams)
            {
                if (teams == null) return;

                for (int i = 0; i < teams.Length - 1; i++)
                {
                    for (int j = 0; j < teams.Length - i - 1; j++)
                    {
                        bool shouldSwap = false;

                        if (teams[j].TotalScore < teams[j + 1].TotalScore) // Если у левой команды (j) баллов меньше, чем у правой (j+1) то нужно поменять местами (большая сумма должна быть слева)
                        {
                            shouldSwap = true;
                        }
                        else if (teams[j].TotalScore == teams[j + 1].TotalScore) //Если суммы баллов равны то сравниваем лучшие места (TopPlace)
                        {

                            if (teams[j].TopPlace > teams[j + 1].TopPlace)
                            {
                                shouldSwap = true;
                            }
                        }

                        if (shouldSwap)
                        {
                            Team temp = teams[j];
                            teams[j] = teams[j + 1];
                            teams[j + 1] = temp;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"{_name}:");
                for (int i = 0; i < _sportsmanCount; i++)
                {
                    Console.Write($"  {i + 1}. ");
                    _sportsmen[i].Print();
                }
                Console.WriteLine($"{TotalScore} баллов, наивысшее место: {TopPlace}");
            }
        }
    }
}

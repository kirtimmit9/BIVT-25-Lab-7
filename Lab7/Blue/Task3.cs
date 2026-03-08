namespace Lab7.Blue
{
    public class Task3
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int[] _penaltyTimes;
            private int _matchCount;

            public string Name
            {
                get { return _name; }
            }
            public string Surname
            {
                get { return _surname; }
            }

            public int[] PenaltyTimes
            {
                get
                {
                    if (_penaltyTimes == null) return new int[0];
                    int[] copy = new int[_penaltyTimes.Length];
                    Array.Copy(_penaltyTimes, copy, _penaltyTimes.Length);
                    return copy;
                }
            }

            public int TotalTime
            {
                get
                {
                    if (_penaltyTimes == null) return 0;
                    int sum = 0;
                    foreach (int time in _penaltyTimes)
                    {
                        sum += time;
                    }
                    return sum;
                }
            }
            // проверка на 10
            public bool IsExpelled
            {
                get
                {
                    if (_penaltyTimes == null) return false;
                    foreach (int time in _penaltyTimes)
                    {
                        if (time == 10) return true;
                    }
                    return false;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _penaltyTimes = new int[0];
                _matchCount = 0;
            }

            public void PlayMatch(int time)
            {
                if (_penaltyTimes == null) return;

                Array.Resize(ref _penaltyTimes, _penaltyTimes.Length + 1);
                _penaltyTimes[_penaltyTimes.Length - 1] = time;
            }
            // добавляет щтрафы

            public static void Sort(Participant[] array)
            {
                if (array == null) return;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[i].TotalTime > array[j].TotalTime)
                        {
                            Participant temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"{_name} {_surname}: {TotalTime}");
            }
        }
    }
}

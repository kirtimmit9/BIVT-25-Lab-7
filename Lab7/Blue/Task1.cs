namespace Lab7.Blue
{
    public class Task1
    {
        public struct Response
        {
            private string _name;
            private string _surname;
            private int _votes;

            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }
            public int Votes { get { return _votes; } }

            public Response(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _votes = 0;
            }

            public int CountVotes(Response[] responses)
            {
                if (responses == null) return 0;

                int count = 0;
                foreach (var response in responses)
                {
                    if (response.Name == _name && response.Surname == _surname)
                    {
                        count++;
                    }
                }

                for (int i = 0; i < responses.Length; i++)
                {
                    if (responses[i].Name == _name && responses[i].Surname == _surname)
                    {
                        responses[i]._votes = count;
                    }
                }

                _votes = count;
                return count;
            }

            public void Print()
            {
                Console.WriteLine($"{_name} {_surname}: {_votes}");
            }
        }
    }
}

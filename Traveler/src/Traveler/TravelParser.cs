using System;
using System.Collections.Generic;

namespace Traveler
{
    public static class TravelParser
    {
        public static (int x, int y, char direction)[] Run(string input)
        {
            var result = new List<(int, int, char)>();
            var l = input.Split("\r\n");

            var i = 0;
            while (true)
            {
                if (!l[i].StartsWith("POS="))
                {
                    throw new InvalidOperationException("Missing position!");
                }

                var temp = l[i].Split('=');
                var p = (int.Parse(temp[1].Split(',')[0]), int.Parse(temp[1].Split(',')[1]), temp[1].Split(',')[2][0]);
                i += 1;

                var q = false;
                while (i < l.Length)
                {
                    if (l[i].StartsWith("POS="))
                    {
                        q = !q;
                        break;
                    }

                    foreach (var op in l[i])
                    {
                        if (op == 'F')
                        {
                            switch (p.Item3)
                            {
                                case 'N': p.Item2 -= 1; break;
                                case 'S': p.Item2 += 1; break;
                                case 'E': p.Item1 += 1; break;
                                case 'W': p.Item1 -= 1; break;
                            }
                        }
                        else if (op == 'B')
                        {
                            switch (p.Item3)
                            {
                                case 'N': p.Item2 += 1; break;
                                case 'S': p.Item2 -= 1; break;
                                case 'E': p.Item1 -= 1; break;
                                case 'W': p.Item1 += 1; break;
                            }
                        }
                        else if (op == 'L' || op == 'R')
                        {
                            var newRotation = Rotate(p.Item3, op);
                            p.Item3 = newRotation;
                        }
                    }

                    i++;
                }

                if (i >= l.Length)
                {
                    break;
                }

                if (string.IsNullOrWhiteSpace(l[i]))
                {
                    i++;
                    continue;
                }

                if (q)
                {
                    result.Add(p);
                }
            }

            return result.ToArray();
        }

        private static char Rotate(char f, char r)
        {
            switch (f)
            {
                case 'N':
                    {
                        switch (r)
                        {
                            case 'F': return 'N';
                            case 'B': return 'N';
                            case 'L': return 'W';
                            case 'R': return 'E';
                        }
                        break;
                    }
                case 'S':
                    {
                        switch (r)
                        {
                            case 'F': return 'S';
                            case 'B': return 'S';
                            case 'L': return 'E';
                            case 'R': return 'W';
                        }
                        break;
                    }
                case 'E':
                    {
                        switch (r)
                        {
                            case 'F': return 'E';
                            case 'B': return 'E';
                            case 'L': return 'N';
                            case 'R': return 'S';
                        }
                        break;
                    }
                case 'W':
                    {
                        switch (r)
                        {
                            case 'F': return 'W';
                            case 'B': return 'W';
                            case 'L': return 'S';
                            case 'R': return 'N';
                        }
                        break;
                    }
            }

            throw new InvalidOperationException("Could not rotate!");
        }
    }
}

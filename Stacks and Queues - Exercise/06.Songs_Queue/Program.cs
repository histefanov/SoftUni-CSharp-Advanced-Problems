using System;
using System.Collections.Generic;

namespace _06.Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> playlist = new Queue<string>(
                Console.ReadLine()
                .Split(", "));

            while (playlist.Count > 0)
            {
                string command = Console.ReadLine();
                if (command == "Play")
                {
                    playlist.Dequeue();
                }
                else if (command == "Show")
                {
                    List<string> currentPlaylist = new List<string>();

                    foreach (var song in playlist)
                    {
                        currentPlaylist.Add(song);
                    }

                    Console.WriteLine(string.Join(", ", currentPlaylist));
                }
                else
                {
                    string song = command.Substring(4);
                    if (!playlist.Contains(song))
                    {
                        playlist.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}

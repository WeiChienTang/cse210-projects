using System;

class Program
{
    static void Main(string[] args)
    {
        Entry entry = new();
        entry.ShowWelcome();
        Player player = entry.CreatPlayer();
        GameSystem.player = player;

        bool isEnding = false;
        BasciMAP place_ = new KamDyn();

        while (!isEnding)
        {
            place_.ShowWelcome();
            place_ = place_.ShowDos();
        }
    }
}
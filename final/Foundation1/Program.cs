using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("$456,000 Squid Game In Real Life!", "MrBeast", 1524);
        video1.AddComment("@JoleAron", "We laughed, we cried... The production value here, the story telling... just wow. Bravo Mr. Beast.");
        video1.AddComment("@mfuyozeyisethwala3444", "456000 squid game challenge. 456 million views. Jimmy is sensational");
        video1.AddComment("@YesTheory", "This is insanity, never done before in the history of this platform. Hats off to you Jimmy ");
        videos.Add(video1);

        Video video2 = new Video("Cleaning the Ocean!", "Beast Philanthropy", 247);
        video2.AddComment("@MrMonny", "It's insane! Jimmy and Mark have just finished the 30 million! That's phenomenal what fans can do.");
        video2.AddComment("@evangcd001", "It's really cool that Jimmy cares so much about the Sea, He's such a great guy. #TeamSeas");
        video2.AddComment("@MattyTingles", "So cool to see myself in this video! Happy to be a part of #TeamSeas");
        video2.AddComment("@JesseSwaney", "This is what beautiful content looks like!");
        video2.AddComment("@Kipzo", "Thanks for everything you've done buddy");
        videos.Add(video2);    

        Video video3 = new Video("Rarest Things On Earth!", "Beast Reacts", 489);
        video3.AddComment("@WestyC", "respect to that delivery man for going the extra mile to connect with his customers.");
        video3.AddComment("@justgrandtheftauto", "Mr Beast himself can be the rareest thing on earth.");
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Video Title:\t\t{video._title}");
            Console.WriteLine($"Video Author:\t\t{video._author}");
            Console.WriteLine($"Video Length:\t\t{video._length} seconds");
            Console.WriteLine($"Number of Comments:\t{video._comments.Count()}");

            foreach (Comment comment in video._comments)
            {
                Console.WriteLine($"\n{comment._name}");
                Console.WriteLine($"\"{comment._comment}\"");
            }
            Console.WriteLine("----------------------------------");
        }
    }
}
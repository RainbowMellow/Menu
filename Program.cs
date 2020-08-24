using System;
using System.Collections.Generic;
using BLLCore;
using ModelsCore;

namespace Menu
{
    class Program
    {
        private static VideoBLL bll = new VideoBLL();

        private static string[] options = {

                "Exit",
                "Create a new video",
                "Delete a video",
                "Show videos",
                "Update video"
            };
        
        static void Main(string[] args)
        { 
            Menu(options);
            
        }

        #region Menu
        private static void Menu(string[] choices)
        {
            Console.Clear();
            Console.WriteLine("Hello! Welcome to the video menu! ");

            for (int i = 0; i < choices.Length; i++)
            {
                Console.WriteLine($"{i}: {choices.GetValue(i)}");
            }

            Console.WriteLine("\nPlease choose an option: ");

           
            int selection;

            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 0
                || selection > 4)
            {
                Console.WriteLine("\nYou need to select a number between 1 and 4.");
            }

            switch (selection)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    CreateVideo();
                    break;
                case 2:
                    DeleteVideo();
                    break;
                case 3:
                    VideoList();
                    break;
                case 4:
                    UpdateVideo();
                    break;
            }

        }
        #endregion

        #region Update
        private static void UpdateVideo()
        {
            Console.WriteLine("You chose to update a video!" +
                "\nPlease write the name of the video you want to update:");

            string title = Console.ReadLine().Trim();

            Char[] array = title.ToCharArray();
            foreach (Char letter in array)
            {
                if (!Char.IsLetter(letter))
                {
                    Console.WriteLine("\nPlease input a name without special characters or numbers." +
                       "\nWould you like to try again?" +
                       "\nYes/No");

                    switch (Console.ReadLine().ToLower())
                    {
                        case "yes":
                            Console.Clear();
                            UpdateVideo();
                            break;
                        case "no":
                            Menu(options);
                            break;
                        default:
                            Environment.Exit(0);
                            break;
                    }

                }
            }

            Video vid = bll.GetVideo(title);
            Console.WriteLine($"\nThe title of the video was {title} \nWhat would you like to change it to?");
            string name = Console.ReadLine().Trim();

            Console.WriteLine($"\nThe date of the video was {vid.Date} \nWhat would you like to change it to?");
            DateTime dt = Convert.ToDateTime(Console.ReadLine().Trim());

            Console.WriteLine($"\nThe storyline of the video was {vid.StoryLine} \nWhat would you like to change it to?");
            string storyLine = Console.ReadLine().Trim();

            try
            {
                bll.UpdateVideo(name, dt, storyLine);
                Console.WriteLine("\nThe video was updated!");
                Console.WriteLine("\nWould you like to go back to the menu or exit? \nMenu/Exit");

                switch (Console.ReadLine().ToLower())
                {
                    case "menu":
                        Console.Clear();
                        Menu(options);
                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
            }
            catch
            {
                Console.WriteLine("The video could not be updated!");
                Console.WriteLine("\nWould you like to go back to the menu or exit? \nMenu/Exit");

                switch (Console.ReadLine().ToLower())
                {
                    case "menu":
                        Console.Clear();
                        Menu(options);
                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
            }

        }
        #endregion

        #region VideoList
        private static void VideoList()
        {
            Console.Clear();
            
            List<Video> videos = bll.GetVideos();
            if (videos.Count == 0)
            {
                Console.WriteLine("You chose to see the list of videos! " +
                    "\nYou haven't added any videos yet!");

                Console.WriteLine("\nWould you like to go back to the menu or exit? \nMenu/Exit");

                switch (Console.ReadLine().ToLower())
                {
                    case "menu":
                        Console.Clear();
                        Menu(options);
                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nWould you like to see one video, or a list or all videos?" +
                    "\n1: Search for video" +
                    "\n2: List of all videos");

                switch (int.Parse(Console.ReadLine().Trim()))
                {
                    case 1:
                        Console.WriteLine("Input the title of the video:");
                        
                        string title = Console.ReadLine().Trim();
            
                        Char[] array = title.ToCharArray();
                        foreach (Char letter in array)
                        {
                            if (!Char.IsLetter(letter))
                            {
                                Console.WriteLine("\nPlease input a name without special characters or numbers." +
                                   "\nWould you like to try again?" +
                                   "\nYes/No");

                                switch (Console.ReadLine().ToLower())
                                {
                                    case "yes":
                                        Console.Clear();
                                        VideoList();
                                        break;
                                    case "no":
                                        Menu(options);
                                        break;
                                    default:
                                        Environment.Exit(0);
                                        break;
                                }

                            }
                        }
                        Video vid = bll.GetVideo(title);
                        Console.WriteLine($"\nInformation about {title}:");
                        Console.WriteLine($"{vid.Title}, {vid.Date.ToShortDateString()}, {vid.StoryLine}");
                        
                        Console.WriteLine("\nWould you like to go back to the menu or exit? \nMenu/Exit");

                        switch (Console.ReadLine().ToLower())
                        {
                            case "menu":
                                Console.Clear();
                                Menu(options);
                                break;
                            case "exit":
                                Environment.Exit(0);
                                break;
                            default:
                                Environment.Exit(0);
                                break;
                        }

                        break;
                    case 2:
                        Console.WriteLine("You chose to see the list of videos! \n" +
                   "\nList of videos: " +
                   "\n(Title, Date, Storyline) \n");

                        foreach (Video video in bll.GetVideos())
                        {
                            Console.WriteLine($"{video.Title}, {video.Date.ToShortDateString()}, {video.StoryLine}");
                        }

                        Console.WriteLine("\nWould you like to go back to the menu or exit? \nMenu/Exit");

                        switch (Console.ReadLine().ToLower())
                        {
                            case "menu":
                                Console.Clear();
                                Menu(options);
                                break;
                            case "exit":
                                Environment.Exit(0);
                                break;
                            default:
                                Environment.Exit(0);
                                break;
                        }
                        break;
                }


               
            }
        }
        #endregion

        #region Delete
        private static void DeleteVideo()
        {
            Console.WriteLine("You chose to delete a video! " +
                "\nInput the name of the video you want to delete: " +
                "\nTo see the list of videos, input L");

            string name = Console.ReadLine().Trim();
            Char[] array = name.ToCharArray();
            foreach (Char letter in array)
            {
                if (!Char.IsLetter(letter))
                {
                    Console.WriteLine("\nPlease input a name without special characters or numbers." +
                        "\nWould you like to try again?" +
                        "\nYes/No");

                    switch (Console.ReadLine().ToLower())
                    {
                        case "yes":
                            Console.Clear();
                            DeleteVideo();
                            break;
                        case "no":
                            Menu(options);
                            break;
                        default:
                            Environment.Exit(0);
                            break;
                    }

                }
            }

            if(name.ToLower().Equals("l"))
            {
                Console.WriteLine("\nList of videos:\n");
                foreach (Video video in bll.GetVideos())
                {
                    Console.WriteLine($"{video.Title}, {video.Date.ToShortDateString()}, {video.StoryLine}");
                }

                Console.WriteLine("\nWould you like to go back?" +
                        "\nYes/No"); ;

                switch (Console.ReadLine().ToLower())
                {
                    case "yes":
                        Console.Clear();
                        DeleteVideo();
                        break;
                    case "no":
                        Menu(options);
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }

            }

            Console.WriteLine($"\nAre you sure you want to delete {name}?" +
                "\nYes/No");

            switch (Console.ReadLine().ToLower())
            {
                case "yes":
                    try 
                    {
                        bll.DeleteVideo(name);
                        Console.WriteLine("\nThe video was deleted!");
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("\nThe video could not be deleted!");
                    }
                    Console.WriteLine("\nWould you like to go back to the menu or exit? \nMenu/Exit");

                    switch (Console.ReadLine().ToLower())
                    {
                        case "menu":
                            Console.Clear();
                            Menu(options);
                            break;
                        case "exit":
                            Environment.Exit(0);
                            break;
                        default:
                            Environment.Exit(0);
                            break;
                    }

                    break;
                case "no":
                    Console.WriteLine("\nThe video was not deleted!");
                    Console.WriteLine("\nWould you like to go back to the menu or exit? \nMenu/Exit");

                    switch (Console.ReadLine().ToLower())
                    {
                        case "menu":
                            Console.Clear();
                            Menu(options);
                            break;
                        case "exit":
                            Environment.Exit(0);
                            break;
                        default:
                            Environment.Exit(0);
                            break;
                    }
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }

        }
        #endregion

        #region Create
        private static void CreateVideo()
        {
            Console.Clear();
            Console.WriteLine("You chose to create a video! " +
                "\nPlease input the name of the video: ");

            string name = Console.ReadLine().Trim();
            Char[] array = name.ToCharArray();
            foreach (Char letter in array)
            {
                if(!Char.IsLetter(letter))
                {
                    Console.WriteLine("\nPlease input a name without special characters or numbers." +
                        "\nWould you like to try again?" +
                        "\nYes/No");

                    switch(Console.ReadLine().ToLower())
                    {
                        case "yes":
                            Console.Clear();
                            CreateVideo();
                            break;
                        case "no":
                            Menu(options);
                            break;
                        default:
                            Environment.Exit(0);
                            break;
                    }
                    
                }
            }

            Console.WriteLine("\nInput date of release: (dd/MM/yyyy)");
            string date = Console.ReadLine();
            DateTime dt = Convert.ToDateTime(date);

            Console.WriteLine("\nInput storyline:");
            string storyLine = Console.ReadLine();

            try
            {
                bll.CreateVideo(name, dt, storyLine);

                Console.WriteLine("\n----------------------------------------" +
                "\nVideo Created!" +
                "\nYou input:");

                Console.WriteLine($"\nName: {name}" +
                    $"\nDate of release: {date}" +
                    $"\nStoryline: {storyLine}");

                Console.WriteLine("\nWould you like to go back to the menu or exit? \nMenu/Exit");

                switch (Console.ReadLine().ToLower())
                {
                    case "menu":
                        Console.Clear();
                        Menu(options);
                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("\n----------------------------------------" +
                        "\nVideo Creation Failed!" +
                        "\nWould you like to try again?" +
                        "\nYes/No");

                switch (Console.ReadLine().ToLower())
                {
                    case "yes":
                        Console.Clear();
                        CreateVideo();
                        break;
                    case "no":
                        Menu(options);
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }

                Console.WriteLine(ex.Message);
            }

        }
        #endregion
    }
}

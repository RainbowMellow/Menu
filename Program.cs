using System;
using System.Collections.Generic;

namespace Menu
{
    class Program
    {
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
            throw new NotImplementedException();
        }
        #endregion

        #region VideoList
        private static void VideoList()
        {
            Console.Clear();
            Console.WriteLine("You chose to see the list of videos! " +
                "\nList of videos: \n");

            List<string> videos = new List<string>{
                "Funny dog haha, (02/21/20), It's a funny dog",
                "Funny cat haha, (05/24/20), It's a funny cat",
                "Funny mouse haha, (07/22/20), It's a funny mouse",

            };

            foreach (string video in videos)
            {
                Console.WriteLine(video);
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
        }
        #endregion

        #region Delete
        private static void DeleteVideo()
        {
            Console.Clear();
            Console.WriteLine("You chose to delete a video! " +
                "\nInput the name of the video you want to delete: \n");

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

            Console.WriteLine($"\nAre you sure you want to delete {name}?" +
                "\nYes/No");

            switch (Console.ReadLine().ToLower())
            {
                case "yes":
                    Console.WriteLine("\nThe video was deleted!");
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

            Console.WriteLine("\nInput date of release: (MM/dd/yy)");
            string date = Console.ReadLine();

            Console.WriteLine("\nInput storyline:");
            string storyLine = Console.ReadLine();

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
        #endregion
    }
}

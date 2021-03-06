﻿using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MicrowaveApplicatie
{
    internal class Microwave
    {
        public bool State;


        private async void Blink(bool test)
        {
            while (State)
            {
                // Wait half a second
                await Task.Delay(500);

                // Blink label
                if (MainWindow.Main.Label.Foreground.Opacity == 0)
                    MainWindow.Main.Label.Foreground.Opacity = 1;
                else
                    MainWindow.Main.Label.Foreground.Opacity = 0;
            }
            
        }

        public void OpenDoor()
        {
            State = true;
            // Stop previous mediaPlayer
            MainWindow.Main.MediaPlayerClose.Close();
            // Blink label
            Blink(true);
            
            // Change button text to close
            MainWindow.Main.DoorButton.Content = "Close"; 
            // Hide the previous mediaplayer and unhide the new mediaplayer, in this case MediaPlayerOpen
            MainWindow.Main.MediaPlayerOpen.Visibility = Visibility.Visible;
            MainWindow.Main.MediaPlayerClose.Visibility = Visibility.Hidden;
            // Start MediaPlayerOpen
            MainWindow.Main.MediaPlayerOpen.Play();
            
        }

        public void CloseDoor()
        {
            
            Blink(false);
            State = false;
            MainWindow.Main.MediaPlayerOpen.Close();
            MainWindow.Main.MediaPlayerOpen.Visibility = Visibility.Hidden;
            MainWindow.Main.MediaPlayerClose.Visibility = Visibility.Visible;
            MainWindow.Main.MediaPlayerClose.Play();
            MainWindow.Main.DoorButton.Content = "Open";
            MainWindow.Main.Label.Foreground.Opacity = 1;


        }
    }
}
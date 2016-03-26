﻿namespace TriviaGoldMine.Client.Views
{
    using System.IO;
    using System.Windows;

    using ViewModels;

    public partial class PowerPointController
    {
        public PowerPointController()
        {
            this.InitializeComponent();
        }

        private void PowerPoint_OnDrop(object sender, DragEventArgs e)
        {
            var droppedFilenames = e.Data.GetData(DataFormats.FileDrop, true) as string[];
            (this.DataContext as Mp3PlayerViewModel).AddSongs(droppedFilenames);
        }

        private void PowerPoint_OnDragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
            {
                var filenames = e.Data.GetData(DataFormats.FileDrop, true) as string[];

                foreach (string filename in filenames)
                {
                    if (Path.GetExtension(filename)?.ToLower() != ".mp3")
                    {
                        e.Effects = DragDropEffects.None;
                        e.Handled = true;
                        break;
                    }
                }
            }
            else
            {
                e.Effects = DragDropEffects.None;
                e.Handled = true;
            }
        }
    }
}
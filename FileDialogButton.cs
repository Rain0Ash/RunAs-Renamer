// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RunAsRenamer
{
    public sealed class FileDialogButton : Button
    {
        private readonly TextBox linkedTextBox;
        private readonly OpenFileDialog openFileDialog = new OpenFileDialog(){
            Multiselect = false,
            Filter = @"icon | *.ico",
            InitialDirectory = Directory.GetCurrentDirectory(),
            Title = @"Selecting icon"
        };
        public FileDialogButton(ref TextBox button)
        {
            linkedTextBox = button;
            Text = @"...";
            TextAlign = ContentAlignment.MiddleCenter;
            linkedTextBox.TextChanged += (sender, args) =>
                openFileDialog.InitialDirectory = Directory.Exists(linkedTextBox.Text)
                    ? linkedTextBox.Text
                    : Directory.GetCurrentDirectory();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            openFileDialog.InitialDirectory = Directory.Exists(linkedTextBox.Text)
                ? linkedTextBox.Text
                : Directory.GetCurrentDirectory();
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                linkedTextBox.Text = openFileDialog.FileName;
            }
        }
    }
}
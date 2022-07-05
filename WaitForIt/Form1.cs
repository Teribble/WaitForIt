﻿using System;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace WaitForIt
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Ответ на загадку
        /// </summary>
        private string str = "Ну, Погоди!";
        /// <summary>
        /// Основная музыка
        /// </summary>
        SoundPlayer gameMusic = new SoundPlayer(@"C:\VisualStudio\WaitForIt\WaitForIt\Music\music.wav");
        /// <summary>
        /// Звук выйгрыша
        /// </summary>
        SoundPlayer victoryMusic = new SoundPlayer(@"C:\VisualStudio\WaitForIt\WaitForIt\Music\vic.wav");
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            textBox1.Visible = false;
            pictureBox5.Visible = false;
            button1.Visible = false;
        }
        /// <summary>
        /// Действия, пока курсор двигается на Panel1
        /// </summary>
        private void OnPanel1MouseMove(object sender, MouseEventArgs e)
        {
            label3.Text = e.X.ToString();
            label4.Text = e.Y.ToString();
        }
        /// <summary>
        /// Действия, в случае, когда курсор покинул Panel1
        /// </summary>
        private void OnPanel1MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
            label5.Visible = true;
            label6.Visible = true;
            textBox1.Visible = true;
        }
        /// <summary>
        /// Действия в случае, когда курсор входит в видимую область TextBox1
        /// </summary>
        private void OnTextBox1MouseEnter(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
        /// <summary>
        /// Действия, при нажатии на Button1
        /// </summary>
        private void OnButton1Click(object sender, EventArgs e)
        {
            gameMusic.Stop();
            if (!victoryMusic.IsLoadCompleted)
            {
                victoryMusic.Play();
            }
            pictureBox5.Visible = true;
            textBox1.Clear();
            MessageBox.Show("Ты выйграл", "Победа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            pictureBox5.Visible = false;
            button2.Visible = true;
            button1.Visible = false; 
        }
        /// <summary>
        /// Действия, при наведении курсора мыши на Button1
        /// </summary>
        private void OnButton1MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;


            if (string.IsNullOrEmpty(textBox1.Text) || textBox1.Text != str)
            {
                int minWidth = panel1.Location.X + (button1.Width + button1.Width);
                int minHeight = panel1.Location.Y + (button1.Height + button1.Height);

                int maxWidth = minWidth + panel1.Width - (button1.Width + button1.Width);
                int maxHeigh = minHeight + panel1.Height - (button1.Height + button1.Height);

                Random r = new Random();

                int width = r.Next(minWidth, maxWidth);
                int height = r.Next(minHeight, maxHeigh);

                do
                {
                    width = r.Next(minWidth, maxWidth);
                    width -= button1.Width;
                }
                while (width > maxWidth || width < minWidth);
                
                do
                {
                    height = r.Next(minHeight, maxHeigh);
                    height -= button1.Height;
                }
                while (height > maxHeigh || height < minHeight);

                button1.Location = new System.Drawing.Point(width, height);
            }
        }
        /// <summary>
        /// Действия, при клики мыши на Button2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            OnButton1MouseMove(null, null);
            button2.Visible = false;
            if (!gameMusic.IsLoadCompleted)
            {
                gameMusic.PlayLooping();
            } 
        }
    }
}

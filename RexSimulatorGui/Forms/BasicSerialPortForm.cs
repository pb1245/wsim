﻿/*
########################################################################
# This file is part of wsim, a WRAMP simulator.
#
# Copyright (C) 2016 Paul Monigatti
# Copyright (C) 2019 The University of Waikato, Hamilton, New Zealand.
#
# This program is free software: you can redistribute it and/or modify
# it under the terms of the GNU General Public License as published by
# the Free Software Foundation, either version 3 of the License, or
# (at your option) any later version.
#
# This program is distributed in the hope that it will be useful,
# but WITHOUT ANY WARRANTY; without even the implied warranty of
# MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
# GNU General Public License for more details.
#
# You should have received a copy of the GNU General Public License
# along with this program.  If not, see <https://www.gnu.org/licenses/>.
########################################################################
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RexSimulator.Hardware.Rex;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Media;
using RexSimulatorGui.Properties;

namespace RexSimulatorGui.Forms
{
    public partial class BasicSerialPortForm : Form
    {
        #region Defines
        private const int NUM_COLS = 100;
        private const int NUM_ROWS = 32;
        #endregion

        #region Member Vars
        private SerialIO mSerialPort;
        private Thread mUploadFileWorker;
        private StringBuilder mRecvBuffer;
        private char[,] mScreenBuffer;
        private int mCX, mCY;

        private bool mCursorOn = false; //for blinking cursor
        private bool mCursorEnabled = true; //TODO: cursor on by default
        private bool mTypeLoadAuto = true; // to not require typing "load" at the start of every file loading.
        private bool mQuickLoadEnabled = true;

        private string mEscapeSequence = null;
        private string mLastFileName = null;
        private RexSimulatorGui.Forms.RexBoardForm mRexBoardForm;
        #endregion

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="port">The Serial device to communicate with.</param>
        public BasicSerialPortForm(SerialIO port, RexSimulatorGui.Forms.RexBoardForm  rexBoardForm)
        {
            InitializeComponent();
            this.mSerialPort = port;
            this.Text = mSerialPort.Name;
            this.mRexBoardForm = rexBoardForm;

            mRecvBuffer = new StringBuilder();
            mScreenBuffer = new char[NUM_ROWS, NUM_COLS];
            mCX = mCY = 0;
            ClearScreen();

            serialLabel.AllowDrop = true;
            serialLabel.DragDrop += new DragEventHandler(serialLabel_DragDrop);
            serialLabel.DragEnter += new DragEventHandler(serialLabel_DragEnter);

            resendFileToolStripMenuItem.Enabled = false;

            mSerialPort.SerialDataTransmitted += new EventHandler<SerialIO.SerialEventArgs>(mSerialPort_SerialDataTransmitted);
            updateTimer.Start();
        }

        #region Private Methods
        /// <summary>
        /// Moves everything on the device up one line.
        /// </summary>
        private void MoveUp()
        {
            //shift everything up
            for (int i = 0; i < NUM_ROWS - 1; i++)
            {
                for (int j = 0; j < NUM_COLS; j++)
                {
                    mScreenBuffer[i, j] = mScreenBuffer[i + 1, j];
                }
            }

            for (int i = 0; i < NUM_COLS; i++)
                mScreenBuffer[NUM_ROWS - 1, i] = ' ';

            while (mCY >= NUM_ROWS)
            {
                mCY--;
            }
        }

        /// <summary>
        /// Clears the screen buffer.
        /// </summary>
        private void ClearScreen()
        {
            for (int i = 0; i < NUM_ROWS; i++)
            {
                for (int j = 0; j < NUM_COLS; j++)
                {
                    mScreenBuffer[i, j] = ' ';
                }
            }
        }

        /// <summary>
        /// Sets whether the cursor is visible or not.
        /// </summary>
        /// <param name="visible">True for the cursor to be visible.</param>
        private void SetCursorVisible(bool visible)
        {
            mCursorEnabled = visible;
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Show the drag and drop copy cursor when appropriate.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void serialLabel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// Process dropping files to the serial port.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void serialLabel_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length == 1)
                {
                    try
                    {
                        mUploadFileWorker = new Thread(new ParameterizedThreadStart(UploadFileWorker));
                        mUploadFileWorker.Start(files[0]);
                    }
                    catch
                    {
                    }
                }
            }
        }

        /// <summary>
        /// Override the default closing behaviour. Rather than close the form, simply hide it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerialPortForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void UploadFileDialog()
        {
            if (mUploadFileWorker != null && mUploadFileWorker.ThreadState == System.Threading.ThreadState.Running)
                mUploadFileWorker.Abort();

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "SREC File|*.srec|All Files|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                mUploadFileWorker = new Thread(new ParameterizedThreadStart(UploadFileWorker));
                mUploadFileWorker.Start(dlg.FileName);
                mLastFileName = dlg.FileName;
                resendFileToolStripMenuItem.Enabled = true;
            }
        }

        /// <summary>
        /// Upload a file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UploadFileDialog();
        }

        /// <summary>
        /// Re-upload the file. Use mLastFile as the file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resendFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mUploadFileWorker = new Thread(new ParameterizedThreadStart(UploadFileWorker));
            mUploadFileWorker.Start(mLastFileName);
        }

        /// <summary>
        /// Transmit a keypress to the board.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serialTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (Control.ModifierKeys == Keys.Control)
            {
                UploadFileDialog();
            }
            else
            {
                mSerialPort.SendAsync(e.KeyChar);
            }
        }

        /// <summary>
        /// Receive a character from the board.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void mSerialPort_SerialDataTransmitted(object sender, SerialIO.SerialEventArgs e)
        {
            lock (mRecvBuffer)
            {
                //mSerialPort.AckRecv();
                mRecvBuffer.Append((char)e.Data);
            }
        }

        /// <summary>
        /// Update the GUI to reflect recent changes in state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateTimer_Tick(object sender, EventArgs e)
        {
            string s;
            lock (mRecvBuffer)
            {
                s = mRecvBuffer.ToString();
                mRecvBuffer.Remove(0, mRecvBuffer.Length);
            }

            foreach (char c in s)
            {
                switch (c)
                {
                    case (char)0x07:
                        SoundPlayer sp = new SoundPlayer(Resources.duck_quack);
                        sp.Play();
                        break;

                    case '\r':
                        mCX = 0;
                        break;

                    case '\n':
                        mCX = 0;
                        mCY++;
                        break;

                    case '\b':
                        if(mCX > 0){
                            mCX--;
                            mScreenBuffer[mCY, mCX] = ' ';
                        }
                        break;

                    case (char)0x1b: //ASCII escape character
                        Debug.Assert(mEscapeSequence == null, "Incorrectly processed escape sequence!\r\n" + mEscapeSequence);
                        mEscapeSequence = ""; //begin reading
                        break;

                    default:
                        if (' ' <= c && c <= '~') //all printable characters
                        {
                            if (mEscapeSequence != null)
                            {
                                mEscapeSequence += c;
                            }
                            else
                            {
                                mScreenBuffer[mCY, mCX++] = c;
                            }
                        }
                        else
                        {
                            Debug.WriteLine("Unknown Character!");
                        }
                        break;
                }

                if (mEscapeSequence != null)
                {
                    //check if the escape sequence is valid
                    Debug.WriteLine("esc");
                    if (mEscapeSequence == "[2J") //clear screen
                    {
                        ClearScreen();
                        mEscapeSequence = null;
                    }
                    else if (mEscapeSequence == "[H") //go to home location
                    {
                        mCX = mCY = 0;
                        mEscapeSequence = null;
                    }
                    else if(mEscapeSequence.Contains(';') && mEscapeSequence.EndsWith("H")) //go to XY co-ordinate
                    {
                        string[] split = mEscapeSequence.Split(new char[] { '[', ';', 'H' }, StringSplitOptions.RemoveEmptyEntries);
                        try
                        {
                            int x = int.Parse(split[1]);
                            int y = int.Parse(split[0]);

                            mCX = Math.Min(Math.Max(0, x), NUM_COLS) - 1;
                            mCY = Math.Min(Math.Max(0, y), NUM_ROWS) - 1;

                            if (mCX < 0)
                                mCX = 0;
                            if (mCX >= NUM_COLS)
                                mCX = NUM_COLS;
                            if (mCY < 0)
                                mCY = 0;
                            if (mCY >= NUM_ROWS)
                                mCY = NUM_ROWS;
                        }
                        catch { }
                        mEscapeSequence = null;
                    }
                    else if (mEscapeSequence == "[?25l") //cursor off
                    {
                        SetCursorVisible(false);
                        mEscapeSequence = null;
                    }
                    else if (mEscapeSequence.Length > 10)
                    {
                        MessageBox.Show("Warning - the serial port received an invalid / unsupported ASCII escape sequence.", "Invalid Escape Sequence", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        mEscapeSequence = null;
                    }
                }
               
                if (mCX >= NUM_COLS)
                {
                    mCY++;
                    mCX = 0;
                }
                if (mCY >= NUM_ROWS)
                {
                    MoveUp();
                }
                Debug.Assert(0 <= mCX && mCX < NUM_COLS);
                Debug.Assert(0 <= mCY && mCY < NUM_ROWS);
            }
            
            //Convert screen buffer into actual text
            if (mCursorEnabled)
                mCursorOn ^= true;
            else
                mCursorOn = false;

            StringBuilder screen = new StringBuilder();
            for (int y = 0; y < NUM_ROWS; y++)
            {
                StringBuilder line = new StringBuilder();
                for (int x = 0; x < NUM_COLS; x++)
                {
                    if (x == mCX && y == mCY && mCursorOn)
                    {
                        line.Append('_');
                    }
                    else
                    {
                        line.Append(mScreenBuffer[y, x]);
                    }
                        
                }
                screen.AppendLine(line.ToString());
            }

            SetText(screen.ToString(), serialLabel);
        }
        #endregion

        #region Cross-thread Stuff
        delegate void SetTextCallback(string s, Label box);
        /// <summary>
        /// Sets text to the label in a thread-safe manner.
        /// </summary>
        /// <param name="s">The text to append.</param>
        /// <param name="box">The label to set the text of.</param>
        private void SetText(string s, Label box)
        {
            if (this.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, s, box);
            }
            else
            {
                box.Text = s;
            }
        }
        #endregion

        #region Thread Workers

        /// <summary>
        /// Sends a file through the serial port.
        /// </summary>
        private void UploadFileWorker(object parameter)
        {
            if(mQuickLoadEnabled)
            {
                mRexBoardForm.QuickUploadSrec(this, (string)parameter);
                foreach(char c in "load\n")
                {
                    mSerialPort.Send(c);
                    Thread.Sleep(10);
                }

                StreamReader r = new StreamReader((string)parameter);
                while(!r.EndOfStream)
                {
                    string line = r.ReadLine();
                    // Just send the start address record the slow way.
                    if(line.StartsWith("S7"))
                    {
                        foreach(char c in line)
                        {
                            mSerialPort.Send(c);
                            Thread.Sleep(10);
                        }
                        mSerialPort.Send('\n');
                    }
                }
                r.Close();
            }
            else 
            {
                StreamReader r = new StreamReader((string)parameter);

                if(mTypeLoadAuto)
                {
                    foreach(char c in "load\n")
                    {
                        mSerialPort.Send(c);
                        Thread.Sleep(10); // give time for BASYS board to be ready to recieve
                    }
                }

                while (!r.EndOfStream)
                {
                    string line = r.ReadLine();
                    for (int i = 0; i < line.Length; i++)
                    {
                        mSerialPort.Send(line[i]);
                    }
                    mSerialPort.Send('\n');
                }
                r.Close();
            }

        }

        private void autoloadDisabledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(autoloadDisabledToolStripMenuItem.Text == "Autoload Disabled")
            {
                autoloadDisabledToolStripMenuItem.Text = "Autoload Enabled";
                mTypeLoadAuto = true;
            }
            else if(autoloadDisabledToolStripMenuItem.Text == "Autoload Enabled")
            {
                autoloadDisabledToolStripMenuItem.Text = "Autoload Disabled";
                mTypeLoadAuto = false;
            }
        }

        private void quickloadDisabledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(quickLoadDisabledToolStripMenuItem.Text == "Quickload Disabled")
            {
                quickLoadDisabledToolStripMenuItem.Text = "Quickload Enabled";
                mQuickLoadEnabled = true;
            }
            else if(quickLoadDisabledToolStripMenuItem.Text == "Quickload Enabled")
            {
                quickLoadDisabledToolStripMenuItem.Text = "Quickload Disabled";
                mQuickLoadEnabled = false;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// If the main program closes, the worker thread need to be killed as well.
        /// </summary>
        public void KillWorkers()
        {
            if (mUploadFileWorker != null && mUploadFileWorker.ThreadState == System.Threading.ThreadState.Running)
                mUploadFileWorker.Abort();
        }
        #endregion
    }
}

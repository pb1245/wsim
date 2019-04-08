using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using RexSimulator.Hardware.Rex;
using System.Threading;

namespace RexSimulatorGui.Forms
{
    public class StateObject
    {
        // Client socket.  
        public Socket workSocket = null;
        // Size of receive buffer.  
        public const int BufferSize = 256;
        // Receive buffer.  
        public byte[] buffer = new byte[BufferSize];
        // Received data string.  
        public StringBuilder sb = new StringBuilder();
    }

    public partial class SerialSettingForm : Form
    {

        SerialIO mSp1, mSp2;
        TcpListener sp1Listener, sp2Listener;
        Socket sp1Socket, sp2Socket;
        StringBuilder mRecvBufferSp1, mRecvBufferSp2;
        bool mProcessSp1, mProcessSp2;
        static ManualResetEvent sendDone = new ManualResetEvent(false);
        static ManualResetEvent receiveDone = new ManualResetEvent(false);
        static string response;
        System.Timers.Timer mUpdateTimer;

        public SerialSettingForm(SerialIO sp1, SerialIO sp2)
        {
            InitializeComponent();
            mSp1 = sp1;
            mSp2 = sp2;
            mRecvBufferSp1 = new StringBuilder();
            mRecvBufferSp2 = new StringBuilder();

            mSp1.SerialDataTransmitted += new EventHandler<SerialIO.SerialEventArgs>(mSerialPort_SerialDataTransmitted);
            mSp2.SerialDataTransmitted += new EventHandler<SerialIO.SerialEventArgs>(mSerialPort_SerialDataTransmitted);

            FormClosing += SerialSettingForm_FormClosing;
            sp1EnableCheckBox.CheckedChanged += Sp1EnableCheckBox_CheckedChanged;
            sp2EnableCheckBox.CheckedChanged += Sp2EnableCheckBox_CheckedChanged;

            mUpdateTimer = new System.Timers.Timer
            {
                Interval = 50
            };
            mUpdateTimer.Elapsed += MUpdateTimer_Elapsed;
            mUpdateTimer.Start();
        }

        private void MUpdateTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (sp1Socket != null)
            {
                lock (mRecvBufferSp1)
                {
                    string s = mRecvBufferSp1.ToString();
                    if (s.Length > 0)
                    {
                        Send(sp1Socket, s);
                        mRecvBufferSp1.Remove(0, mRecvBufferSp1.Length);
                    }
                }
            }

            if (sp2Socket != null)
            {
                lock (mRecvBufferSp2)
                {
                    string s = mRecvBufferSp2.ToString();
                    if (s.Length > 0)
                    {
                        Send(sp2Socket, s);
                        mRecvBufferSp2.Remove(0, mRecvBufferSp2.Length);
                    }
                }
            }
        }

        void mSerialPort_SerialDataTransmitted(object sender, SerialIO.SerialEventArgs e)
        {
            if ((sender as SerialIO).Name == "Serial Port 1")
            {
                lock (mRecvBufferSp1)
                {
                    //mSerialPort.AckRecv();
                    //Send(sp1Socket, ((char)e.Data).ToString());
                    mRecvBufferSp1.Append((char)e.Data);
                }
            }
            else if ((sender as SerialIO).Name == "Serial Port 2")
            {
                lock (mRecvBufferSp2)
                {
                    //mSerialPort.AckRecv();
                    //Send(sp2Socket, ((char)e.Data).ToString());
                    mRecvBufferSp2.Append((char)e.Data);
                }
            }
        }

        private static void Send(Socket client, String data)
        {
            // Convert the string data to byte data using ASCII encoding.  
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.  
            client.BeginSend(byteData, 0, byteData.Length, SocketFlags.None,
                new AsyncCallback(SendCallback), client);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = client.EndSend(ar);
                System.Diagnostics.Debug.WriteLine("Sent {0} bytes to server.", bytesSent);

                // Signal that all bytes have been sent.  
                sendDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void SerialSettingForm_Load(object sender, EventArgs e)
        {

        }

        private void Sp1EnableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            mProcessSp1 = sp1EnableCheckBox.Checked;
            if (mProcessSp1)
            {
                sp1Listener = new TcpListener(IPAddress.Parse("0.0.0.0"), (int)sp1PortNum.Value);
                sp1Listener.Start();
                sp1Socket = sp1Listener.AcceptSocket();
                MessageBox.Show("Got client!");
            }
            else
            {
                sp1Listener.Stop();
                if (sp1Socket != null)
                    sp1Socket.Dispose();
            }
        }

        private void Sp2EnableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            mProcessSp2 = sp2EnableCheckBox.Checked;
            if (mProcessSp2)
            {
                sp2Listener = new TcpListener(IPAddress.Parse("0.0.0.0"), (int)sp2PortNum.Value);
                sp2Listener.Start();
                sp2Socket = sp2Listener.AcceptSocket();
            }
            else
            {
                sp2Listener.Stop();
                if (sp2Socket != null)
                    sp2Socket.Dispose();
            }
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the state object and the client socket   
                // from the asynchronous state object.  
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;
                // Read data from the remote device.  
                int bytesRead = client.EndReceive(ar);
                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.  
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                    //  Get the rest of the data.  
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                }
                else
                {
                    // All the data has arrived; put it in response.  
                    if (state.sb.Length > 1)
                    {
                        response = state.sb.ToString();
                        System.Diagnostics.Debug.WriteLine(response);
                    }
                    // Signal that all bytes have been received.  
                    receiveDone.Set();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void Receive(Socket client)
        {
            try
            {
                // Create the state object.  
                StateObject state = new StateObject();
                state.workSocket = client;

                // Begin receiving the data from the remote device.  
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void SerialSettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}

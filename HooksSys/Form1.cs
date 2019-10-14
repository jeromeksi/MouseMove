using System;
using System.Drawing;
using System.Windows.Forms;

namespace HooksSys
{
    public partial class Form1 : Form
    {
        private KeyHandler ghk;
        
        private Point hg_w1=new Point(-1,-1);
        private Point hg_w2=new Point(-1,-1);
        public Form1()
        {
            InitializeComponent();
            ghk = new KeyHandler(Constants.CTRL,Keys.R, this);
            ghk.Register();
        }
        private void HandleHotkey()
        {
            if(hg_w1.X == -1)
            {
                hg_w1 = Cursor.Position;
            }
            else if (hg_w2.X == -1)
            {
                hg_w2 = Cursor.Position;
            }          
            else
            {
                var currentPos = Cursor.Position;
                Cursor.Position = new Point(currentPos.X +(hg_w2.X-hg_w1.X), currentPos.Y);
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);

                Cursor.Position = currentPos;

                //MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
                //MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
                HandleHotkey();
            base.WndProc(ref m);
        }
    }
}

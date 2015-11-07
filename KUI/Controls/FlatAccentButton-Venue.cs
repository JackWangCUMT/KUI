﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KUI.Controls
{
    public class FlatAccentButton : FlatButton
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(
                MouseOver ? Theme.ForeBrush : Theme.AccentBrush, ClientRectangle);

            SizeF textSize = e.Graphics.MeasureString(Text, Theme.BodyFont);
            e.Graphics.DrawString(Text, Theme.BodyFont, Theme.FontBrush, 
                Width / 2 - textSize.Width / 2, Height / 2 - textSize.Height / 2);
        }

        public override void DrawShadow(Graphics g)
        {
            if (HasShadow)
            {
                for (int i = 0; i < ShadowLevel; i++)
                {
                    g.DrawRectangle(
                        new Pen(Theme.AccentColor.Shade(Theme.ShadowSize, i)),
                        ShadeRect(i));
                }
            }
        }
    }
}
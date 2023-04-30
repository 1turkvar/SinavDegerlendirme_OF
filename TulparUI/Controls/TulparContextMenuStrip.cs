﻿using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using TulparUI.Animations;

namespace TulparUI.Controls
{
    [ToolboxItem(false)]

    public class TulparContextMenuStrip : ContextMenuStrip, ITulparControl
    {
        //Properties for managing the material design properties
        [Browsable(false)]
        public int Depth { get; set; }

        [Browsable(false)]
        public TulparSkinManager SkinManager => TulparSkinManager.Instance;

        [Browsable(false)]
        public MouseState MouseState { get; set; }

        internal AnimationManager AnimationManager;

        internal Point AnimationSource;

        public delegate void ItemClickStart(object sender, ToolStripItemClickedEventArgs e);

        public event ItemClickStart OnItemClickStart;

        public TulparContextMenuStrip()
        {
            Renderer = new TulparToolStripRender();

            AnimationManager = new AnimationManager(false)
            {
                Increment = 0.07,
                AnimationType = AnimationType.Linear
            };
            AnimationManager.OnAnimationProgress += sender => Invalidate();
            AnimationManager.OnAnimationFinished += sender => OnItemClicked(_delayesArgs);

            BackColor = SkinManager.BackdropColor;
        }

        protected override void OnMouseUp(MouseEventArgs mea)
        {
            base.OnMouseUp(mea);

            AnimationSource = mea.Location;
        }

        private ToolStripItemClickedEventArgs _delayesArgs;

        protected override void OnItemClicked(ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem != null && !(e.ClickedItem is ToolStripSeparator))
            {
                if (e == _delayesArgs)
                {
                    //The event has been fired manualy because the args are the ones we saved for delay
                    base.OnItemClicked(e);
                }
                else
                {
                    //Interrupt the default on click, saving the args for the delay which is needed to display the animaton
                    _delayesArgs = e;

                    //Fire custom event to trigger actions directly but keep cms open
                    OnItemClickStart?.Invoke(this, e);

                    //Start animation
                    AnimationManager.StartNewAnimation(AnimationDirection.In);
                }
            }
        }
    }

    public class TulparToolStripMenuItem : ToolStripMenuItem
    {
        public TulparToolStripMenuItem()
        {
            AutoSize = false;
            Size = new Size(128, 32);
        }

        protected override ToolStripDropDown CreateDefaultDropDown()
        {
            var baseDropDown = base.CreateDefaultDropDown();
            if (DesignMode) return baseDropDown;

            var defaultDropDown = new TulparContextMenuStrip();
            defaultDropDown.Items.AddRange(baseDropDown.Items);

            return defaultDropDown;
        }
    }

    internal class TulparToolStripRender : ToolStripProfessionalRenderer, ITulparControl
    {
        private const int LEFT_PADDING = 16;
        private const int RIGHT_PADDING = 8;

        //Properties for managing the material design properties
        public int Depth { get; set; }

        public TulparSkinManager SkinManager => TulparSkinManager.Instance;

        public MouseState MouseState { get; set; }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            var g = e.Graphics;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            var itemRect = GetItemRect(e.Item);
            var textRect = new Rectangle(LEFT_PADDING, itemRect.Y, itemRect.Width - (LEFT_PADDING + RIGHT_PADDING), itemRect.Height);

            using (NativeTextRenderer NativeText = new NativeTextRenderer(g))
            {
                NativeText.DrawTransparentText(e.Text, SkinManager.GetLogFontByType(TulparSkinManager.FontType.Body2),
                    e.Item.Enabled ? SkinManager.TextHighEmphasisColor : SkinManager.TextDisabledOrHintColor,
                    textRect.Location,
                    textRect.Size,
                    NativeTextRenderer.TextAlignFlags.Left | NativeTextRenderer.TextAlignFlags.Middle);
            }
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(SkinManager.BackgroundColor);

            //Draw background
            var itemRect = GetItemRect(e.Item);
            g.FillRectangle(e.Item.Selected && e.Item.Enabled ? SkinManager.BackgroundFocusBrush : SkinManager.BackgroundBrush, itemRect);

            //Ripple animation
            var toolStrip = e.ToolStrip as TulparContextMenuStrip;
            if (toolStrip != null)
            {
                var animationManager = toolStrip.AnimationManager;
                var animationSource = toolStrip.AnimationSource;
                if (toolStrip.AnimationManager.IsAnimating() && e.Item.Bounds.Contains(animationSource))
                {
                    for (int i = 0; i < animationManager.GetAnimationCount(); i++)
                    {
                        var animationValue = animationManager.GetProgress(i);
                        var rippleBrush = new SolidBrush(Color.FromArgb((int)(51 - (animationValue * 50)), Color.Black));
                        var rippleSize = (int)(animationValue * itemRect.Width * 2.5);
                        g.FillEllipse(rippleBrush, new Rectangle(animationSource.X - rippleSize / 2, itemRect.Y - itemRect.Height, rippleSize, itemRect.Height * 3));
                    }
                }
            }
        }

        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
        }

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            var g = e.Graphics;

            g.FillRectangle(SkinManager.BackgroundBrush, e.Item.Bounds);
            g.DrawLine(
                new Pen(SkinManager.DividersColor),
                new Point(e.Item.Bounds.Left, e.Item.Bounds.Height / 2),
                new Point(e.Item.Bounds.Right, e.Item.Bounds.Height / 2));
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            e.ToolStrip.BackColor = SkinManager.BackgroundColor;
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            var g = e.Graphics;
            const int ARROW_SIZE = 4;

            var arrowMiddle = new Point(e.ArrowRectangle.X + e.ArrowRectangle.Width / 2, e.ArrowRectangle.Y + e.ArrowRectangle.Height / 2);
            var arrowBrush = e.Item.Enabled ? SkinManager.TextHighEmphasisBrush : SkinManager.TextDisabledOrHintBrush;
            using (var arrowPath = new GraphicsPath())
            {
                arrowPath.AddLines(
                    new[] {
                        new Point(arrowMiddle.X - ARROW_SIZE, arrowMiddle.Y - ARROW_SIZE),
                        new Point(arrowMiddle.X, arrowMiddle.Y),
                        new Point(arrowMiddle.X - ARROW_SIZE, arrowMiddle.Y + ARROW_SIZE) });
                arrowPath.CloseFigure();

                g.FillPath(arrowBrush, arrowPath);
            }
        }

        private Rectangle GetItemRect(ToolStripItem item)
        {
            return new Rectangle(0, item.ContentRectangle.Y, item.ContentRectangle.Width, item.ContentRectangle.Height);
        }
    }
}

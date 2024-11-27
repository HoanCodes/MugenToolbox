using Avalonia.Controls;
using Avalonia.Input;
using System;

namespace IkemenToolbox.Controls
{
    internal class ImprovedListBox : ListBox
    {
        public ImprovedListBox()
        {
            PointerPressed += OnItemPressed;
        }

        private async void OnItemPressed(object sender, PointerPressedEventArgs e)
        {
            if (sender is not ListBoxItem item)
            {
                return;
            }

            var mousePos = e.GetPosition(this);
            //var ghostPos = GhostItem.Bounds

            var result = await DragDrop.DoDragDrop(e, new DataObject(), DragDropEffects.Move);
        }
    }
}
using System.Windows.Forms;

namespace LoveVision
{
    public static class ListBoxExtension
    {
        public static void AddItemThreadSafe(this ListBox lb, object item)
        {
            if (lb.InvokeRequired)
            {
                lb.Invoke(new MethodInvoker(delegate
                {
                    lb.Items.Add(item);
                    lb.SelectedIndex = lb.Items.Count - 1;
                }));
            }
            else
            {
                lb.Items.Add(item);
                lb.SelectedIndex = lb.Items.Count - 1;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using MetroFramework.Forms;
using System.Windows.Forms;
using ARC_Studio.Workers;

namespace ARC_Studio.Forms
{
    public partial class LOCEditor : MetroForm
	{

		string openedloc = "";
		int lastselect = 0;

		public LOCEditor(string localise)
        {
            InitializeComponent();
			openedloc = localise;
            LanguagesParser languagesParser = new LanguagesParser();
            languagesContainer_0 = languagesParser.Parse(localise);
            method_5();
            method_4(languagesContainer_0);

        }

		private void tbMessage_TextChanged(object sender, global::System.EventArgs e)
		{
			if (messageEntry_0 != null)
			{
				messageEntry_0.Message = tbMessage.Text;
			}
		}

		private void method_5()
		{
			messageEntry_0 = null;
			tbMessage.Clear();
		}

		private void method_4(LanguagesContainer languagesContainer_1)
		{
			foreach (string text in languagesContainer_1.Languages.Keys)
			{
				ListViewItem listViewItem = new ListViewItem(text);
				listViewItem.Tag = languagesContainer_1.Languages[text];
				duohnRabql.Items.Add(listViewItem);
			}
		}


		private void method_6(global::System.Collections.Generic.List<MessageEntry> list_0)
		{
			lvMessages.Items.Clear();
			int num = 1;
			foreach (MessageEntry messageEntry in list_0)
			{
				ListViewItem listViewItem = new ListViewItem(num.ToString());
				listViewItem.Tag = messageEntry;
				listViewItem.SubItems.Add(messageEntry.Message);
				lvMessages.Items.Add(listViewItem);
				num++;
			}
		}

		private void duohnRabql_SelectedIndexChanged(object sender, EventArgs e)
        {

			if (duohnRabql.SelectedItems.Count > 0)
			{
				method_5();
				LanguageEntry languageEntry = duohnRabql.SelectedItems[0].Tag as LanguageEntry;
				method_6(languageEntry.Messages);
			}
		}

        private void lvMessages_SelectedIndexChanged(object sender, EventArgs e)
        {

			if (this.lvMessages.SelectedItems.Count > 0)
			{
				MessageEntry messageEntry = this.lvMessages.SelectedItems[0].Tag as MessageEntry;
				this.messageEntry_0 = messageEntry;
				this.tbMessage.Text = messageEntry.Message;
			}
		}

        private void tbMessage_TextChanged_1(object sender, EventArgs e)
        {

			if (this.messageEntry_0 != null)
			{
				this.messageEntry_0.Message = this.tbMessage.Text;
			}
		}

        private void sameToolStripMenuItem_Click(object sender, EventArgs e)
        {
			if (this.languagesContainer_0 != null)
			{
				if (!string.IsNullOrWhiteSpace(openedloc))
				{

					LanguageBuilder languageBuilder = new LanguageBuilder();
					languageBuilder.Build(this.languagesContainer_0, openedloc);
					MessageBox.Show("Languages save has completed.", "Save completed");
				}
			}
		}

		internal static string smethod_3(string string_0, string string_1, string string_2, string string_3 = "")
		{
			global::System.Windows.Forms.SaveFileDialog saveFileDialog = new global::System.Windows.Forms.SaveFileDialog();
			string result = null;
			saveFileDialog.DefaultExt = string_0;
			saveFileDialog.Filter = string_1;
			saveFileDialog.InitialDirectory = string_2;
			saveFileDialog.FileName = string_3;
			global::System.Windows.Forms.DialogResult dialogResult = saveFileDialog.ShowDialog();
			if (dialogResult == global::System.Windows.Forms.DialogResult.OK)
			{
				result = saveFileDialog.FileName;
			}
			return result;
		}

        private void LOCEditor_Resize(object sender, EventArgs e)
        {
			lvMessages.Height = (panel1.Height / 2) - 28;
			tbMessage.Height = panel1.Height / 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
				lvMessages.Select();
				int i = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0)) - 1;
				lvMessages.Items[i].Focused = true;
				lvMessages.Items[i].Selected = true;
				lvMessages.Items[lastselect].Selected = false;
				lvMessages.Items[i].EnsureVisible();
				lastselect = i;
			}
            catch
            {

            }
        }
    }
}

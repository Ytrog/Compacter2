namespace Compacter
{
    public partial class Main : Form
    {

        private FolderManager folderManager;

        public Main()
        {
            InitializeComponent();
        }

        private void tsbOpen_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK) {
                folderManager = new() { Path =  folderBrowserDialog1.SelectedPath };
            }
        }
    }
}
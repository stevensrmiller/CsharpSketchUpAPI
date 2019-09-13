using System;
using System.IO;
using System.Windows.Forms;

namespace ExLumina.Examples.SketchUp.API
{
    public partial class MainForm : Form
    {
        const string outputDirectory = @"\Factory Output";

        string location =
            Environment.GetFolderPath(
                Environment.SpecialFolder.UserProfile);

        Example[] examples =
        {
            new ImageLoader("Image Loader"),
            new PlainQuad("Plain Quad"),
            new QuadWithHole("Quad with a Hole"),
            new TwoQuadsSharedPoints("Two Quads with Shared Points"),
            new TwoQuadsWeldedEdge("Two Quads with Welded Edge"),
            new TwoQuadsUnweldedEdge("Two Quads with Unwelded Edge"),
            new RedQuad("Red Quad"),
            new TexturedQuad("Textured Quad"),
            new TwoQuadsSeamlessTexture("Two Quads with Seamless Texture"),
            new TwoQuadsParentChild("Two Quads as Parent and Child"),
            new SixQuadFan("Six Quads in a Fan")
        };

        public MainForm()
        {
            InitializeComponent();

            foreach (var example in examples)
            {
                clbList.Items.Add(example);
            }

            for (int index = 0; index < clbList.Items.Count; ++index)
            {
                clbList.SetItemChecked(index, false);
            }

            if (Directory.Exists(location + outputDirectory))
            {
                location += outputDirectory;
            }
        }

        private void btnRunExamples_Click(object sender, EventArgs e)
        {
            foreach (int index in clbList.CheckedIndices)
            {
                ((Example)(clbList.Items[index])).Run(location);
            }

            MessageBox.Show(
                "Done.",
                "CsharpSketchUpAPI Examples",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnSetLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.Description = "Select the location where you want the example " +
                             "programs to create their SketchUp output files.";

            fd.SelectedPath = location;

            if (fd.ShowDialog() == DialogResult.OK)
            {
                btnRunExamples.Enabled = true;
                location = fd.SelectedPath;
                lblLocation.Text = location;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}

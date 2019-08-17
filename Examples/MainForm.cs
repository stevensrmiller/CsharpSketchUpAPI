using System;
using System.Windows.Forms;

namespace ExLumina.SketchUp.API.Examples
{
    public partial class MainForm : Form
    {
        string location;

        Example[] examples =
        {
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
                clbList.SetItemChecked(index, true);
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
    }
}

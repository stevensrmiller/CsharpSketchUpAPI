namespace ExLumina.Examples.SketchUp.API
{
    abstract class Example
    {
        readonly string name;

        public Example(string name)
        {
            this.name = name;
        }

        public Example() : this("<no name>")
        {

        }

        public abstract void Run(string path);

        public override string ToString()
        {
            return name;
        }
    }
}

using System;
using System.IO;
using System.Threading.Tasks;


namespace R5T.Bath.Default
{
    /// <summary>
    /// Note: Creator is responsible for disposal of the constructor-provided <see cref="System.IO.TextWriter"/> instance.
    /// </summary>
    public class TextWriterHumanOutput : IHumanOutput
    {
        protected TextWriter TextWriter { get; set; }


        public TextWriterHumanOutput(TextWriter textWriter)
        {
            this.TextWriter = textWriter;
        }

        protected TextWriterHumanOutput()
        {
        }

        public void WriteLine(string line)
        {
            this.TextWriter.WriteLine(line);
        }

        public async Task WriteLineAsync(string line)
        {
            await this.TextWriter.WriteLineAsync(line);
        }
    }
}

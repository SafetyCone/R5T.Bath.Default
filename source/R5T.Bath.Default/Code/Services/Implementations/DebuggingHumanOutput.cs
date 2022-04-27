using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.Bath.Default
{
    /// <summary>
    /// An <see cref="IHumanOutput"/> implementation for use during debugging.
    /// When an asynchronous output to a human operation is performed, program execution can continue until the operation is awaited. This means that the view of program execution offered to the human can be delayed relative to the actual execution of the program. This can be terribly misleading.
    /// This debugging-specific version of the <see cref="IHumanOutput"/> service implements "sync-over-async" to make asynchronous operations synchronous.
    /// This service should be added to a DI-container via a factory method that specifies which <see cref="IHumanOutput"/> service instance should be used internally.
    /// </summary>
    [ServiceImplementationMarker]
    public class DebuggingHumanOutput : IHumanOutput, IServiceImplementation
    {
        private IHumanOutput HumanOutput { get; }


        public DebuggingHumanOutput(IHumanOutput humanOutput)
        {
            this.HumanOutput = humanOutput;
        }

        public void WriteLine(string line)
        {
            this.HumanOutput.WriteLine(line);
        }

        public Task WriteLineAsync(string line)
        {
            this.HumanOutput.WriteLineAsync(line).Wait(); // Make the asynchronous operation synchronous.

            return Task.CompletedTask;
        }
    }
}

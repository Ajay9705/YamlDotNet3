namespace YamlDotNetFork.Samples.Helpers
{
    public interface ITestOutputHelper {
        void WriteLine();
        void WriteLine(string value);
        void WriteLine(string format, params object[] args);
    }
}

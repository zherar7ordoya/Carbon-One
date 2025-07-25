#define USE_CUSTOM

using System;
using System.Collections.Generic;

namespace ColorStressTest
{
    public interface IProcessor
    {
        void Execute();
    }

    public interface ICustom : IProcessor { }

    public enum Mode
    {
        Basic,
        Advanced
    }

    public struct Config
    {
        public const string DefaultPath = "/usr/bin";
        public static readonly int Timeout = 5000;

        public Mode CurrentMode;
        public string Path;

        public Config(Mode mode)
        {
            CurrentMode = mode;
            Path = DefaultPath;
        }
    }

    public class ProcessorBase : IProcessor
    {
        /// <summary>
        /// Executes the processor with an optional path.
        /// If no path is provided, it uses the default path defined in Config.
        /// </summary>
        /// <param name="path"></param>
        public virtual void Execute(string path = Config.DefaultPath)
        {
            Console.WriteLine($"Executing with path: {path}");
        }
    }

    public class AdvancedProcessor : ProcessorBase, ICustom
    {
        private const int value = 42;
        public override void Execute()
        {
            Console.WriteLine($"Executing with value: {value}");
        }
    }

    public static class ProcessorFactory
    {
        public static IProcessor Create(Mode mode)
        {
            switch (mode)
            {
                case Mode.Basic:
                    return new ProcessorBase();
                case Mode.Advanced:
                    return new AdvancedProcessor();
                default:
                    throw new InvalidOperationException();
            }
        }
    }

    public class App
    {
        private static readonly string[] options = { "basic", "advanced" };

        public static void Main(string[] args)
        {
#if USE_CUSTOM
            Mode selectedMode = Mode.Advanced;
#else
            Mode selectedMode = Mode.Basic;
#endif
            Config config = new Config(selectedMode);
            IProcessor processor = ProcessorFactory.Create(config.CurrentMode);
            processor.Execute();
        }
    }
}

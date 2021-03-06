using System;

namespace Svn2GitNet
{
    public class Worker
    {
        protected Options _options;
        protected ICommandRunner _commandRunner;
        protected string _gitConfigCommandArguments;
        protected IMessageDisplayer _messageDisplayer;

        public Worker(Options options,
                      ICommandRunner commandRunner,
                      string gitConfigCommandArguments,
                      IMessageDisplayer messageDisplayer)
        {
            _options = options;
            _commandRunner = commandRunner;
            _gitConfigCommandArguments = gitConfigCommandArguments;
            _messageDisplayer = messageDisplayer;
        }

        protected void ShowMessageIfPossible(string message)
        {
            if (_messageDisplayer != null)
            {
                _messageDisplayer.Show(message);
            }
        }

        protected void Log(string message)
        {
            if (_options.IsVerbose)
            {
                Console.WriteLine(message);
            }
        }

        protected string RunCommandIgnoreExitCode(CommandInfo cmdInfo)
        {
            return RunCommandIgnoreExitCode(cmdInfo.Command, cmdInfo.Arguments);
        }

        protected string RunCommandIgnoreExitCode(string cmd, string arguments)
        {
            string standardOutput;
            _commandRunner.Run(cmd, arguments, out standardOutput);

            return standardOutput;
        }

        protected int RunCommand(CommandInfo cmdInfo)
        {
            return _commandRunner.Run(cmdInfo.Command, cmdInfo.Arguments);
        }

        protected int RunCommand(CommandInfo cmdInfo, out string standardOutput)
        {
            return _commandRunner.Run(cmdInfo.Command, cmdInfo.Arguments, out standardOutput);
        }

        protected int RunCommand(CommandInfo cmdInfo, out string standardOutput, out string standardError)
        {
            return _commandRunner.Run(cmdInfo.Command, cmdInfo.Arguments, out standardOutput, out standardError);
        }
    }
}
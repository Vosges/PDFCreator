﻿using System.Collections.Generic;
using System.Windows.Input;

namespace pdfforge.PDFCreator.Core.Services.Macros
{
    public class MacroCommandBuilder : IMacroCommandBuilder
    {
        protected readonly List<ICommand> CommandList = new List<ICommand>();
        private readonly ICommandLocator _commandLocator;

        public MacroCommandBuilder(ICommandLocator commandLocator)
        {
            _commandLocator = commandLocator;
        }

        public IMacroCommand Build()
        {
            var macrocommand = new MacroCommand(CommandList);

            return macrocommand;
        }

        public IMacroCommandBuilder AddCommand(ICommand command)
        {
            if (command == null)
                return this;

            CommandList.Add(command);
            return this;
        }

        public IMacroCommandBuilder AddCommand<T>() where T : class, ICommand
        {
            var command = _commandLocator?.GetCommand<T>();
            AddCommand(command);
            return this;
        }
    }
}

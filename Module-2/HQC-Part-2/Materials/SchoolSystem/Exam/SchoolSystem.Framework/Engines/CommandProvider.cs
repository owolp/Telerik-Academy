using System;
using System.Linq;
using System.Reflection;

using SchoolSystem.Framework.Commands.Contracts;
using SchoolSystem.Framework.Engines.Contracts;

namespace SchoolSystem.Framework.Engines
{
    public class CommandProvider : ICommandProvider
    {
        public ICommand FindCommandExecutorWithName(string commandName)
        {
            var typeWithName = this.FindTypeWithName(commandName);
            if (typeWithName == null)
            {
                return null;
            }

            var commandInstance = Activator.CreateInstance(typeWithName) as ICommand;
            return commandInstance;
        }

        private TypeInfo FindTypeWithName(string typeName)
        {
            var thisAssembly = this.GetType().GetTypeInfo().Assembly;
            var typeWithName = thisAssembly.DefinedTypes
                .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                .FirstOrDefault(type => type.Name.ToLower().Contains(typeName.ToLower()));

            return typeWithName;
        }
    }
}

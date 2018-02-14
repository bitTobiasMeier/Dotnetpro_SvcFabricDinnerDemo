using System;

namespace SvcFabricDinnerDemo.ReliableServicesCore
{
    public class ActorInstanceInformation
    {
        public ActorInstanceInformation(string internalName, Guid key)
        {
            this.InternalName = internalName;
            this.Key = key;
        }
        public string InternalName { get; private set; }
        public Guid Key { get; private set; }
    }
}
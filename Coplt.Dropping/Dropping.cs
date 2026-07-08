namespace Coplt.Dropping
{
    /// <summary>
    /// Where to call drop
    /// </summary>
    [Flags]
    public enum DropFrom
    {
        /// <summary>
        /// Dispose will call this
        /// </summary>
        Dispose = 1 << 0,
        /// <summary>
        /// Finalizer will call this
        /// </summary>
        Finalizer = 1 << 1,
        /// <summary>
        /// Dispose and Finalizer will call this
        /// </summary>
        Always = Dispose | Finalizer,
    }

    /// <summary>
    /// Mark this type as needing to be disposable
    /// </summary>
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class, Inherited = false)]
    internal sealed class DroppingAttribute : Attribute
    {
        /// <summary>
        /// <c>false</c> to disable inherit
        /// </summary>
        public bool AllowInherit { get; set; } = true;
        /// <summary>
        /// Set default <see cref="DropFrom"/>, struct will ignore
        /// </summary>
        public DropFrom From { get; set; } = DropFrom.Always;
    }

    /// <summary>
    /// Mark the dispose target, can be a method, field, or property
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Field | AttributeTargets.Property, Inherited = false)]
    internal sealed class DropAttribute : Attribute
    {
        /// <summary>
        /// Calling order
        /// </summary>
        public int Order { get; set; }
        /// <summary>
        /// Where to call drop, struct will ignore
        /// </summary>
        public DropFrom From { get; set; } = DropFrom.Always;
    }
}

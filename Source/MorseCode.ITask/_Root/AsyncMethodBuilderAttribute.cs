#if !NETSTANDARD2_1_OR_GREATER && !NETCOREAPP1_1_OR_GREATER
namespace System.Runtime.CompilerServices
{
    sealed class AsyncMethodBuilderAttribute : Attribute
    {
        public Type BuilderType { get; }

        public AsyncMethodBuilderAttribute(
            Type builderType)
        {
            BuilderType = builderType;
        }
    }
}
#endif

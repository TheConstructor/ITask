using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace MorseCode.ITask.Tests
{
    [TestFixture]
    public class TaskInterfaceAsyncMethodBuilderTests
    {
        private const string StackTraceRedactionPattern = "\\w__[\\w_]+(?=[()<>.])|(?<=\\(\\)) in [^\r\n]+";

        [Test]
        public async Task TaskInterfaceAsyncMethodBuilderTask()
        {
            await TaskInterfaceAsyncMethodBuilderTaskMethodAsync().ConfigureAwait(false);
        }

        async ITask TaskInterfaceAsyncMethodBuilderTaskMethodAsync()
        {
            await Task.Delay(50).ConfigureAwait(false);
        }

        [Test]
        [SetUICulture("")]
        public void TaskInterfaceAsyncMethodBuilderTaskWithException()
        {
            var exception = Assert.ThrowsAsync<Exception>(async () =>
                await TaskInterfaceAsyncMethodBuilderTaskWithExceptionMethodAsync().ConfigureAwait(false));
            Assert.AreEqual("Test-Case Exception", exception.Message);
            var redactedStackTrace = Regex.Replace(exception.StackTrace, StackTraceRedactionPattern, "");
#if NET6_0_OR_GREATER
            Assert.AreEqual(
                """
                   at MorseCode.ITask.Tests.TaskInterfaceAsyncMethodBuilderTests.TaskInterfaceAsyncMethodBuilderTaskWithExceptionMethodAsync()
                   at MorseCode.ITask.Tests.TaskInterfaceAsyncMethodBuilderTests.<TaskInterfaceAsyncMethodBuilderTaskWithException>()
                   at NUnit.Framework.Internal.TaskAwaitAdapter.GenericAdapter`1.BlockUntilCompleted()
                   at NUnit.Framework.Internal.MessagePumpStrategy.NoMessagePumpStrategy.WaitForCompletion(AwaitAdapter awaiter)
                   at NUnit.Framework.Internal.AsyncToSyncAdapter.Await[TResult](TestExecutionContext context, Func`1 invoke)
                   at NUnit.Framework.Internal.AsyncToSyncAdapter.Await(TestExecutionContext context, Func`1 invoke)
                   at NUnit.Framework.Assert.ThrowsAsync(IResolveConstraint expression, AsyncTestDelegate code, String message, Object[] args)
                """,
                redactedStackTrace);
#elif DEBUG
            StringAssert.StartsWith(
                """
                   at MorseCode.ITask.Tests.TaskInterfaceAsyncMethodBuilderTests.<TaskInterfaceAsyncMethodBuilderTaskWithExceptionMethodAsync>.MoveNext()
                --- End of stack trace from previous location where exception was thrown ---
                   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
                   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
                   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable.ConfiguredTaskAwaiter.GetResult()
                   at MorseCode.ITask.ConfiguredTaskAwaiterWrapper.MorseCode.ITask.IAwaiter.GetResult()
                   at MorseCode.ITask.Tests.TaskInterfaceAsyncMethodBuilderTests.<<TaskInterfaceAsyncMethodBuilderTaskWithException>>d.MoveNext()
                --- End of stack trace from previous location where exception was thrown ---
                   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
                   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
                """,
                redactedStackTrace);
#else
            StringAssert.StartsWith(
                """
                   at MorseCode.ITask.Tests.TaskInterfaceAsyncMethodBuilderTests.<TaskInterfaceAsyncMethodBuilderTaskWithExceptionMethodAsync>.MoveNext()
                --- End of stack trace from previous location where exception was thrown ---
                   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
                   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
                   at MorseCode.ITask.ConfiguredTaskAwaiterWrapper.MorseCode.ITask.IAwaiter.GetResult()
                   at MorseCode.ITask.Tests.TaskInterfaceAsyncMethodBuilderTests.<<TaskInterfaceAsyncMethodBuilderTaskWithException>>d.MoveNext()
                --- End of stack trace from previous location where exception was thrown ---
                   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
                   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
                """,
                redactedStackTrace);
#endif
        }

        [Test]
        [SetUICulture("")]
        public void TaskInterfaceAsyncMethodBuilderTaskWithExceptionNoConfigure()
        {
            var exception = Assert.ThrowsAsync<Exception>(async () =>
                await TaskInterfaceAsyncMethodBuilderTaskWithExceptionMethodAsync());
            Assert.AreEqual("Test-Case Exception", exception.Message);
            var redactedStackTrace = Regex.Replace(exception.StackTrace, StackTraceRedactionPattern, "");
#if NET6_0_OR_GREATER
            Assert.AreEqual(
                """
                   at MorseCode.ITask.Tests.TaskInterfaceAsyncMethodBuilderTests.TaskInterfaceAsyncMethodBuilderTaskWithExceptionMethodAsync()
                   at MorseCode.ITask.Tests.TaskInterfaceAsyncMethodBuilderTests.<TaskInterfaceAsyncMethodBuilderTaskWithExceptionNoConfigure>()
                   at NUnit.Framework.Internal.TaskAwaitAdapter.GenericAdapter`1.BlockUntilCompleted()
                   at NUnit.Framework.Internal.MessagePumpStrategy.NoMessagePumpStrategy.WaitForCompletion(AwaitAdapter awaiter)
                   at NUnit.Framework.Internal.AsyncToSyncAdapter.Await[TResult](TestExecutionContext context, Func`1 invoke)
                   at NUnit.Framework.Internal.AsyncToSyncAdapter.Await(TestExecutionContext context, Func`1 invoke)
                   at NUnit.Framework.Assert.ThrowsAsync(IResolveConstraint expression, AsyncTestDelegate code, String message, Object[] args)
                """,
                redactedStackTrace);
#elif DEBUG
            StringAssert.StartsWith(
                """
                   at MorseCode.ITask.Tests.TaskInterfaceAsyncMethodBuilderTests.<TaskInterfaceAsyncMethodBuilderTaskWithExceptionMethodAsync>.MoveNext()
                --- End of stack trace from previous location where exception was thrown ---
                   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
                   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
                   at System.Runtime.CompilerServices.TaskAwaiter.GetResult()
                   at MorseCode.ITask.TaskAwaiterWrapper.MorseCode.ITask.IAwaiter.GetResult()
                   at MorseCode.ITask.Tests.TaskInterfaceAsyncMethodBuilderTests.<<TaskInterfaceAsyncMethodBuilderTaskWithExceptionNoConfigure>>d.MoveNext()
                --- End of stack trace from previous location where exception was thrown ---
                   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
                   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
                """,
                redactedStackTrace);
#else
            StringAssert.StartsWith(
                """
                   at MorseCode.ITask.Tests.TaskInterfaceAsyncMethodBuilderTests.<TaskInterfaceAsyncMethodBuilderTaskWithExceptionMethodAsync>.MoveNext()
                --- End of stack trace from previous location where exception was thrown ---
                   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
                   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
                   at MorseCode.ITask.TaskAwaiterWrapper.MorseCode.ITask.IAwaiter.GetResult()
                   at MorseCode.ITask.Tests.TaskInterfaceAsyncMethodBuilderTests.<<TaskInterfaceAsyncMethodBuilderTaskWithExceptionNoConfigure>>d.MoveNext()
                --- End of stack trace from previous location where exception was thrown ---
                   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
                   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
                """,
                redactedStackTrace);
#endif
        }

        async ITask TaskInterfaceAsyncMethodBuilderTaskWithExceptionMethodAsync()
        {
            await Task.Delay(50).ConfigureAwait(false);
            throw new Exception("Test-Case Exception");
        }

        [Test]
        public async Task TaskInterfaceAsyncMethodBuilderResultTask()
        {
            var value = await TaskInterfaceAsyncMethodBuilderResultTaskMethodAsync().ConfigureAwait(false);
            Assert.AreEqual(3, value);
        }

        async ITask<int> TaskInterfaceAsyncMethodBuilderResultTaskMethodAsync()
        {
            var results = await Task.WhenAll(
                Enumerable.Range(0, 3).Select(async i =>
                {
                    await Task.Delay(i);
                    return i;
                }));
            return results.Length;
        }

        [Test]
        [SetUICulture("")]
        public void TaskInterfaceAsyncMethodBuilderResultTaskWithException()
        {
            var exception = Assert.ThrowsAsync<Exception>(async () =>
                await TaskInterfaceAsyncMethodBuilderResultTaskWithExceptionMethodAsync().ConfigureAwait(false));
            Assert.AreEqual("Test-Case Exception", exception.Message);
            var redactedStackTrace = Regex.Replace(exception.StackTrace, StackTraceRedactionPattern, "");
#if NET6_0_OR_GREATER
            Assert.AreEqual(
                """
                   at MorseCode.ITask.Tests.TaskInterfaceAsyncMethodBuilderTests.TaskInterfaceAsyncMethodBuilderResultTaskWithExceptionMethodAsync()
                   at MorseCode.ITask.Tests.TaskInterfaceAsyncMethodBuilderTests.<TaskInterfaceAsyncMethodBuilderResultTaskWithException>()
                   at NUnit.Framework.Internal.TaskAwaitAdapter.GenericAdapter`1.BlockUntilCompleted()
                   at NUnit.Framework.Internal.MessagePumpStrategy.NoMessagePumpStrategy.WaitForCompletion(AwaitAdapter awaiter)
                   at NUnit.Framework.Internal.AsyncToSyncAdapter.Await[TResult](TestExecutionContext context, Func`1 invoke)
                   at NUnit.Framework.Internal.AsyncToSyncAdapter.Await(TestExecutionContext context, Func`1 invoke)
                   at NUnit.Framework.Assert.ThrowsAsync(IResolveConstraint expression, AsyncTestDelegate code, String message, Object[] args)
                """,
                redactedStackTrace);
#elif DEBUG
            StringAssert.StartsWith(
                """
                   at MorseCode.ITask.Tests.TaskInterfaceAsyncMethodBuilderTests.<TaskInterfaceAsyncMethodBuilderResultTaskWithExceptionMethodAsync>.MoveNext()
                --- End of stack trace from previous location where exception was thrown ---
                   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
                   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
                   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
                   at MorseCode.ITask.ConfiguredTaskAwaiterWrapper`1.MorseCode.ITask.IAwaiter<TResult>.GetResult()
                   at MorseCode.ITask.Tests.TaskInterfaceAsyncMethodBuilderTests.<<TaskInterfaceAsyncMethodBuilderResultTaskWithException>>d.MoveNext()
                --- End of stack trace from previous location where exception was thrown ---
                   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
                   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
                """,
                redactedStackTrace);
#else
            StringAssert.StartsWith(
                """
                   at MorseCode.ITask.Tests.TaskInterfaceAsyncMethodBuilderTests.<TaskInterfaceAsyncMethodBuilderResultTaskWithExceptionMethodAsync>.MoveNext()
                --- End of stack trace from previous location where exception was thrown ---
                   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
                   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
                   at MorseCode.ITask.ConfiguredTaskAwaiterWrapper`1.MorseCode.ITask.IAwaiter<TResult>.GetResult()
                   at MorseCode.ITask.Tests.TaskInterfaceAsyncMethodBuilderTests.<<TaskInterfaceAsyncMethodBuilderResultTaskWithException>>d.MoveNext()
                --- End of stack trace from previous location where exception was thrown ---
                   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
                   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
                """,
                redactedStackTrace);
#endif
        }

        [Test]
        [SetUICulture("")]
        public void TaskInterfaceAsyncMethodBuilderResultTaskWithExceptionNoConfigure()
        {
            var exception = Assert.ThrowsAsync<Exception>(async () =>
                await TaskInterfaceAsyncMethodBuilderResultTaskWithExceptionMethodAsync());
            Assert.AreEqual("Test-Case Exception", exception.Message);
            var redactedStackTrace = Regex.Replace(exception.StackTrace, StackTraceRedactionPattern, "");
#if NET6_0_OR_GREATER
            Assert.AreEqual(
                """
                   at MorseCode.ITask.Tests.TaskInterfaceAsyncMethodBuilderTests.TaskInterfaceAsyncMethodBuilderResultTaskWithExceptionMethodAsync()
                   at MorseCode.ITask.Tests.TaskInterfaceAsyncMethodBuilderTests.<TaskInterfaceAsyncMethodBuilderResultTaskWithExceptionNoConfigure>()
                   at NUnit.Framework.Internal.TaskAwaitAdapter.GenericAdapter`1.BlockUntilCompleted()
                   at NUnit.Framework.Internal.MessagePumpStrategy.NoMessagePumpStrategy.WaitForCompletion(AwaitAdapter awaiter)
                   at NUnit.Framework.Internal.AsyncToSyncAdapter.Await[TResult](TestExecutionContext context, Func`1 invoke)
                   at NUnit.Framework.Internal.AsyncToSyncAdapter.Await(TestExecutionContext context, Func`1 invoke)
                   at NUnit.Framework.Assert.ThrowsAsync(IResolveConstraint expression, AsyncTestDelegate code, String message, Object[] args)
                """,
                redactedStackTrace);
#elif DEBUG
            StringAssert.StartsWith(
                """
                   at MorseCode.ITask.Tests.TaskInterfaceAsyncMethodBuilderTests.<TaskInterfaceAsyncMethodBuilderResultTaskWithExceptionMethodAsync>.MoveNext()
                --- End of stack trace from previous location where exception was thrown ---
                   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
                   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
                   at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()
                   at MorseCode.ITask.TaskAwaiterWrapper`1.MorseCode.ITask.IAwaiter<TResult>.GetResult()
                   at MorseCode.ITask.Tests.TaskInterfaceAsyncMethodBuilderTests.<<TaskInterfaceAsyncMethodBuilderResultTaskWithExceptionNoConfigure>>d.MoveNext()
                --- End of stack trace from previous location where exception was thrown ---
                   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
                   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
                """,
                redactedStackTrace);
#else
            StringAssert.StartsWith(
                """
                   at MorseCode.ITask.Tests.TaskInterfaceAsyncMethodBuilderTests.<TaskInterfaceAsyncMethodBuilderResultTaskWithExceptionMethodAsync>.MoveNext()
                --- End of stack trace from previous location where exception was thrown ---
                   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
                   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
                   at MorseCode.ITask.TaskAwaiterWrapper`1.MorseCode.ITask.IAwaiter<TResult>.GetResult()
                   at MorseCode.ITask.Tests.TaskInterfaceAsyncMethodBuilderTests.<<TaskInterfaceAsyncMethodBuilderResultTaskWithExceptionNoConfigure>>d.MoveNext()
                --- End of stack trace from previous location where exception was thrown ---
                   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
                   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
                """,
                redactedStackTrace);
#endif
        }

        async ITask<int> TaskInterfaceAsyncMethodBuilderResultTaskWithExceptionMethodAsync()
        {
            await Task.Delay(50).ConfigureAwait(false);
            throw new Exception("Test-Case Exception");
        }
    }
}

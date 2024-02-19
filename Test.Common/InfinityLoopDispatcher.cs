namespace Test.Common;

public abstract class InfiniteLoopDispatcher
{
	private readonly ManualResetEvent mre = new(false);

	public DateTime? NotifySelfAt;

	protected InfiniteLoopDispatcher()
	{
		var thread = new Thread(() =>
		{
			while (CanProcess())
			{
				ProcessingLoop();
			}
		})
		{
#if (!DEBUG)
            IsBackground = true
#endif
		};
		thread.Start();
	}

	protected void NotifyLoop()
	{
		mre.Set();
	}

	protected void PauseLoop()
	{
		mre.Reset();
	}

	private void ProcessingLoop()
	{
		while (CanProcess())
		{
			ProcessLoop();
		}
	}

	private bool CanProcess()
	{
		if (NotifySelfAt is null)
		{
			return mre.WaitOne();
		}

		var timeToWait = NotifySelfAt.Value - DateTime.UtcNow;

		if (timeToWait >= TimeSpan.Zero)
		{
			if (!mre.WaitOne(timeToWait))
			{
				NotifySelfAt = null;
			}
		}

		return true;
	}

	protected abstract void ProcessLoop();
}



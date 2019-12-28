namespace Hiralal.AdvancedPatterns.Pooling
{
	public class PoolToolSingleton<T> : PoolTool
		where T:PoolToolSingleton<T>
	{
		public static T Instance { get; private set; }

		private void Awake()
		{
			if (Instance == null) Instance = (T)this;
			else Destroy(this);
		}
	}

	/*
	Example Template:
	 
	public class AsteroidPool : PoolToolSingleton<AsteroidPool> { }
	 */
}
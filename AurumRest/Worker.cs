﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumRest
{
	public class Worker
	{
		// This method will be called when the thread is started.
		public void DoWork(object obj)
		{
			while (!_shouldStop)
			{
				Console.WriteLine("worker thread: working...");
			}
			Console.WriteLine("worker thread: terminating gracefully.");
		}
		public void RequestStop()
		{
			_shouldStop = true;
		}
		// Volatile is used as hint to the compiler that this data
		// member will be accessed by multiple threads.
		private volatile bool _shouldStop;

	}
}

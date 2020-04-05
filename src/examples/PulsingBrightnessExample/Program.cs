﻿using System;
using System.Threading;

namespace SharpPiLed.Examples.PulsingBrightnessExample
{
	public class Program
	{
		public static int Main(string[] args)
		{
			var matrix = new LedMatrix(new LedMatrixOptions(), args);
			var canvas = matrix.CreateOffscreenCanvas();

			var maxBrightness = matrix.Brightness;
			var count = 0;
			const int c = 255;

			while (!Console.KeyAvailable)
			{
				if (matrix.Brightness < 1)
				{
					matrix.Brightness = maxBrightness;
					count += 1;
				}
				else
				{
					matrix.Brightness -= 1;
				}

				switch (count % 4)
				{
					case 0:
						canvas.Fill(new Color(c, 0, 0));
						break;
					case 1:
						canvas.Fill(new Color(0, c, 0));
						break;
					case 2:
						canvas.Fill(new Color(0, 0, c));
						break;
					case 3:
						canvas.Fill(new Color(c, c, c));
						break;
				}

				canvas = matrix.SwapOnVsync(canvas);

				Thread.Sleep(20);
			}

			return 0;
		}
	}
}

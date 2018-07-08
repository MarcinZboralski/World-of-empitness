using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DunGen
{
	public sealed class GenerationStats
	{
        public int MainPathRoomCount { get; private set; }
        public int BranchPathRoomCount { get; private set; }
        public int TotalRoomCount { get; private set; }
        public int MaxBranchDepth { get; private set; }
		public int TotalRetries { get; private set; }
        
        public float PreProcessTime { get; private set; }
        public float MainPathGenerationTime { get; private set; }
        public float BranchPathGenerationTime { get; private set; }
        public float PostProcessTime { get; private set; }
        public float TotalTime { get; private set; }

        private Stopwatch stopwatch = new Stopwatch();
        private GenerationStatus generationStatus;


		internal void Clear()
		{
			MainPathRoomCount = BranchPathRoomCount = TotalRoomCount = MaxBranchDepth = TotalRetries = 0;
			PreProcessTime = MainPathGenerationTime = BranchPathGenerationTime = PostProcessTime = TotalTime = 0;
		}

		internal void IncrementRetryCount()
		{
			TotalRetries++;
		}

        internal void SetRoomStatistics(int mainPathRoomCount, int branchPathRoomCount, int maxBranchDepth)
        {
            MainPathRoomCount = mainPathRoomCount;
            BranchPathRoomCount = branchPathRoomCount;
            MaxBranchDepth = maxBranchDepth;
            TotalRoomCount = MainPathRoomCount + BranchPathRoomCount;
        }

        internal void BeginTime(GenerationStatus status)
        {
            if (stopwatch.IsRunning)
                EndTime();

            generationStatus = status;
            stopwatch.Reset();
            stopwatch.Start();
        }

        internal void EndTime()
        {
            stopwatch.Stop();
            float elapsedTime = (float)stopwatch.Elapsed.TotalMilliseconds;

            switch (generationStatus)
            {
                case GenerationStatus.PreProcessing:
                    PreProcessTime += elapsedTime;
                    break;
                case GenerationStatus.MainPath:
                    MainPathGenerationTime += elapsedTime;
                    break;
                case GenerationStatus.Branching:
                    BranchPathGenerationTime += elapsedTime;
                    break;
                case GenerationStatus.PostProcessing:
                    PostProcessTime += elapsedTime;
                    break;
            }

            TotalTime = PreProcessTime + MainPathGenerationTime + BranchPathGenerationTime + PostProcessTime;
        }

		public GenerationStats Clone()
		{
		    GenerationStats newStats = new GenerationStats
		    {
		        MainPathRoomCount = MainPathRoomCount,
		        BranchPathRoomCount = BranchPathRoomCount,
		        TotalRoomCount = TotalRoomCount,
		        MaxBranchDepth = MaxBranchDepth,
		        TotalRetries = TotalRetries,
		        PreProcessTime = PreProcessTime,
		        MainPathGenerationTime = MainPathGenerationTime,
		        BranchPathGenerationTime = BranchPathGenerationTime,
		        PostProcessTime = PostProcessTime,
		        TotalTime = TotalTime
		    };



		    return newStats;
		}
	}
}

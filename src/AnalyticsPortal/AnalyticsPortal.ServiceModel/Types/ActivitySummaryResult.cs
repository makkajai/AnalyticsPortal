namespace AnalyticsPortal.ServiceModel.Types
{
    public class ActivitySummaryResult
    {
        /// <summary>
        /// Total Duration student played
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Student for which this result has been generated
        /// </summary>
        public Student Student { get; set; }

        /// <summary>
        /// Activity for which this result has been generated
        /// </summary>
        public Activity Activity { get; set; }

        public int MaxLevel { get; set; }

        public int Correct { get; set; }

        public int Incorrect { get; set; }

        /// <summary>
        /// How many log entries are considered for this result
        /// </summary>
        public int LastX { get; set; }
    }
}

using System.Collections.Generic;
using System.Linq;

namespace Matrise.Services.NetCheck
{
    public class SpeedTestResultAggregator
    {
        public double CalculateAverageDownloadSpeed(List<double> downloadSpeeds)
        {
            return downloadSpeeds.Average();
        }

        public double CalculateAverageUploadSpeed(List<double> uploadSpeeds)
        {
            return uploadSpeeds.Average();
        }
    }
}

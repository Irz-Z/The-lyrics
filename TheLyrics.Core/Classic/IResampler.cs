using TheLyrics.Core.Ustx;
using Serilog;

namespace TheLyrics.Classic {
    public interface IResampler {
        string FilePath { get; }
        float[] DoResampler(ResamplerItem args, ILogger logger);
        string DoResamplerReturnsFile(ResamplerItem args, ILogger logger);
        void CheckPermissions();
        ResamplerManifest Manifest {  get; }
        bool SupportsFlag(string abbr);
    }
}

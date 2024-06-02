using System.Diagnostics;
using JsonDiffPatchDotNet;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Logging;
using DvdRental.Library.Handlers;
using DvdRental.Library.Models;

namespace DvdRental.Library.Services
{
    public class ContextStatusService : IContextStatusService
    {
        private HandlerType _handlerType;
        private JObject _start;
        private JObject _end;
        private Stopwatch _watch;
        private long _elapsed;
        private readonly ILogger _logger;

        public ContextStatusService(ILogger<ContextStatusService> logger)
        {
            _logger = logger;
        }

        public void StartContext(HandlerType handlerType, DvdRentalContext context)
        {
            _handlerType = handlerType;

            if (_logger.IsEnabled(LogLevel.Debug))
                _start = JObject.FromObject(context);

            _watch = new Stopwatch();
            _watch.Start();
        }

        public void EndContext(DvdRentalContext context)
        {
            _watch.Stop();
            _elapsed = _watch.ElapsedMilliseconds;

            if (_logger.IsEnabled(LogLevel.Debug))
                _end = JObject.FromObject(context);

            TrackDifferences();
        }

        private void TrackDifferences()
        {
            var jsonDiff = new JsonDiffPatch();

            var diff = jsonDiff.Diff(_start, _end);

            _logger.LogInformation($"{_handlerType} took {_elapsed}ms.");

            _logger.LogDebug($"Json Differences:\n {diff}");
        }
    }
}

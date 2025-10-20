using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using System.Threading.Tasks;
using SPTarkov.Server.Core.Models.Utils;

namespace TTC.Mod.Load;

[Injectable(TypePriority = OnLoadOrder.PreSptModLoader + 10)]
public sealed class PreSpt : IOnLoad
{
	private readonly ISptLogger<PreSpt> _logger;

	public PreSpt(ISptLogger<PreSpt> logger)
	{
		_logger = logger;
	}

	public Task OnLoad()
	{
		_logger.Info("[TTC] PreSpt starting - configs validation pending.");
		return Task.CompletedTask;
	}
}

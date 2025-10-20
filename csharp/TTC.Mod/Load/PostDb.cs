using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using System.Threading.Tasks;
using SPTarkov.Server.Core.Models.Utils;

namespace TTC.Mod.Load;

[Injectable(TypePriority = OnLoadOrder.Database + 50)]
public sealed class PostDb : IOnLoad
{
	private readonly ISptLogger<PostDb> _logger;

	public PostDb(ISptLogger<PostDb> logger)
	{
		_logger = logger;
	}

	public Task OnLoad()
	{
		_logger.Info("[TTC] PostDB starting - vertical slice TBD.");
		return Task.CompletedTask;
	}
}

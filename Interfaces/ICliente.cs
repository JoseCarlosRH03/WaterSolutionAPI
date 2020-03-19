using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterSolutionAPI.ModelDTO;
using WaterSolutionAPI.Models;

namespace WaterSolutionAPI.Interfaces
{
	public interface ICliente
	{
		Task<Cliente> Save(Cliente model);
		Task<Cliente> Edit(Cliente model);
		Task<List<ClienteDTO>> MostrarCliente(int id);
		bool Exists(int id);
	}
}

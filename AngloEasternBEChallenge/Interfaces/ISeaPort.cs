using AngloEasternBEChallenge.Models;

namespace AngloEasternBEChallenge.Interfaces
{
    public interface ISeaPort
    {
        Task<List<MdlSeaPort>> GetAllSeaPorts();
    }
}

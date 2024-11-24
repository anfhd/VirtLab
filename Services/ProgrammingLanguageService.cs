using Contracts;
using Entities.Models;
using Services.Contracts;

namespace Services;

internal sealed class ProgrammingLanguageService(IRepositoryManager repository) : IProgrammingLanguageService
{
    public IEnumerable<ProgrammingLanguage> GetAllProgrammingLanguages(bool trackChanges) =>
        repository.ProgrammingLanguage.GetAllProgrammingLanguages(trackChanges);
}
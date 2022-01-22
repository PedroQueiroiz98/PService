using PS.Domain.Shared;

namespace PS.Domain.Service;


public class Service : Entity , IAggregateRoot{

    private List<Problem> _problems;
    public IReadOnlyList<Problem> problems=>_problems.AsReadOnly();
    public Service(){
        _problems = new List<Problem>();
    }
}
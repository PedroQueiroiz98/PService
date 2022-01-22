using PS.Domain.Shared;

namespace PS.Domain.Service;



public class Problem : Entity{
    
    public Level Level {get; private set;}
    private List<Process> _process;
    public IReadOnlyList<Process> Processes=>_process.AsReadOnly();
    public Problem(Level level){
        Level = level;
        _process = new List<Process>();
    }

}